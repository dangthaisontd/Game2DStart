using UnityEngine;
[AddComponentMenu("DangSon/DiamondManager")]
public class DiamondManager : MonoBehaviour
{
    public int diamondNumber = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SetDiamond(diamondNumber);
            Destroy(gameObject);
        }

    }
}
