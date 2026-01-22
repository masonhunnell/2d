using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    public LayerMask groundMask;
    public float groundCastLength = 1f;
    public float jumpImpulseForce = 2f;
    private float horizontalMovement;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float jumpForce = 0f;
    private const float EPSILON = 0.0001f;
    private SpriteRenderer SpriteRenderer;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }


    void Update()
    {
        var groundRayCast = RaycastUtilities.CastRay(
            new RaycastUtilities.RayData<string>("groundCast", transform.position, Vector2.down,
                                                groundCastLength, groundMask));
        isGrounded = groundRayCast;
     if(Mathf.Abs(horizontalMovement) > EPSILON){
        SpriteRenderer.flipX = horizontalMovement < 0;
     }

    }

    void FixedUpdate(){
        rb.linearVelocityX = speed * horizontalMovement;

        if(jumpForce > 0){
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpForce = 0f;
        }
    }
    public void Onjump(InputAction.CallbackContext Context){
      if(Context.ReadValueAsButton() && isGrounded){
      
        jumpForce = jumpImpulseForce;  
      }
    }

     public void OnMove(InputAction.CallbackContext Context){
        var movementVector = Context.ReadValue<Vector2>();
        horizontalMovement = movementVector.x;
    }
}
