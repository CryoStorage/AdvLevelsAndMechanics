using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    private float _mouseX;
    [SerializeField] private float sens = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        _mouseX += Input.GetAxis("Mouse X") *sens;
        // _mouseY += Input.GetAxis("Mouse Y") *sens;
        
        transform.localRotation = Quaternion.Euler(transform.localRotation.x,_mouseX,transform.localRotation.z);
    }
}
