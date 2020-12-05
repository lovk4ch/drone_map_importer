using UnityEngine;

public abstract class MapObject : MonoBehaviour
{
    protected JsonConverter converter;
    public virtual void Initialize(string obj) { }
}