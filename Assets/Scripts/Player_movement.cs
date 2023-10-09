using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BoxCollider2D _boxColl;
    private SpriteRenderer _sprite;
    private Animator _animate;
    
    [SerializeField] private LayerMask JumpGround;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    
    private float _xDir;
    private float _yDir;

    public ProjectileBehavior ProjectilePrefab;
    public Transform LaunchOffset;
    
    private enum movementState {idle, running, jumping, falling}
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxColl = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _animate = GetComponent<Animator>();
    }

    void Update()
    {
        _xDir = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_xDir * moveSpeed, _rb.velocity.y);

        //Jump Code
        if (Input.GetButtonDown("Jump") && onGround())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }
        //Shooting code
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Vector3 projectileDirection = _sprite.flipX ? Vector3.left : Vector3.right;
            ProjectileBehavior newProjectile = Instantiate(ProjectilePrefab, LaunchOffset.position, Quaternion.identity);
            newProjectile.SetDirection(projectileDirection);
        }
        
        charAnimator();
    }

    void charAnimator()
    {
        _yDir = _rb.velocity.y;
        movementState state;

        switch (_xDir)
        {
            case > 0f:
                state = movementState.running;
                _sprite.flipX = false;
                LaunchOffset.localRotation = Quaternion.Euler(0, 0, 0); // Reset rotation of LaunchOffset
                LaunchOffset.localPosition = new Vector3(0.7f, 0, 0); //Reset location of LaunchOffset
                break;
            case < 0f:
                state = movementState.running;
                _sprite.flipX = true;
                LaunchOffset.localRotation = Quaternion.Euler(0, 180, 0); // Rotate LaunchOffset by 180 degrees
                LaunchOffset.localPosition = new Vector3(-0.7f, 0, 0); //Reset location of LaunchOffset
                break;
            default:
                state = movementState.idle;
                break;
        }

        switch (_yDir)
        {
            case > .1f:
                state = movementState.jumping;
                break;
            case < -.1f:
                state = movementState.falling;
                break;
        }

        _animate.SetInteger("AnimationState", (int)state);
    }

    bool onGround()
    {
        return Physics2D.BoxCast(_boxColl.bounds.center, _boxColl.bounds.size, 0f, Vector2.down, .1f, JumpGround);
    }
}
