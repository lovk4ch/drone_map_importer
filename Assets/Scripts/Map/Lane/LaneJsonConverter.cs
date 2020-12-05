public class LaneJsonConverter : JsonConverter
{
    public override string Convert(string obj)
    {
        obj = PropertyToJsonArray(obj, "line_segment");
        return base.Convert(obj);
    }
}