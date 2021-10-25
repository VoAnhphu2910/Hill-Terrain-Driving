using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.carObject;
        pos.z = -10;
    }

    Vector3 pos;
    // Update is called once per frame
    void Update()
    {
        pos.x = target.transform.position.x + offset.x;
        pos.y = target.transform.position.y + offset.y;
        transform.position = pos;
    }
}
