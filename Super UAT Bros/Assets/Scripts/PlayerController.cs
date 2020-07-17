using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float maxHP;
    private Transform tf;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;

    public GameObject SpawnPoint;
    public GameObject Player;

    /// <summary>
    /// The movement speed of the player.
    /// </summary>
    public float movementSpeed = 5.0f;

    public float jumpForce = 10.0f;
    public Transform groundPoint;
    public bool isGrounded = false;
    public bool DoubleJump = false;



    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        maxHP = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (maxHP == 0)
        {

            LoseScreen();

        }

            float xMovement = Input.GetAxis("Horizontal") * movementSpeed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);
        if (xMovement > 0)
        {
            sr.flipX = false;
            animator.Play("PlayerWalk");
        }
        else if (xMovement < 0)
        {
            sr.flipX = true;
            animator.Play("PlayerWalk");
        }
        else
        {
            animator.Play("PlayerIdle");
        }
        // Detect if the player is on the ground
        RaycastHit2D hitInfo = Physics2D.Raycast(groundPoint.position, Vector2.down, 1f);
        if (hitInfo.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Jump");
            rb2d.AddForce(Vector2.up * jumpForce);
        }

        //Double Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && DoubleJump == false)
        {

            Debug.Log("Double Jump");
            rb2d.AddForce(Vector2.up * jumpForce);
            DoubleJump = true;

        }

        if (isGrounded == true)
        {

            DoubleJump = false;

        }
        
    }

    public void Respawn ()
    {

        Player.transform.position = SpawnPoint.transform.position;

    }

    public void LoseScreen()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(3);

    }

}
