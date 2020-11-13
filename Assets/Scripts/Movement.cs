using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = 10f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private Transform groundCheck;

    private CharacterController _controller;
    private Test3DStuff _controls;
    private int _groundCheckLayerMask;
    private bool _isGrounded;
    private Transform _transform;
    private Vector3 _velocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _controls = new Test3DStuff();
        _transform = transform;
        _groundCheckLayerMask = ~LayerMask.GetMask("Player");
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundCheck.localScale.x, _groundCheckLayerMask);
        Move(_controls.Player.Move.ReadValue<Vector2>());
        Fall();
    }

    private void OnEnable() { _controls.Player.Enable(); }

    private void OnDrawGizmos() { Gizmos.DrawWireSphere(groundCheck.position, groundCheck.localScale.x); }

    private void Move(Vector2 direction)
    {
        var fixedDir = _transform.right * direction.x + _transform.forward * direction.y;
        _controller.Move(fixedDir * (speed * Time.deltaTime));
    }

    private void Fall()
    {
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity = Vector3.down; // a little leeway so it really touches the ground
            return;
        }

        _velocity.y -= gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (_isGrounded) _velocity.y = Mathf.Sqrt(jumpHeight * 2 * gravity);
    }
}