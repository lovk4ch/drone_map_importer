using System.Text.RegularExpressions;

public abstract class JsonConverter
{
    protected string PropertyToJsonArray(string json, string property)
    {
        string pattern = property + @" {[\S\s]*?}\r\n[\s]*}";
        Regex regex = new Regex(pattern);
        Match match = Regex.Match(json, pattern);
        if (match.Success)
        {
            json = regex.Replace(json, GetJsonArray(match.Value, property), 1);
            return PropertyToJsonArray(json, property);
        }
        return json;
    }

    protected string GetJsonArray(string array, string property)
    {
        array = array
            .Replace(property + " {\r\n", property + " [\r\n")
            .Replace("point {\r\n", "{\r\n");
        array = array.Remove(array.Length - 1);
        array = array.Insert(array.Length, "]");
        return array;
    }

    protected string UniformJsonArray(string json, string property)
    {
        string _jsonArray = "\r\n" + property + " [";

        string pattern = property + @" {[\S\s]*?}\r\n[\s]*}";
        Regex regex = new Regex(pattern);
        Match match;
        do
        {
            match = Regex.Match(json, pattern);
            if (match.Value != "")
            {
                _jsonArray += match.Value.Replace(property + " {", "\r\n{");
                json = regex.Replace(json, string.Empty, 1);
            }
        }
        while (match.Success);
        _jsonArray += "\r\n]\r\n";

        pattern = @"\r\n[\s]*\r\n";
        regex = new Regex(pattern);
        return regex.Replace(json, _jsonArray, 1);
    }

    protected string SetProperties(string obj)
    {
        string pattern = @": [A-Z_0-9]+,";
        var regex = new Regex(pattern);
        obj = Regex.Replace(obj, pattern, new MatchEvaluator(SetProperty));
        return obj;
    }

    protected string SetProperty(Match match)
    {
        return match.Value.Substring(0, 2) + "\"" + match.Value.Substring(2, match.Value.Length - 3) + "\",";
    }

    public virtual string Convert(string obj)
    {
        obj = obj
            .Replace("\r\n", ",\r\n")
            .Replace("{,", "{")
            .Replace(" {", ": {")
            .Replace(" [,", ": [")
            .Replace(" : {", "  {");
        obj = SetProperties(obj);
        return obj;
    }
}