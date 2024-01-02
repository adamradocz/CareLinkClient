using System.Text.Json.Serialization;
using UnitsNet;

namespace CareLinkClient.Models.Data;

public class Main
{
    [JsonPropertyName("deviceKind")]
    public string DeviceKind { get; set; } = string.Empty;

    [JsonPropertyName("lastSensorTSAsString")]
    public DateTimeOffset LastSensorTimeStamp { get; set; }

    [JsonPropertyName("medicalDeviceTimeAsString")]
    public DateTimeOffset MedicalDeviceTimeAsString { get; set; }

    [JsonPropertyName("bgunits")]
    public string BloodGlucoseUnits { get; set; } = string.Empty;

    [JsonPropertyName("lastSensorTS")]
    public long LastSensorTs { get; set; }

    [JsonPropertyName("kind")]
    public string Kind { get; set; } = string.Empty;

    [JsonPropertyName("version")]
    public float Version { get; set; }

    [JsonPropertyName("currentServerTime")]
    public long CurrentServerTime { get; set; }

    [JsonPropertyName("lastConduitTime")]
    public long LastConduitTime { get; set; }

    [JsonPropertyName("lastConduitUpdateServerTime")]
    public long LastConduitUpdateServerTime { get; set; }

    [JsonPropertyName("lastMedicalDeviceDataUpdateServerTime")]
    public long LastMedicalDeviceDataUpdateServerTime { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("conduitSerialNumber")]
    public string ConduitSerialNumber { get; set; } = string.Empty;

    [JsonPropertyName("conduitBatteryLevel")]
    public int ConduitBatteryLevel { get; set; }

    [JsonPropertyName("conduitBatteryStatus")]
    public string ConduitBatteryStatus { get; set; } = string.Empty;

    [JsonPropertyName("conduitInRange")]
    public bool ConduitInRange { get; set; }

    [JsonPropertyName("conduitMedicalDeviceInRange")]
    public bool ConduitMedicalDeviceInRange { get; set; }

    [JsonPropertyName("conduitSensorInRange")]
    public bool ConduitSensorInRange { get; set; }

    [JsonPropertyName("medicalDeviceFamily")]
    public string MedicalDeviceFamily { get; set; } = string.Empty;

    [JsonPropertyName("sensorState")]
    public string SensorState { get; set; } = string.Empty;

    [JsonPropertyName("medicalDeviceSerialNumber")]
    public string MedicalDeviceSerialNumber { get; set; } = string.Empty;

    [JsonPropertyName("medicalDeviceTime")]
    public long MedicalDeviceTime { get; set; }

    [JsonPropertyName("sMedicalDeviceTime")]
    public DateTimeOffset SMedicalDeviceTime { get; set; }

    [JsonPropertyName("reservoirLevelPercent")]
    public int ReservoirLevelPercent { get; set; }

    [JsonPropertyName("reservoirAmount")]
    public double ReservoirAmount { get; set; }

    [JsonPropertyName("medicalDeviceBatteryLevelPercent")]
    public int MedicalDeviceBatteryLevelPercent { get; set; }

    [JsonPropertyName("sensorDurationHours")]
    public int SensorDurationHours { get; set; }

    [JsonPropertyName("timeToNextCalibHours")]
    public int TimeToNextCalibrationHours { get; set; }

    [JsonPropertyName("calibStatus")]
    public string CalibrationStatus { get; set; } = string.Empty;

    [JsonPropertyName("bgUnits")]
    public string BloodglucoseUnits { get; set; } = string.Empty;

    [JsonPropertyName("timeFormat")]
    public string TimeFormat { get; set; } = string.Empty;

    [JsonPropertyName("lastSensorTime")]
    public long LastSensorTime { get; set; }

    [JsonPropertyName("sLastSensorTime")]
    public DateTimeOffset SLastSensorTime { get; set; }

    [JsonPropertyName("medicalDeviceSuspended")]
    public bool MedicalDeviceSuspended { get; set; }

    [JsonPropertyName("lastSGTrend")]
    public string LastSensorGlucoseTrend { get; set; } = string.Empty;

    [JsonPropertyName("lastSG")]
    public SensorGlucose LastSensorGlucose { get; set; }

    [JsonPropertyName("lastAlarm")]
    public LastAlarm LastAlarm { get; set; } = new();

    [JsonPropertyName("activeInsulin")]
    public ActiveInsulin ActiveInsulin { get; set; }

    [JsonPropertyName("sgs")]
    public List<SensorGlucose> SensorGlucoses { get; set; }

    [JsonPropertyName("limits")]
    public List<Limit> Limits { get; set; }

    [JsonPropertyName("markers")]
    public List<Marker> Markers { get; set; }

    [JsonPropertyName("sgBelowLimit")]
    public MassConcentration SensorGlucoseBelowLimit { get; set; }

    [JsonPropertyName("cgmInfo")]
    public object CgmInfo { get; set; }

    [JsonPropertyName("approvedForTreatment")]
    public bool ApprovedForTreatment { get; set; }
}
