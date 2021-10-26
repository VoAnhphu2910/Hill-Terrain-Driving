using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public static Distance instance;

    [SerializeField]
    private GameObject starPoint;
    [SerializeField]
    private GameObject endPoint;
    [SerializeField]
    private Slider distanceSlider;

    private float distance;

    private GameObject car;

    private float currentDistance;
    // Start is called before the first frame update
    void Start()
    {
        car = GameManager.instance.carObject;
        instance = this;
        distance = Vector2.Distance(starPoint.transform.position, endPoint.transform.position);
        //Debug.Log(distance);
        distanceSlider.maxValue = distance;
        

    }

    public void SetDistance()
    {
        currentDistance = distance - Vector2.Distance(car.transform.position, endPoint.transform.position);
        distanceSlider.value = currentDistance;
        GameManager.instance.textDistance.text = Mathf.RoundToInt(currentDistance) + "M";
    }
}
