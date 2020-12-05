using Newtonsoft.Json;

public class Signal : MapObject
{
    public SignalJson signal;

    public override void Initialize(string obj)
    {
        converter = new SignalJsonConverter();
        obj = converter.Convert(obj);
        this.signal = JsonConvert.DeserializeObject<SignalJson>(obj);
    }
}