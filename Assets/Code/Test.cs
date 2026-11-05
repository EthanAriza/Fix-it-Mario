using UnityEngine;


public class PlayerScript : MonoBehaviour
{
   
    public SpriteRenderer SR;
    public Rigidbody2D RB;
    public float speed = 3;
    public Transform playerLocation;
    public enum Modes
    {
        Roam = 0,
        Chase = 1,
    }
    
    public Modes Mode = Modes.Roam;
    public float chaseRange = 5;
    public float roamChangeDirTime = 2;

    private float roamTimer;
    private int roamDirection = 1;
    
    
    
    
    
    
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        RB =  GetComponent<Rigidbody2D>();
        Mode = Modes.Roam;
        roamTimer = roamChangeDirTime;
        SetMode(Modes.Roam);
      
        
    }

    void Update()
    {
        

        if (playerLocation == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, playerLocation.position);

        if (distanceToPlayer <= chaseRange)
            SetMode(Modes.Chase);
        else
            SetMode(Modes.Roam);

        if (Mode == Modes.Roam)
        {
            Roam();
        }
        else if (Mode == Modes.Chase)
        {
            Chase();
        }
        
    }

    void Roam()
    {
        roamTimer -= Time.deltaTime;
        if (roamTimer <= 0f)
        {
            roamDirection = Random.Range(0, 2) == 0 ? -1 : 1;
            roamTimer = roamChangeDirTime;
        }

        RB.linearVelocity = new Vector2(roamDirection * speed * 0.5f, RB.linearVelocity.y);
    }

    void Chase()
    {
        Vector2 direction = (playerLocation.position - transform.position).normalized;
        RB.linearVelocity = new Vector2(direction.x * speed, RB.linearVelocity.y);
    }

    public void SetMode(Modes Act)
    {
        Mode = Act;

        if (Mode == Modes.Roam)
        {
            SR.color = Color.red;
        }

        if (Mode == Modes.Chase)
        {
            SR.color = Color.yellow;
        }




    }
    
    
    
}