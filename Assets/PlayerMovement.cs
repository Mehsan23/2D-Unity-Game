using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Extra stuff - Adiem question

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public float moveSpeed = 5f;  // how fast player moves
    public float jumpSpeed;  //how hight player jumps
    public float groundCheckRadius;
    public float exitCheckRadius; //Extra stuff - Adiem question
    public bool isGrounded;  // to check if palyer touches the groundCheckRadius
    //public bool isExit;


    public Transform groundCheck;  // definition of a transform used for player and ground collision detection
    //public Transform exitCheck;
    public LayerMask whatIsGround;
    //public LayerMask whatISExit; //Extra stuff - Adiem question
   // private Animator myAnim;  // for animation

    //Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
       // myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        //Extra stuff - Adiem question
        //isExit = Physics2D.OverlapCircle(groundCheck.position, exitCheckRadius, whatISExit);

        if (Input.GetAxisRaw("Horizontal") >0f) {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3 (1f, 1f, 1f);
        } else if (Input.GetAxisRaw("Horizontal") < 0f) {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3 (-1f, -1f, -1f);
        } else
            myRigidbody.velocity = new Vector3 (0f, myRigidbody.velocity.y, 0f );

        if (Input.GetButtonDown("Jump")) {
          myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);

        }

        //Extra stuff - Adiem question
        //if (isExit == true) {SceneManager.LoadScene("Scenes/Level2", LoadSceneMode.Single);}
        //{UnityEditor.EditorApplication.isPlaying = false;}

       // myAnim.SetFloat("speed", Mathf.Abs(myRigidbody.velocity.x));
       // myAnim.SetBool("grounded", isGrounded);

    }
}
