using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColoredObject : MonoBehaviour
{
    public Color color;
    
    protected MeshRenderer _rend;
    
    protected virtual void Start()
    {
        Prepare();
        _rend.material.color = color;
    }
    
    protected virtual void Prepare()
    {
        _rend = GetComponent<MeshRenderer>();
    }
}
