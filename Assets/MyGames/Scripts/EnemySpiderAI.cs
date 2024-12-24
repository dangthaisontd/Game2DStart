using Unity.Mathematics;
using UnityEngine;
[AddComponentMenu("DangSon/EnemySpiderAI")]
public class EnemySpiderAI : MonoBehaviour
{
    [Header("Enemy Atribute")]
    public float speed = 1.5f;
    public Transform target;
    public float attackRange = 1f;
    public float attackCoolDown = 2f;
    [Header("Check Ground")]
    public LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    public float radius = 0.5f;
    private float lastAttackTime = 0;
    private Rigidbody2D rb;
    private Animator anim;
    private int isAttackId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        isAttackId = Animator.StringToHash("IsAttack");
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        Vector2 direction= (target.position - transform.position).normalized;
        //
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            //tan cong
            rb.linearVelocity = Vector2.zero;
            if (Time.time - lastAttackTime >= attackCoolDown)
            {
                //tan cong
            anim.SetTrigger(isAttackId);
            
            lastAttackTime = Time.time;
            }
        }
        else
        {
            if (IsGround())
            //di ve phia nguoi choi
            {
                rb.linearVelocity = direction * speed;
            }
        }
        if(direction.x>0)
        {
            Vector3 scale = transform.localScale;
            scale.x = math.abs(scale.x);
            transform.localScale = scale;
        }
        else if(direction.x<0) 
        {
            Vector3 scale = transform.localScale;
            scale.x = -math.abs(scale.x);
            transform.localScale = scale;
        }
        bool IsGround()
        {
            bool isLocalGround = Physics2D.OverlapCircle(groundCheck.position, radius, groundLayer);
            return isLocalGround;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
