using System;
using UnityEngine;
[AddComponentMenu("DangSon/EnemyAI")]
public class EnemyAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float minDistance = 0.2f;
    public float speedMove=2;
    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private int isIdleId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = pointB;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        isIdleId = Animator.StringToHash("IsIdle");
    }

    // Update is called once per frame
    void Update()
    {
        Pattrol();
    }

    private void Pattrol()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("SpiderIdle"))
            return;
        Vector2 direction = (target.position-transform.position).normalized;
        if(Vector2.Distance(transform.position, target.position)<minDistance)
        {
            anim.SetTrigger(isIdleId);
            target = target==pointB ? pointA : pointB;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        rb.linearVelocity = direction*speedMove;
    }
}
