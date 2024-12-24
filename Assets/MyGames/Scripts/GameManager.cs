using UnityEngine;
[AddComponentMenu("DangSon/GameManager")]
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static  GameManager Instance
    {
        get => instance;
    }
    //
    private int coin;
    public int diamond;
    private void Awake()
    {
        if(instance!=null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCoin(int coin)
    {
        this.coin += coin;
    }
    public int GetCoin()
    {
        return coin;
    }
    public void SetDiamond(int diamond)
    {
        this.diamond += diamond;
    }
    public int GetDiamond()
    {
        return diamond;
    }
}
