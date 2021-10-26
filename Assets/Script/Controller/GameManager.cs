using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    
    private int coin;
    [Tooltip("Nhiên liệu tính bằng thời gian đơn vị là giây")]
    public int fuel;
    public int Gem;

    [SerializeField]
    private int nextLevel;

    [SerializeField]
    private GameObject panelWin;
    [SerializeField]
    private GameObject panelLose;

    private float fuelCurent;
    [SerializeField]
    private Slider sliderFuel;

    [SerializeField]
    private GameObject []carList;
    public GameObject carObject;
    private CarController carController;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private AudioSource backgroundMusic;
    public AudioSource audioCollect;


    [SerializeField]
    private SceneFader sceneFader;

    [SerializeField]
    private Text textWincoin;
    [SerializeField]
    private Text textLoseCoin;
    [SerializeField]
    public Text textTime;

    public Text textDistance;

    private float timeCounting;

    [HideInInspector]
    public UnityEvent<int> setCoin;

    // Start is called before the first frame update
    void Awake()
    {

        carObject = Instantiate(carList[SaveData.data.carSelect], spawnPoint);
        carController = carObject.GetComponent<CarController>();

        audioCollect.volume = SaveData.data.vfxVolume;

        if (SaveData.data.vfxVolume > 0)
        {
            carObject.GetComponent<AudioSource>().volume = SaveData.data.vfxVolume;
        }
        else
        {
            carObject.GetComponent<AudioSource>().Stop();
        }

        if (SaveData.data.musicVolume <= 0)
        {
            backgroundMusic.Stop();
        }
        else
        {
            backgroundMusic.volume = SaveData.data.musicVolume;
        }

        instance = this;
        fuelCurent = 0;
        sliderFuel.maxValue = fuel;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounting += Time.deltaTime; 

        fuelCurent += Time.deltaTime;
        sliderFuel.value = fuelCurent;

        if (sliderFuel.value >= sliderFuel.maxValue)
        {
            LoseGame();
        }

    }



    public void SetfuelValue(int amount)
    {

        fuelCurent -= amount;
        if(fuelCurent < 0)
        {
            fuelCurent = 0;
        }

        sliderFuel.value = fuelCurent;
        //sliderFuel
    }

    public void SetCoin(int _amount)
    {
        coin += _amount;
        //textCoin.text = coin.ToString();
        setCoin?.Invoke(coin);
    }

    #region CarController


    public void Gas(bool move)
    {
        carController.Gas(move);
    }

    public void Brake(bool brake)
    {
        carController.Brake(brake);
    }

    public void SetBrake(int index)
    {
        carController.SetBrake(index);
    }

    #endregion

    public void WinGame()
    {
        panelWin.SetActive(true);

        textTime.text = Mathf.RoundToInt(timeCounting/60).ToString() + " minutes " + Mathf.RoundToInt(timeCounting % 60).ToString() +" seconds" ;
        textWincoin.text = coin.ToString();
        SaveData.SetCoin(coin);
        SaveData.SetLevelList(nextLevel);
    }

    public void LoseGame()
    {
        textLoseCoin.text = coin.ToString();
        SaveData.SetCoin(coin);
        panelLose.SetActive(true);
    }

    public void Pause(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);

        if (obj.activeSelf)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

    }

    public void Retry()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        sceneFader.FadeTo("MainMenu");
    }
}
