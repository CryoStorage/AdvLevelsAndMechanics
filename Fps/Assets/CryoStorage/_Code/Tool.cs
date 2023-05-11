using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{

    [SerializeField] private float rotSpeed = 100f;
    private float levitSpeed = 0.001f;
    private float sine;
    
    // Update is called once per frame
    void Update()
    {
        sine = Mathf.Sin(Time.time);
        Levitate();
    }

    private void Levitate()
    {
        transform.Rotate(0,Time.deltaTime *rotSpeed,0);
        transform.position += new Vector3(0, sine * (levitSpeed * Time.deltaTime), 0);
    }


}
