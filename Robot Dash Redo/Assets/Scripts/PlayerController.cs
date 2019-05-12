using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //floats
    //the player's move speed and force of their jump is defined here
    public float moveSpeed;
    public float jumpForce;
    //ints
    //current health and max health are defined here
    public int curHealth;
    public int maxHealth = 100;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;

    private Animator anim;
    //references
    private Rigidbody2D myRigidBody;
    private gameMaster gm;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag("gameMaster").GetComponent<gameMaster>();

        curHealth = maxHealth;

        anim = GetComponent<Animator>();

    }
    void Update()
    {
        //jump
        myRigidBody.velocity = new Vector2(moveSpeed, myRigidBody.velocity.y);
        if (grounded)
            doubleJumped = false;

        anim.SetBool("Grounded", grounded);

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) && grounded)
        {
            //myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            Jump();
        }

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) && !doubleJumped && !grounded)
        {
            //myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
            Jump();
            doubleJumped = true;
        }
        //current health is equal to max health at the start of the game
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        // if current health is equal to or less than zero then the player dies
        if (curHealth <= 0)
        {
            Die();
        }
        anim.SetFloat("Speed", Mathf.Abs(myRigidBody.velocity.x));

    }
    //when the player dies, unity's scene manager reloads the current scene
    void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    //declares damage taken by an object as an integer and when damage is taken, health is subtracted
    public void Damage(int dmg)
    {
        curHealth -= dmg;
    }
    //this code is used to knockback the player when they hit a spike obstacle
    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;

            myRigidBody.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
        }
        yield return 0;
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public void Jump()
    {
        myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpForce);
    }
    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "FallDetector")
        {
            //what happens when the player enters the fall detector zone
            Die();
        }
        if (Other.tag == "HeightDetector")
        {
            Die();
        }
    }
}
