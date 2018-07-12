using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    private Rigidbody2D _rigid;
    private PlayerAnimation _animation;
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private float _jumpForce = 5.0f;

    [SerializeField]
    private LayerMask _groundLayer;

    [SerializeField]
    private float _speed = 2.5f;

	// Use this for initialization
	void Start () {
        _rigid = GetComponent<Rigidbody2D>();
        _animation = GetComponent<PlayerAnimation>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        Move();
        Jump();
    }

    void Move() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            _spriteRenderer.flipX = true;
        }

        _rigid.velocity = new Vector2(horizontalInput * _speed, _rigid.velocity.y);
        _animation.Move(horizontalInput);
    }

    void Jump() {
        bool grounded = IsGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpForce);
        }
    }

    bool IsGrounded() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, _groundLayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
       
        if (hitInfo.collider != null) {
            return true;
        }
        else {
            return false;
        }
    }
}
