using Unity.VisualScripting;
using UnityEngine;
[AddComponentMenu("DangSon/PlayerAttack")]
public class PlayerAttack : MonoBehaviour
{
    public float radiusAttack = 0.7f;
    public Transform pointAtack;
    private int isAttackId;
    private Animator anim;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        isAttackId = Animator.StringToHash("IsAttack");
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
        }
    }
}

