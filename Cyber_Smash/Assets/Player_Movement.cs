using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    private float Left_Right;
    public float jumpForce;
    public float upgradeTimer;
    public float upgradeSpeed;
    public bool upgraded = false;

  



    private void FixedUpdate()
    {
        // Player jumps
        if (Input.GetKey("w"))
        {
            Debug.Log("jump");
            body.velocity = Vector2.up * jumpForce * 100 * Time.deltaTime;
        }

        if (!upgraded)
        {
            // player moves left to right
            body.velocity = new Vector2(Left_Right * speed * 100 * Time.deltaTime, body.velocity.y);

        }
        else
        {
            upgradeTimer = Time.deltaTime;
            if (upgradeTimer >= 5)
            {
                Debug.Log("downgrade");
                upgraded = false;
                upgradeTimer = 0;
            }
            Debug.Log("upgraded");
            body.velocity = new Vector2(Left_Right * upgradeSpeed * 100 * Time.deltaTime, body.velocity.y);

        }


    }

    private void Update()
    {
        Left_Right = Input.GetAxisRaw("Horizontal");
    }

    public void MoveFaster()
    {
        upgraded = true;

    }
}
