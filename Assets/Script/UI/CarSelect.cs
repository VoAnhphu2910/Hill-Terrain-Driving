using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSelect : MonoBehaviour
{
    public Sprite[] carsImage;

    // Các gameobject dùng để hiển thị xe
    [SerializeField]
    private Image imageCarPrevious;
    [SerializeField]
    private Image imageCarCurrent;
    [SerializeField]
    private Image imageCarNext;
    [SerializeField]
    private GameObject lockIcon;

    //[SerializeField]
    //private Button ButtonBuy;

    [SerializeField]
    private Text textCoin; 
    [SerializeField]
    private Text textPrice;

    [SerializeField]
    private GameObject panelMessege;

    // Biến số xe hiện tại đang được chọn
    private int indexCurrentCar;

    private void OnEnable()
    {
        textCoin.text = SaveData.data.coin.ToString();
            
        indexCurrentCar = SaveData.data.carSelect;

        imageCarCurrent.sprite = carsImage[indexCurrentCar];
        
        if (indexCurrentCar + 1 > carsImage.Length -1)
        {
            imageCarNext.sprite = carsImage[0];
        }
        else
        {
            imageCarNext.sprite = carsImage[indexCurrentCar + 1];
        }

        if (indexCurrentCar - 1 <0)
        {
            imageCarPrevious.sprite = carsImage[carsImage.Length - 1];
        }
        else
        {
            imageCarPrevious.sprite = carsImage[indexCurrentCar - 1];
        }

        
        //SetCar(indexCurrentCar, 1);
        //SetCar(indexCurrentCar, -1);
    }


    public void SelectCarCurrent()
    {
        SaveData.SetCarSelect(indexCurrentCar);
    }

    public void ButtonBuy()
    {
        if(SaveData.data.coin >= SaveData.data.carListPrice[indexCurrentCar])
        {
            Debug.Log(indexCurrentCar);
            SaveData.data.coin -= SaveData.data.carListPrice[indexCurrentCar];
            SaveData.SetCarList(indexCurrentCar);

            lockIcon.SetActive(false);
            textCoin.text = SaveData.data.coin.ToString();
        }
        else
        {
            panelMessege.SetActive(true);
        }
    }

    public void NextCar()
    {

        indexCurrentCar++;
        
        if (indexCurrentCar > carsImage.Length - 1)
        {
            indexCurrentCar = 0;
        }


        for (int i = 0; i < SaveData.data.carList.Count; i++)
        {

            if (indexCurrentCar == SaveData.data.carList[i])
            {
                lockIcon.SetActive(false);
                break;
            }
            else
            {
                lockIcon.SetActive(true);
                textPrice.text = SaveData.data.carListPrice[indexCurrentCar].ToString();
            }
        }
        //Debug.Log(indexCurrentCar);


        // hiển thị ảnh hiện tại của xe đang chọn
        
        imageCarCurrent.sprite = carsImage[indexCurrentCar];
        

        // Xe tiếp theo
        if (indexCurrentCar + 1 > carsImage.Length - 1)
        {
            imageCarNext.sprite = carsImage[0];
        }
        else
        {
            imageCarNext.sprite = carsImage[indexCurrentCar + 1];
        }

        // Xe trước đó
        if (indexCurrentCar - 1 < 0)
        {
            imageCarPrevious.sprite = carsImage[carsImage.Length - 1];
        }
        else
        {
            imageCarPrevious.sprite = carsImage[indexCurrentCar - 1];
        }
        

    }

    public void PreviousCar()
    {
        indexCurrentCar--;


        if (indexCurrentCar < 0)
        {
            indexCurrentCar = carsImage.Length-1;
        }

        for (int i = 0; i < SaveData.data.carList.Count; i++)
        {
            if (indexCurrentCar == SaveData.data.carList[i])
            {
                lockIcon.SetActive(false);
                break;
            }
            else
            {
                lockIcon.SetActive(true);
                textPrice.text = SaveData.data.carListPrice[indexCurrentCar].ToString();
            }
        }


        // Hiển thị xe hiện tại đang được chọn
        if (indexCurrentCar < 0)
        {
            imageCarCurrent.sprite = carsImage[carsImage.Length - 1];
        }
        else
        {
            imageCarCurrent.sprite = carsImage[indexCurrentCar];
        }

        // Xe tiếp theo
        if (indexCurrentCar + 1 > carsImage.Length - 1)
        {
            imageCarNext.sprite = carsImage[0];
        }
        else
        {
            imageCarNext.sprite = carsImage[indexCurrentCar + 1];
        }

        // Xe trước đó
        if (indexCurrentCar - 1 < 0)
        {
            imageCarPrevious.sprite = carsImage[carsImage.Length - 1];
        }
        else
        {
            imageCarPrevious.sprite = carsImage[indexCurrentCar - 1];
        }

    }

}
