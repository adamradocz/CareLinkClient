using CareLinkClient.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CareLinkClient.Helpers;

[JsonSourceGenerationOptions(JsonSerializerDefaults.General,
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNameCaseInsensitive = false,
    NumberHandling = JsonNumberHandling.AllowReadingFromString,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase
    )]
[JsonSerializable(typeof(Patient))]
internal partial class PatientJsonContext : JsonSerializerContext
{}
