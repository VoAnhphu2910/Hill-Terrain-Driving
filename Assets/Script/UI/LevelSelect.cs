using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private Button[] levelButton;

    [SerializeField]
    SceneFader sceneFader;

    private void OnEnable()
    {
        for (int i = 0; i < SaveData.data.levelList.Count; i++)
        {
            Debug.Log(SaveData.data.levelList[i]);
        }

        for (int i = 0; i < levelButton.Length; i++)
        {
            //Debug.Log("name " + int.Parse(levelButton[i].name));
            //Debug.Log("Level " + SaveData.data.levelList[j]);
            if(i > SaveData.data.levelList.Count - 1)
            {
                levelButton[i].interactable = false;
            }
            else if (int.Parse(levelButton[i].name) != SaveData.data.levelList[i])
            {
                levelButton[i].interactable = false;
            }
            
            
        }
        
    }

    public void SelectLevel(string scene)
    {
        sceneFader.FadeTo(scene);
    }
}
