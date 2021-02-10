using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    public Animator myAnim;
    void Start () {
        myAnim = GetComponent<Animator>();
    }


    void Update () {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        myAnim.SetFloat("Speed", Mathf.Abs(movement.x));
    }

    void Jump(){
        if (Input.GetButtonDown("Jump") && isGrounded == true){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);

        }
        if (Input.GetButtonDown("Jump") == true){
            myAnim.SetBool("isJump", true);
        }
        if (Input.GetButtonDown("Jump") == false && isGrounded == true){
            myAnim.SetBool("isJump", false);
        }
         
    }    
}
