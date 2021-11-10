using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    private float Left_Right;
    public float jumpForce;

    

    private void FixedUpdate()
    {
        // Player jumps
        if ( Input.GetKey("w"))
        {
            
            body.velocity = Vector2.up * jumpForce * 100 * Time.deltaTime;
        }

        // player moves left to right
        body.velocity = new Vector2(Left_Right * speed *100 * Time.deltaTime, body.velocity.y);
      
    }

    private void Update()
    {
        Left_Right = Input.GetAxisRaw("Horizontal");   
    }
}
