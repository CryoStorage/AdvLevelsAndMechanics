using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ColorBall : ColoredObject
{
    [SerializeField] private float timeout = 3f;
    
    private Rigidbody _rb;
    private Collider _collider;

    private Vector3 launchOffset = new Vector3(0, 1f, 0);
    // Start is called before the first frame update
    protected override void Start()
    {
        Prepare();
        base.Start();
        Deactivate();
    }

    public void Launch(Vector3 origin, Vector3 launchDir, float launchForce)
    {
        transform.position = origin + launchOffset;
        Activate();
        _rb.AddForce(launchDir*launchForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("ColorBlock"))
        {
            BeginTimeOut(); 
            return;
        }
        ColorBlock colorBlock = collision.gameObject.GetComponent<ColorBlock>();
        if (colorBlock.color != color) return;
        colorBlock.MoveToTarget();
        Deactivate();
    }

    void BeginTimeOut()
    {
        Invoke(nameof(Deactivate),timeout);
    }

    public void SetColor(Color col)
    {
        color = col;
        _rend.material.color = color;
    }
 
    private void Activate()
    {
        _rend.enabled = true;
        _collider.enabled = true;
        _rb.isKinematic = false;
    }

    public void Deactivate()
    {
        _rend.enabled = false;
        _collider.enabled = false;
        _rb.velocity = Vector3.zero;
        _rb.isKinematic = true;
    }

    protected override void Prepare()
    {
        base.Prepare();
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

    }
}
