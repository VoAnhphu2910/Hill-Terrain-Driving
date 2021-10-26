using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D backTire;

    [SerializeField]
    private WheelJoint2D frontWheel;
    [SerializeField]
    private WheelJoint2D backWheel;

    [SerializeField]
    private float speed;

    private bool brakeFront = false;
    private bool brakeBack = false;

    private bool gas = false;
    private bool brake = false;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    AudioClip engineMoveAudio;

    private void Awake()
    {
        audioSource.clip = engineMoveAudio;
        //audioSource.clip = engineStarAudio;
        audioSource.Play();
        //StartCoroutine(Wait(engineMoveAudio, 1.6f));
    }

    // Update is called once per frame
    void Update()
    {
                //Debug.Log(body.velocity.magnitude);
        //GameManager.instance.Setfuel(body.velocity.magnitude / 100);


        Distance.instance.SetDistance();

        if(gas || brake)
        {
            if(audioSource.volume < SaveData.data.vfxVolume)
            {
                audioSource.volume += Time.deltaTime;
            }
        }
        else
        {
            if(audioSource.volume > .1f)
            {
                audioSource.volume -= Time.deltaTime;
            }
        }
        //GameManager.instance.SetfuelValue(Distance.instance.distanceSlider.value);
    }

    private void FixedUpdate()
    {
        if (gas || Input.GetKeyDown(KeyCode.D))
        {
            Move(-1);

        }
        if (brake || Input.GetKeyDown(KeyCode.A))
        {
            Move(1);
        }
    }

#region Controller Object

    private void Move(int dir)
    {
        //frontTire.AddTorque(dir * speed * Time.deltaTime);
        backTire.AddTorque(dir * speed * Time.deltaTime);
    }


    private IEnumerator SetBrakeTime(WheelJoint2D wheelJoint2D)
    {

        wheelJoint2D.useMotor = true;
        yield return new WaitForSeconds(.3f);
        wheelJoint2D.useMotor = false;
    }

    public void Gas(bool _gas)
    {
        //if (_gas)
        //{
        //    //StartCoroutine(Wait(engineMoveAudio, .3f));
        //    SetSound(engineMoveAudio);
        //}
        //else
        //{
        //    //StartCoroutine(Wait(engineStarAudio, .3f));
        //    SetSound(engineStarAudio);
        //}

        gas = _gas;

        brakeFront = true;
    }

    public void Brake(bool _brake)
    {
        //if (_brake)
        //{
        //    //StartCoroutine(Wait(engineMoveAudio, .3f));
        //    SetSound(engineMoveAudio);
        //}
        //else
        //{
        //    //StartCoroutine(Wait(engineStarAudio, .3f));
        //    SetSound(engineStarAudio);
        //}

        brake = _brake;
        brakeBack = true;
    }

    public void SetBrake(int index)
    {
        if (index == 1)
        {
            if (brakeBack)
            {
                StartCoroutine(SetBrakeTime(backWheel));
                brakeBack = false;
            }
        }
        if (index == 0)
        {
            if (brakeFront == true)
            {
                StartCoroutine(SetBrakeTime(frontWheel));
                brakeFront = false;
            }
        }
    }

    #endregion


#region Audio Controller

    IEnumerator Wait(AudioClip clip, float time)
    {
        yield return new WaitForSeconds(time);
        SetSound(clip);
    }

    public void SetSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

#endregion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EndPoint")
        {
            GameManager.instance.WinGame();
            //Time.timeScale = 0;
        }
    }

}
