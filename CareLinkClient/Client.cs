using CareLinkClient.Helpers;
using CareLinkClient.Models;
using CareLinkClient.Models.Data;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CareLinkClient;

public class Client : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly CareLinkClientOptions _careLinkClientOptions;
    private readonly ByteArrayContent _refreshTokenContent = new(Array.Empty<byte>());

    private bool _disposedValue;

    public DateTimeOffset TokenExpirationUtc { get; private set; }

    public Client(HttpClient httpClient, IOptions<CareLinkClientOptions> options)
    {
        ArgumentNullException.ThrowIfNull(httpClient);

        _httpClient = httpClient;
        _careLinkClientOptions = options.Value;

        TokenExpirationUtc = _careLinkClientOptions.TokenExpirationUtc;

        _httpClient.BaseAddress = GetBaseAddress(_careLinkClientOptions.CountryCode);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _careLinkClientOptions.InitialBearerToken);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        _httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
        _httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
        _httpClient.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Not_A Brand\";v=\"8\", \"Chromium\";v=\"120\", \"Google Chrome\";v=\"120\"");
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
    }

    private static Uri GetBaseAddress(in string countryCode)
    {
        return countryCode.Equals("US", StringComparison.OrdinalIgnoreCase)
            ? new Uri("https://carelink.minimed.com")
            : new Uri("https://carelink.minimed.eu");
    }

    public async Task RefreshTokenAsync(CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.PostAsync("patient/sso/reauth", _refreshTokenContent, cancellationToken).ConfigureAwait(false);
        var cookies = response.Headers.NonValidated["Set-Cookie"];

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetNewTokenFromCookie(cookies.ElementAt(0)));
        TokenExpirationUtc = GetExpirationTimeFromCookie(cookies.ElementAt(1));
    }

    private static string GetNewTokenFromCookie(ReadOnlySpan<char> tokenCookieAsSpan)
    {
        var newAuthTmpTokenAsSpan = tokenCookieAsSpan["auth_tmp_token=".Length..tokenCookieAsSpan.IndexOf(';')];
        return new string(newAuthTmpTokenAsSpan);
    }

    private static DateTimeOffset GetExpirationTimeFromCookie(ReadOnlySpan<char> expirationTimeCookieAsSpan)
    {
        var expirationTimeAsSpan = expirationTimeCookieAsSpan["c_token_valid_to=".Length..expirationTimeCookieAsSpan.IndexOf(';')];
        return DateTimeOffset.ParseExact(expirationTimeAsSpan, "ddd MMM dd HH:mm:ss UTC yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
    }

    public Task<Main?> GetPatientDataAsync(CancellationToken cancellationToken = default)
        => _httpClient.GetFromJsonAsync($"patient/connect/data?cpSerialNumber=NONE&msgType=last24hours&requestTime={DateTimeOffset.Now.ToUnixTimeMilliseconds()}", MainJsonContext.Default.Main, cancellationToken);

    public Task<Patient?> GetPatientAsync(CancellationToken cancellationToken = default)
        => _httpClient.GetFromJsonAsync("/patient/users/me/", PatientJsonContext.Default.Patient, cancellationToken);

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
                _refreshTokenContent.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
