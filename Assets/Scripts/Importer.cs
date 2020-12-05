using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

[ExecuteInEditMode]
public class Importer : MonoBehaviour
{
    private readonly Vector3 correction = new Vector3(6180800, 0, 358600);
    private readonly List<Segment> segments = new List<Segment>();

    private GameObject map;
    private GameObject lanes;
    private GameObject signals;

    // axis correction from map to unity
    private Vector3 RotateGizmos(Vector3 vector)
    {
        return new Vector3(vector.y, vector.z, vector.x) - correction;
    }

    private void Start()
    {
        map = new GameObject("Map");

        lanes = new GameObject("TrafficLanes");
        lanes.transform.SetParent(map.transform);

        signals = new GameObject("TrafficSignals");
        signals.transform.SetParent(map.transform);

        string data = File.ReadAllText(Application.dataPath + "/Sources/sim_map.txt");
        Split(data);
    }

    private void OnDrawGizmos()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Gizmos.color = Color.cyan;
            for (int j = 1; j < segments[i].lineSegment.Length; j++)
            {
                Gizmos.DrawLine(
                    RotateGizmos(segments[i].lineSegment[j - 1]),
                    RotateGizmos(segments[i].lineSegment[j]));
            }

            Gizmos.DrawWireSphere(
                RotateGizmos(segments[i].startPosition), 1);
        }
    }

    private void AddToMap(string obj, string type)
    {
        switch (type)
        {
            case "lane":
                GameObject mapLaneSection = new GameObject("MapLaneSection");
                Lane lane = mapLaneSection.AddComponent<Lane>();
                lane.Initialize(obj);
                lane.transform.parent = lanes.transform;
                segments.Add(lane.segment);
                break;
            case "signal":
                GameObject mapLaneSignal = new GameObject("MapSignalSection");
                Signal signal = mapLaneSignal.AddComponent<Signal>();
                signal.transform.parent = signals.transform;
                signal.Initialize(obj);
                break;
            case "overlap":
                break;
            case "road":
                break;
        }
    }

    private void Split(string json)
    {
        string pattern = @"(lane|signal|overlap|road) {[\S\s]*?\n(lane|signal|overlap|road) {";
        string match = Regex.Match(json, pattern).Value;
        string prefix = "";
        int index = match.LastIndexOf("\n");

        if (index != -1)
        {
            match = match.Substring(0, index);
            json = json.Substring(index + 1);
            int split = match.IndexOf(" {");
            if (split != -1)
            {
                prefix = match.Substring(0, split);
                match = match.Substring(split + 1, match.Length - split - 1);
            }
        }
        else
        {
            int split = json.IndexOf(" {");
            if (split != -1)
            {
                prefix = json.Substring(0, split);
                match = json;
                json = "";
            }
        }
        AddToMap(match, prefix);

        if (json != string.Empty)
        {
            Split(json);
        }
    }
}