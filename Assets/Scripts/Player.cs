using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D _rb;
    private bool _facingRight;
    private Animator _animator;
    private bool _isGrounded;
    private bool _isJumping;
    private InventoryManager _inventoryManager;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform[] _groundPoints;
    [SerializeField]
    private float _groundRadius;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private LayerMask _whatIsGround;
    [SerializeField]
    private bool _airControl;



    void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _inventoryManager = GetComponent<InventoryManager>();
        _facingRight = true;
	}
	
    void Update()
    {
        HandleInput();
    }

	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");

        _isGrounded = IsGrounded();
        HandleMovement(horizontal);
        Flip(horizontal);
        HandleLayers();
        ResetValues();
	}

    private void HandleMovement(float horizontal)
    {
        if (_rb.velocity.y < 0)
        {
            _animator.SetBool("Land", true);
        }
        if (_isGrounded || _airControl)
            _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y);
        if (_isGrounded && _isJumping)
        {
            _isGrounded = false;
            _rb.AddForce(new Vector2(0, _jumpForce));
            _animator.SetTrigger("Jump");
        }
        _animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
        }
    }

    private void Flip(float horizontal)
    {
        if ((horizontal > 0 && !_facingRight) || (horizontal < 0 && _facingRight))
        {
            _facingRight = !_facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private bool IsGrounded()
    {
        if (_rb.velocity.y <= 0)
        {
            foreach (Transform point in _groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, _groundRadius, _whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        _animator.ResetTrigger("Jump");
                        _animator.SetBool("Land", false);
                        return (true);
                    }
                }
            }
        }
        return (false);
    }

    private void ResetValues()
    {
        _isJumping = false;
    }

    private void HandleLayers()
    {
        if (!_isGrounded)
        {
            _animator.SetLayerWeight(1, 1);
        } else
        {
            _animator.SetLayerWeight(1, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("PickUp"))
        {
            PickUp item = hit.GetComponent<PickUp>();
            _inventoryManager.Add(item);
            Destroy(hit.gameObject);
        }
        else if (hit.CompareTag("Chest"))
        {
            if (_inventoryManager.RemoveOne(PickUp.Type.Key))
            {
                Chest item = hit.GetComponent<Chest>();
                item.OpenChest();
            }
        }
    }
}
