using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    private float _mouseX;
    [SerializeField] private float sens = 1f;
    // Update is called once per frame
    protected virtual void Update()
    {
        _mouseX += Input.GetAxis("Mouse X") *sens;
        
        transform.localRotation = Quaternion.Euler(transform.localRotation.x,_mouseX,transform.localRotation.z);
    }
}
