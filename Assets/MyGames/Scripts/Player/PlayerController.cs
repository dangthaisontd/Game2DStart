using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

[AddComponentMenu("DangSon/PlayerController")]
public class PlayerController : MonoBehaviour
{
    [Header("Player Controller")]
    public float moveSpeed = 5.0f; 
    public LayerMask groundLayer;
    public float jumFore=5.0f;
    [SerializeField] private Transform groundCheck;
    public float radius = 0.5f;
    bool facingRight = true;
    private Animator anim;
    private Rigidbody2D rb;
    //
    private int isWalkId;
    private int isJumId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        isWalkId = Animator.StringToHash("IsWalk");
        isJumId = Animator.StringToHash("IsJum");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //
        if(IsGround()&&Input.GetKeyDown(KeyCode.Space))
        {
           StartCoroutine(Jum());
        }
    }
    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
        if((horizontal>0&&!facingRight)||(horizontal<0&&facingRight))
        {
            Flip();
        }
        if(IsGround()&&Math.Abs(horizontal)>0)
        {
            anim.SetBool(isWalkId, true);
        }
        else
        {
            anim.SetBool(isWalkId, false);
        }
    }
    bool IsGround()
    {
        bool isLocalGround = Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
        return isLocalGround;
    }
    IEnumerator Jum()
    {
        
        anim.SetTrigger(isJumId);
        //tre 03f
        yield return new WaitForSeconds(0.3f);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumFore);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
    
}
