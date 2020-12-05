using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Subsignal
{
    [JsonProperty("id")]
    public Id id;
    [JsonProperty("type")]
    public string type;
    [JsonProperty("location")]
    public Vector3 location;
}

[System.Serializable]
public class StopLine
{
    [JsonProperty("segment")]
    public Segment segment;
}

[System.Serializable]
public class SignalJson
{
    [JsonProperty("id")]
    public Id id;
    [JsonProperty("boundary")]
    public List<Vector3> boundary;
    [JsonProperty("subsignal")]
    public List<Subsignal> points;
    [JsonProperty("overlap_id")]
    public Id overlapId;
    [JsonProperty("type")]
    public string type;
    [JsonProperty("stop_line")]
    public StopLine stopLine;
}