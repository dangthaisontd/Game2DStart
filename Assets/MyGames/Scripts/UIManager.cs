using System.Collections;
using TMPro;
using UnityEngine;
[AddComponentMenu("DangSon/UIManager")]
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textCoin;
    public TextMeshProUGUI textDiamond;
    private void Start()
    {
        StartCoroutine(UpdateUI());
    }
    private IEnumerator UpdateUI()
    {
        while (true)
        {
            textCoin.text = GameManager.Instance.GetCoin().ToString();
            textDiamond.text = GameManager.Instance.GetDiamond().ToString();
            yield return new WaitForSeconds(0.2f);
        }
        
    }
}
