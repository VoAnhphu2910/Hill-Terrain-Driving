using System.Collections.Generic;
using UnityEngine;



public static class SaveData
{
    public static Data data;
    private const string stringSaveDataMenu = "SaveData";

    static SaveData()
    {
        data = JsonUtility.FromJson<Data>(PlayerPrefs.GetString(stringSaveDataMenu));

        // Lần đầu chạy ứng dụng
        if (data == null)
        {
            int coint = 1000;
            int carSelect = 0;

            List<int> carList = new List<int> { 0 };
            List<int> carListPrice = new List<int> { 0, 2500, 4000, 5000 };

            List<int> levelList = new List<int> { 0 };

            float vfxVolume = 1f;
            float musicVolume = 1f;

            data = new Data
            (
                coint, carSelect, carList, carListPrice, levelList,vfxVolume, musicVolume
            );
            Save();
        }
    }

    public static void SetMusicVolume(float volume)
    {
        data.musicVolume = volume;
        Save();
    }

    public static void SetVFXVolume(float volume)
    {
        data.vfxVolume = volume;
        Save();
    }

    public static void SetCoin(int _coin)
    {
        data.coin += _coin;
        Save();
    }

    public static void SetCarSelect(int _id)
    {
        data.carSelect = _id;
        Save();
    }

    public static void SetCarList(int id)
    {
        data.carList.Add(id);
        Save();
    }

    public static void SetLevelList(int id)
    {
        data.levelList.Add(id);
        Save();
    }

    public static void Save()
    {
        var data = JsonUtility.ToJson(SaveData.data);
        PlayerPrefs.SetString(stringSaveDataMenu, data);
    }
}



public class Data
{
    public int coin,carSelect;
    public List<int> carList;
    public List<int> carListPrice;
    public List<int> levelList;
    public float vfxVolume, musicVolume;

    public Data(int coin, int carSelect, List<int> carList, List<int> carListPrice, 
        List<int> levelList, float vfxVolume, float musicVolume)
    {
        this.coin = coin;
        this.carSelect = carSelect;
        this.carList = carList;
        this.carListPrice = carListPrice;
        this.levelList = levelList;
        this.vfxVolume = vfxVolume;
        this.musicVolume = musicVolume;
    }
}
