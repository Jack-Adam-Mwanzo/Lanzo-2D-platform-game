using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        Jump();
        animator.SetBool("isJumping", true);
    }

    void Jump() {
       if(Input.GetButtonDown("Jump")) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0.001f), ForceMode2D.Impulse);
       }
    }
}
