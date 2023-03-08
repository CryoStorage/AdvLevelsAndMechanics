using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickUp : ColoredObject
{
    [SerializeField] protected float respawnTime;
    private Collider _collider;
    private Light _light;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))return ;
        StartCoroutine(CorRespawn());
    }

    protected override void Start()
    {
        base.Start();
        base.Prepare();
        _light.color = color;
    }

    IEnumerator CorRespawn()
    {
        _rend.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        _rend.enabled = true;
        _collider.enabled = true;
    }
    protected override void Prepare()
    {
        _light = GetComponentInChildren<Light>();
        _collider = GetComponent<Collider>();
        base.Prepare();
    }

}
