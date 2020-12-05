using Newtonsoft.Json;
using UnityEngine;

[System.Serializable]
public class Id
{
    public string id;
}

[System.Serializable]
public class Curve
{
    [JsonProperty("segment")]
    public Segment segment;
}

[System.Serializable]
public class BoundaryType
{
    [JsonProperty("types")]
    public string types;
}

[System.Serializable]
public class Boundary
{
    [JsonProperty("curve")]
    public Curve curve;
    [JsonProperty("virtual")]
    public bool _virtual;
}

[System.Serializable]
public class Segment
{
    [JsonProperty("line_segment")]
    public Vector3[] lineSegment;
    [JsonProperty("s")]
    public int s;
    [JsonProperty("start_position")]
    public Vector3 startPosition;
    [JsonProperty("heading")]
    public int heading;
    [JsonProperty("length")]
    public float length;
}