using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //public static UIManager instance;

    [SerializeField]
    private AudioSource audioSource;


    [SerializeField]
    private Slider sliderMusicVolume;

    [SerializeField]
    private Slider sliderVFXVolume;

    private void Awake()
    {
        //instance = this

        sliderMusicVolume.value = SaveData.data.musicVolume;
        sliderVFXVolume.value = SaveData.data.vfxVolume;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Delete");
        }
    }

    public void SetActiveUI(GameObject obj)
    {
        obj.SetActive(!obj.activeSelf);
    }


    public void SetMusicVolume(float volume)
    {
        SaveData.SetMusicVolume(volume);
    }

    public void SetVFXVolume(float volume)
    {
        SaveData.SetVFXVolume(volume);
    }

    public void ClickAudio()
    {
        audioSource.Play();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level 0");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
