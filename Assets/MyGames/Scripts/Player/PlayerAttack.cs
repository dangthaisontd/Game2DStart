using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
[AddComponentMenu("DangSon/PlayerAttack")]
public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Atribute")]
    public float radiusAttack = 0.7f;
    public Transform pointAtack;
    [Header("Attack")]
    public float timeDelay = 0.2f;
    public int damageToGive = 10;
    public float atackRate = 0.2f;
    [Header("LayerMask")]
    public LayerMask enemyLayer;
    [Header("FX Attack")]
    public GameObject FxAttackPrefabs;
    private int isAttackId;
    private Animator anim;
    private float nextAttack=0;
    private PlayerController playerController;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        isAttackId = Animator.StringToHash("IsAttack");
        playerController = GetComponent<PlayerController>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(pointAtack != null )
        {
            Gizmos.DrawWireSphere(pointAtack.position, radiusAttack);        
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
        anim.SetTrigger(isAttackId);
        HandelFX();
        HandleAttack();
        }
    }
    void HandelFX()
    {
       GameObject objFx = Instantiate(FxAttackPrefabs, transform.position, Quaternion.identity);
       Quaternion scaleto = objFx.transform.localRotation;
       scaleto.z += 45;
       objFx.transform.localRotation = scaleto;
       if(!playerController.GetFaceRight())
        {
         Vector2 scale = objFx.transform.localScale;
         scale.x *= -1;
         objFx.transform.localScale = scale;
        }
    }
    private void HandleAttack()
    {
     if(Time.time>nextAttack)
        {
            nextAttack = Time.time + atackRate;
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(timeDelay);
        Collider2D[] hitEnemys= Physics2D.OverlapCircleAll(pointAtack.position,radiusAttack,enemyLayer);
        foreach (var enemy in hitEnemys)
        {
            var canTakeDamage = enemy.GetComponent<ICanTakeDamage>();
            if(canTakeDamage != null)
            {
                canTakeDamage.TakeDamage(damageToGive,Vector2.down,gameObject);
                
            }
        }
    }
}

