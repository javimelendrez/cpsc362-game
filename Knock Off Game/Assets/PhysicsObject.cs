using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsObject : MonoBehaviour
{

    public float minGroundNormalY = .65f;
    public float gravityModifier = 1f;

    protected Vector2 targetVelocity;
    protected bool grounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);


    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    public UnityEvent OnLandEvent;

    private bool isInvulnerable = false;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
   // public Weapon ww;
    public GameObject gg;
    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity()
    {

    }

    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;

        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear();
            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }


        }

        rb2d.position = rb2d.position + move.normalized * distance;
        if (rb2d.position.y < -6f)
        {
            SoundManager.StopMusic();
            SoundManager.PlaySound("game over sound");

            FindObjectOfType<GameManage>().EndGame();

        }
        if (rb2d.position.x > 232.37)
        {
            // SoundManager.StopMusic();
            SoundManager.PlaySound("level complete");
            FindObjectOfType<GameManage>().CompleteLevel();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            SoundManager.PlaySound("coin sound");
            Destroy(collision.gameObject);
            ScoreScript.scoreValue += 1;
        }
        if (collision.CompareTag("bad guy") && !isInvulnerable)
        {
            SoundManager.StopMusic();
            SoundManager.PlaySound("game over sound");
            FindObjectOfType<GameManage>().EndGame();
        }
        if (collision.CompareTag("Star") && !isInvulnerable)
        {
            SoundManager.StopMusic();
            SoundManager.PlaySound("star music");
            Destroy(collision.gameObject);
            StartCoroutine(InvulnerabilityFlash());
      
        }
        if (collision.CompareTag("fire")){
            //(gg.GetComponent("Weapon") as MonoBehaviour).enabled = true;
            Destroy(collision.gameObject);
            // (gg.GetComponent("Weapon") as MonoBehaviour).enabled = true;
            gg.GetComponent<Weapon>().enabled = true;

        }
    }

    //Makes the player invulnerable and flashing, and ends it after a time
    IEnumerator InvulnerabilityFlash()
    {
        isInvulnerable = true;
        for (int i = 0; i < 25; i++)
        {
            //Debug.Log("flashing...");
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            yield return new WaitForSeconds(0.2F);
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.2F);
        }
        SoundManager.StopMusic();
        SoundManager.PlaySound("next level");
        //May need the level music in the Sound Manager
        isInvulnerable = false;
    }
}

