using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventSender : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))return;
        unityEvent.Invoke();
    }

    [SerializeField] private UnityEvent unityEvent;
}
