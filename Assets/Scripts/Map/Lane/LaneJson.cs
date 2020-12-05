using Newtonsoft.Json;

[System.Serializable]
public class LaneJson
{
    [JsonProperty("id")]
    public Id id;
    [JsonProperty("central_curve")]
    public Curve centralCurve;
    [JsonProperty("left_boundary")]
    public Boundary leftBoundary;
    [JsonProperty("right_boundary")]
    public Boundary rightBoundary;
    [JsonProperty("length")]
    public float length;
    [JsonProperty("speed_limit")]
    public int speedLimit;
    [JsonProperty("overlap_id")]
    public Id overlapId;
    [JsonProperty("predecessor_id")]
    public Id predecessorId;
    [JsonProperty("successor_id")]
    public Id successorId;
    [JsonProperty("type")]
    public string type;
    [JsonProperty("turn")]
    public string turn;
    [JsonProperty("direction")]
    public string direction;
}