using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D body;    // player
    public float speed;         // player speed 
    public float playerRun;
    private float Left_Right;
    public float jumpForce;     // how high

    // Power up
    private float upgradeTimer;
    public float upgradeSpeed;
    public bool upgraded = false;
    public int upgrade_Timer_stop;

    // double jump
    private int jumpCt = 0;
    public int jumpMax;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool dblJumpEnables = false;







    private void FixedUpdate()
    {
        Left_Right = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        //Debug.Log(isGrounded);

        if (!upgraded)
        {
            // player moves left to right
            if(Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("shift pressed");
                body.velocity = new Vector2(Left_Right * playerRun * 100 * Time.deltaTime, body.velocity.y);

            }
            else
            {
                body.velocity = new Vector2(Left_Right * speed * 100 * Time.deltaTime, body.velocity.y);
            }
            

        }
        else
        {
            upgradeTimer += Time.deltaTime;

            body.velocity = new Vector2(Left_Right * upgradeSpeed * 100 * Time.deltaTime, body.velocity.y);
            if (upgradeTimer >= upgrade_Timer_stop)
            {
                // Debug.Log("downgrade");
                upgraded = false;
                upgradeTimer = 0;
            }
            //Debug.Log(upgradeTimer.ToString());


        }

    }

    private void Update()
    {
        if (isGrounded)
        {
            //Debug.Log(jumpCt.ToString());
            jumpCt = jumpMax;
        }

        // Player jumps
        /* To adjust the number of of jumps
         * change the jumpMax variable 
         * 1 = 1 jump in air
         * 2 = 2 jumps in air etc.
         */
        if (Input.GetKeyDown(KeyCode.W))
        {

            if (isGrounded)
            {
                Debug.Log("jump");
                
                body.velocity = Vector2.up * jumpForce;
                dblJumpEnables = true;
                jumpCt--;
                
            }
            else if (dblJumpEnables)
            {
                if (jumpCt > 0)
                {
                    body.velocity = Vector2.up * jumpForce;
                    jumpCt--;
                    Debug.Log(jumpCt);
                }
                else
                    dblJumpEnables = false;
            }

        }

    }

    public void MoveFaster()
    {
        upgraded = true;
        upgradeTimer = 0;
    }


}
