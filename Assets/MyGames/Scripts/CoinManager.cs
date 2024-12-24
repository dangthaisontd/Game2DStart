using UnityEngine;
[AddComponentMenu("DangSon/CoinManager")]
public class CoinManager : MonoBehaviour
{
    public int coinNumber = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SetCoin(coinNumber);
            Destroy(gameObject);
        }

    }
}
