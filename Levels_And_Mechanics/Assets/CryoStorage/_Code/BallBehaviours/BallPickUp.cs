using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickUp : MonoBehaviour
{

    [SerializeField] private float respawnTime;
    [SerializeField]private Color _color;
    private Light _light;
    private MeshRenderer _rend;
    private Collider _collider;
    
    // Start is called before the first frame update
    void Start()
    {
        Prepare();
        _light.color = _color;
        _rend.material.color = _color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))return ;
        CorRespawn();
    }

    IEnumerator CorRespawn()
    {
        _rend.enabled = false;
        _collider.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        _rend.enabled = true;
        _collider.enabled = true;
    }

    void Prepare()
    {
        _light = GetComponentInChildren<Light>();
        _rend = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }
}
