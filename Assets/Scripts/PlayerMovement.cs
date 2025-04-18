using UnityEngine;
using System.Collections;
// using System.Collections.Generic;
using System;
// using UnityEditor.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public int facingDirection = 1;
    public Rigidbody2D rb;
    public Animator anim;
    public Player_Combat player_Combat;
    private bool isKnockedBack;

    void Update()
    {
        if(Input.GetButtonDown("Slash")){
            player_Combat.Attack();
        }
    }
    void FixedUpdate()
    {
        if(isKnockedBack == false){
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if(horizontal > 0 && transform.localScale.x < 0 ||
            horizontal < 0 && transform.localScale.x > 0){
                Flip();
            }


            anim.SetFloat("horizontal", Math.Abs(horizontal));
            anim.SetFloat("vertical", Math.Abs(vertical));

            rb.linearVelocity = new Vector2(horizontal, vertical) * StatsManager.Instance.speed;
        }
    }

    void Flip(){
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Knockback(Transform enemy, float force, float stunTime){
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime){
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}
