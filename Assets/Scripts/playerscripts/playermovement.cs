using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Animator animator;
    float lockPos = 0;
    private Rigidbody2D myBody;

    [SerializeField]
    private float moveSpeed = 5f;

    private bool facingRight;
    // Start is called before the first frame update
    void Awake()
    {
        facingRight = true;
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetBool("isJumping", true);
        float horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));


        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);//lock rotation
        Move(horizontal);
        //Move();
        Flip(horizontal);
        Jump();
        //Jump();
    }
    private void Move(float horizontal)
    {
        myBody.velocity = new Vector2(horizontal * moveSpeed, myBody.velocity.y);
        //float horizontal = Input.GetAxisRaw("Horizontal");
        //if(horizontal > 0f) {
        //    myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        //}
       // if(horizontal < 0f) {
       //     myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
       // }

       // myBody = transform.localScale;
       // if(Input.GetAxisRaw("Horizontal") < 0) {
        //    myBody = -10;
       // }
       // if(Input.GetAxisRaw("Horizontal") > 0) {
       //     myBody = 10;
       // }
       // transform.localScale = 10;
    }//move

    public void PlatformMove(float x) {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
    //flip the character

    private void Flip(float horizontal)
    {
      if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
          facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
     void Jump() {
       if(Input.GetButtonDown("Jump")) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0.001f), ForceMode2D.Impulse);
       }
    }
    //void Jump() {
       // if(Input.GetButtonDown("Jump")) {
       //     gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
       // }
    //}
}
