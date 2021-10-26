using UnityEngine;

public class Collection : MonoBehaviour
{
    public enum Type
    {
        coin,
        fuel,
        Gem
    }

    [SerializeField]
    private int amount;
    [SerializeField]
    private Type type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type == Collection.Type.fuel)
        {
            GameManager.instance.SetfuelValue(amount);
        }
        else if(type == Collection.Type.coin)
        {
            //GameManager.instance.coin += amount;
            GameManager.instance.SetCoin(amount);
        }
        else if(type == Collection.Type.Gem)
        {
            GameManager.instance.Gem += amount;
        }

        GameManager.instance.audioCollect.Play();
        Destroy(this.gameObject);
    }
}
