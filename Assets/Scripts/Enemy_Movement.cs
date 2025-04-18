// using Unity.VisualScripting;
// using UnityEditor.Tilemaps;
using UnityEngine;
// using UnityEngine.XR;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    public float attackRange = 2;
    public float attackCooldown = 2;
    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    private float attackCooldownTimer;
    private Rigidbody2D rb;
    private Transform player;
    private int facingDirection = -1;
    private EnemyState enemyState;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyState != EnemyState.Knockback){
            CheckForPlayer();
            if(attackCooldownTimer > 0){
                attackCooldownTimer -= Time.deltaTime;
            }
            if(enemyState == EnemyState.Chasing)
            {
                Chase();
            }
            else if(enemyState == EnemyState.Attacking){
                rb.linearVelocity = Vector2.zero;

            }
        }
    }

    void Chase(){
        if(player.position.x > transform.position.x && facingDirection == -1 ||
        player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }
            Vector2 direction  = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
    }

    void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);
        if(hits.Length > 0){
            player = hits[0].transform;

            if(Vector2.Distance(transform.position, player.position) <= attackRange && attackCooldownTimer <= 0){
                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.Attacking);
            }

            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState != EnemyState.Attacking){
                ChangeState(EnemyState.Chasing);
            }
        }
        else{
            rb.linearVelocity  = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    void Flip(){
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void ChangeState(EnemyState newState)
    {
        if(enemyState == EnemyState.Idle)
            anim.SetBool("isIdle",false);
        else if(enemyState == EnemyState.Chasing)
            anim.SetBool("isMoving",false);
        else if(enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking",false);


        enemyState = newState;

        if(enemyState == EnemyState.Idle)
            anim.SetBool("isIdle",true);
        else if(enemyState == EnemyState.Chasing)
            anim.SetBool("isMoving",true);
        else if(enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking",true);
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
    Knockback,
}
