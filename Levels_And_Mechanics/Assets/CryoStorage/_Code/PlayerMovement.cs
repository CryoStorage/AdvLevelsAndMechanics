using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float gravityStrength = 2f;
    private CharacterController _charController;
    private Vector3 _pos;
    private Vector3 _dir;
    // Start is called before the first frame update
    void Start()
    {
        Prepare();
        _pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = _pos;
        _pos += _dir * Time.fixedDeltaTime;
        // _pos -= ApplyGravity(gravityStrength) * Time.fixedDeltaTime;
    }

    public void InputForward()
    {
        _dir += transform.forward * moveSpeed;
    }

    public void InputLeft()
    {
        _dir += new Vector3(-moveSpeed, 0, 0);
    }

    public void InputBack()
    {
        _dir += new Vector3(0, 0, -moveSpeed);
    }

    public void InputRight()
    {
        _dir += new Vector3(moveSpeed, 0, 0);
    }

    public void InputJump()
    {
        
    }

    private Vector3 ApplyGravity(float g)
    {
        Vector3 gForce = new Vector3(0, g, 0);
        return gForce;
    }
    
    private void Prepare()
    {
        if (_charController != null) return;
        _charController = GetComponent<CharacterController>();

    }
}
