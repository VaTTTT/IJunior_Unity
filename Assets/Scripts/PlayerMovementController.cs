using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private Vector2 _moveVector;
    private Vector3 _rotation;
    private bool _isGrounded;
    private SpriteRenderer _spriteRenderer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _isGrounded = true;
    }

    private void Awake()
    {
        _isGrounded = false;
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rotation = transform.eulerAngles;
    }

    private void Update()
    {
        Walk();
        Jump();
    }

    private void Walk()
    {
        Turn();
        _moveVector.x = Input.GetAxis("Horizontal");
        _rigidBody.velocity = new Vector2(_moveVector.x * _speed, _rigidBody.velocity.y);
        _animator.SetFloat("moveSpeed", Mathf.Abs(_moveVector.x));
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
        }
    }

    private void Turn()
    { 
        if (_moveVector.x < 0) 
        {
            _rotation.y = 180f;
            transform.rotation = Quaternion.Euler(_rotation);
        }
        
        if (_moveVector.x > 0) 
        {
            _rotation.y = 0f;
            transform.rotation = Quaternion.Euler(_rotation);
        }
    }
}
