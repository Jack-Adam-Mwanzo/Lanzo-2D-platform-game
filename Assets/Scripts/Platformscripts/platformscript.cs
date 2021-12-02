using System.ComponentModel;
using System.Threading;
using System.Security.Principal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformscript : MonoBehaviour
{
    public float move_Speed = 2f;
    public float bound_Y = 6f;

    public bool is_Breakable, is_Spike, is_Platform;

    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        if(is_Breakable)
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y >= bound_Y){
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate() {
        Invoke("DeactivateGameObject", 0.3f);
    }
    void DeactivateGameObject() {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Player"){
            if(is_Spike) {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
        }
    }//OnTriggerEnter
    void OnCollisionEnter2D(Collision2D target) {
        if(target.gameObject.tag == "Player"){
            if(is_Breakable) {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }
            if(is_Platform){
                SoundManager.instance.LandSound();
            }
        }
    }//OnCollisionEnter

}//class
