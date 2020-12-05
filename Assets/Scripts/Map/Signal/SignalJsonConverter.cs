public class SignalJsonConverter : JsonConverter
{
    public override string Convert(string obj)
    {
        obj = PropertyToJsonArray(obj, "line_segment");
        obj = PropertyToJsonArray(obj, "boundary");
        obj = UniformJsonArray(obj, "subsignal");
        return base.Convert(obj);
    }
}