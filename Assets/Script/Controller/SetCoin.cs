using UnityEngine;
using UnityEngine.UI;

public class SetCoin : MonoBehaviour
{
    private Text textCoin;

    // Start is called before the first frame update
    void Awake()
    {
        textCoin = gameObject.GetComponent<Text>();
        
    }

    private void Start()
    {
        GameManager.instance.setCoin.AddListener(_SetCoin);
    }

   private void _SetCoin(int coin)
    {
        textCoin.text = coin.ToString();
    }
}
