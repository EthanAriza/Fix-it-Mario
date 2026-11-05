using UnityEngine;
using UnityEngine.SceneManagement;


public class Playermain : MonoBehaviour
{
    public enum PlayerState
    {
        Idle = 0,
        Walking = 1,
        Hurt = 2,
        Jumping = 3,
        Dead = 4
    }
    public GameObject Goal;
    public int Fixed_items;
    
    public PlayerState state = PlayerState.Idle;
    public bool canfix;


    private float speed = 10;
    private float jump = 10;
    public float gravity = 3;
    public bool isGrounded;

    private bool facingleft = true;
    private Rigidbody2D RB;
    private SpriteRenderer SR;
    public bool death = false;
    private float Delay = 2; // reusable delay time for invokes and such (CAREFUL WHEN CHANGING IT AFFECTS A FEW THINGS)

    public Sprite[] playerSprites;
    
    public AudioSource AS;

    void Start()
    {
        Goal.SetActive(false);
        Fixed_items = 0;
        SR= GetComponent<SpriteRenderer>();
        RB= GetComponent<Rigidbody2D>();
        AS= GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (Fixed_items >= 3) // The player can exit when they do the bare minimum of three repairs
        {
            Goal.SetActive(true);
        }
        
        if (transform.position.y < -4) //If the player falls they die (KEEP THE LEVELS ABOVE -4y)
        {
            Reset();
        }
        
        if (Input.GetKeyDown(KeyCode.R)) //reset button
        {
           Invoke(nameof(Reset), Delay);
           Reset();
           
        }
       
        if (death)  return;
        
        Movement();
        SR.flipX = facingleft;
        SetState(state);
    }

    public void SetState(PlayerState PlayerSet)
    {
        state = PlayerSet;

        if (PlayerSet == PlayerState.Idle)
        {
            SR.sprite = playerSprites[0];
            SR.color = Color.white;
        }

        if (PlayerSet == PlayerState.Walking)
        {
            SR.sprite = playerSprites[2];
            SR.color = Color.white;
        }

        if (PlayerSet == PlayerState.Hurt)
        {
            SR.color = Color.red;
        }

        if (PlayerSet == PlayerState.Jumping)
        {
            SR.sprite = playerSprites[1];
            SR.color = Color.white;
        }

        if (PlayerSet == PlayerState.Dead)
        {
            SR.color = Color.red;
        }
    }

    public void Movement()
    {
        
        Vector2 vel = RB.linearVelocity;
        
        if (Input.GetKey(KeyCode.D))
        { 
            vel.x = speed;
            facingleft = false;
            state = PlayerState.Walking;
        }
        else if (Input.GetKey(KeyCode.A))
        { 
            vel.x = -speed;
            facingleft = true;
            state = PlayerState.Walking;
        }
        else if (!isGrounded)
        {
            state = PlayerState.Jumping;
        }
        else
        { 
            vel.x = 0;
            state = PlayerState.Idle;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            vel.y = jump;
            state = PlayerState.Jumping;
        }
        RB.linearVelocity = vel;
    }

    public void NoMovement() //halts
    {
        death  = true;
        RB.linearVelocity = Vector2.zero;
        state = PlayerState.Dead;
    }
    public bool CanJump()
    {
        return isGrounded;
    }
    private void OnCollisionEnter2D(Collision2D other) //killboxes basically whenever you die to one u will turn red, stop ur movement via the dead state and then reset the level
    {  
        isGrounded = true;
        if (other.gameObject.CompareTag("Evil"))
        {
            SR.color = Color.red;
            NoMovement();
            Invoke("Reset", Delay);  
        }
        if (other.gameObject.CompareTag("Hazard"))
        {
            SR.color = Color.red;
            NoMovement();
            Invoke("Reset", Delay);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }
    
    void Reset() //reset the scene the player is in
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D other) //for the win con
    {
        if (other.gameObject.CompareTag("WinTile"))
        {
            
            SceneManager.LoadScene("WinScreen");
        }
    }
}
