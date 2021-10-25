using System.Collections;
using System.Collections.Generic;
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

    public bool check;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

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
