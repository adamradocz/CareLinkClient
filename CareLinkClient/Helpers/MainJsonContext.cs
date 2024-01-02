using CareLinkClient.Models.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CareLinkClient.Helpers;

[JsonSourceGenerationOptions(JsonSerializerDefaults.General,
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNameCaseInsensitive = false,
    NumberHandling = JsonNumberHandling.Strict,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    Converters = [typeof(MassConcentrationJsonConverter)]
    )]
[JsonSerializable(typeof(Main))]
internal partial class MainJsonContext : JsonSerializerContext
{}
