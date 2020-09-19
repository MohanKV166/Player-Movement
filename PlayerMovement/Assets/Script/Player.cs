
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
   
    [Header("Horizontal Movement")]
    public float moveSpeed = 4f;
    private bool facingRight = true;

    [Header("Components")]
    public Rigidbody2D rb;
   // public  Animator animator;
     

    public float jumpForce = 15f;
    int extraJump;
    public int extraJumpValues;
    public AudioSource jumpSound;
    public AudioSource powerUpSound;
    float timer;
    float timey;

  
   


    private void Awake()
    {
        extraJump = extraJumpValues;
       
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void FixedUpdate()
    {
        //float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float horizontalInput = Input.GetAxis("Horizontal");
        bool setRun = horizontalInput > 0 || horizontalInput < 0;
       // animator.SetBool("isRunning", setRun);
        if ((horizontalInput > 0 && !facingRight) || (horizontalInput < 0 && facingRight))
        {
            Flip();
        }
        rb.AddForce(new Vector2(horizontalInput * moveSpeed, 0));
        
    /*    if(GameControllScript.instance.health == 2)
        {
            timer++;
            if (timer < 5)
            {
                animator.SetTrigger("Hurt");
            }
        }
        if(GameControllScript.instance.health == 1)
        {
            timey++;
            if(timey<5)
            {
                animator.SetTrigger("Hurt");
            }
        }
        if(GameControllScript.instance.health == 0)
        {
            animator.SetTrigger("Death");
        }*/
      
        
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
    }
   
   public void Jump()
    {
        if(GroundChecker.isGrounded==true)
         {
             extraJump = extraJumpValues;
         }
         if( extraJump>0)
         {
             rb.velocity = Vector2.up * jumpForce;
             extraJump--;
             jumpSound.Play();
           //  animator.SetTrigger("Jump");

         }
         else if( extraJump==0&&GroundChecker.isGrounded==true)
         {
             rb.velocity = Vector2.up * jumpForce;
             jumpSound.Play();
            // animator.SetTrigger("Jump");

         }
         
       
    }
   
    
  


}
