using Newtonsoft.Json;

public class Lane : MapObject
{
    public LaneJson lane;
    public Segment segment => lane.centralCurve.segment;

    public override void Initialize(string obj)
    {
        converter = new LaneJsonConverter();
        obj = converter.Convert(obj);
        this.lane = JsonConvert.DeserializeObject<LaneJson>(obj);
    }
}