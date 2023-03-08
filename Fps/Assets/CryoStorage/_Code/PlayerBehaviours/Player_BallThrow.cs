using System;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player_BallThrow : MonoBehaviour
{
    [SerializeField]private Image indicator;
    [SerializeField] private GameObject ballObject;
    [SerializeField] private float launchForce;
    [SerializeField] private Camera viewCam;
    
    private bool _hasBall;
    private ColorBall _colorBall;
    private readonly Color _blank = new Color(0f,0f,0f,0f);
    private readonly Color _red = new Color(200f,46f,53f,255f);
    private readonly Color _green = new Color(58f,200f,46f,255f);

    private StarterAssetsInputs _input;
    // Start is called before the first frame update
    void Start()
    {
        Prepare();
        indicator.color = _blank;
    }

    private void Update()
    {
        UpdateBallStatus();
        ThrowBall();
    }

    private void UpdateBallStatus()
    {
        if (!_hasBall)
        {
            indicator.color = _blank;
        }
        if (_colorBall.color == _red)
        {
            indicator.color = _red;
        } 
        if (_colorBall.color == _green)
        {
            indicator.color = _green;
        }
    }

    public void ThrowBall()
    {
        if (!_input.shoot) return;
        if (!_hasBall)return;
        _colorBall.Launch(transform.position,viewCam.transform.forward, launchForce);
        _hasBall = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_hasBall) return;
        if (!other.CompareTag("BallPickUp")) return;
        Color pickupColor = other.GetComponent<BallPickUp>().color;
        _colorBall.SetColor(pickupColor); 
        _hasBall = true;
    }

    private void Prepare()
    {
        _colorBall = ballObject.GetComponent<ColorBall>();
        _input = GetComponent<StarterAssetsInputs>();
    }
    
    
}
