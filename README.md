# CareLinkClient
Experimental C# library for retrieving data from Medtronic CareLink™.

#Disclaimer and Warning
This project is intended for educational and informational purposes only. It relies on a series of fragile components and assumptions, any of which may break at any time. It is not FDA approved and should not be used to make medical decisions. It is neither affiliated with nor endorsed by Medtronic, and may violate their Terms of Service. Use of this code is without warranty or formal support of any kind.

# How to use
- Use the CareLinkService as an example.
- It needs initial valid access token and expiration time obtained by manual.
  1. Login to the CareLink portal.
  1. In Google Chrome, open the Developer Tools window (right click and Inspect).
  1. Application tab -> Cookies
  1. `auth_tmp_token` is the token.
  1. `c_token_valid_to` is the token's expiration time.

# Used libraries
## [HttpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient)
- [Guidelines for using HttpClient](https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient-guidelines)
- [IHttpClientFactory with .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory)
- [Make HTTP requests using IHttpClientFactory in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests)
- [Use IHttpClientFactory to implement resilient HTTP requests](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)
- [Stop using the HttpClient the wrong way in .NET](https://www.youtube.com/watch?v=Z6Y2adsMnAA)
- [The Secret HttpClient Feature You Need To Use in .NET](https://www.youtube.com/watch?v=goxI3rOMnmY)
- [You are mocking the HttpClient the wrong way](https://www.youtube.com/watch?v=7OFZZAHGv9o)

## [Polly](https://www.thepollyproject.org/)
- [The CORRECT way to implement Retries in .NET](https://www.youtube.com/watch?v=nJH0PC2Pubs)

## [JSON.NET](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/overview)
- [How to write custom converters for JSON serialization](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/converters-how-to)
- [How to use source generation in System.Text.Json](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/source-generation)

# Credits
This project is based on other projects:
- [carelink-python-client](https://github.com/ondrej1024/carelink-python-client)
- [CareLinkJavaClient](https://github.com/benceszasz/CareLinkJavaClient) 


