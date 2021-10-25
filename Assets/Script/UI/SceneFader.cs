using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;   //Ảnh để tạo hiệu ứng load màn chơi
    public AnimationCurve curve;    // Đường cong biểu đồ biểu diễn tốc tộ thực hiện load

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()    // Tạo hiệu ứng khi load vào màn chơi
    {
        float t = 1f;

        while (t > 0f)
        {
            t -= Time.deltaTime;    // Trừ theo khung hình để lấy thời gian load màn
            float a = curve.Evaluate(t);    // Tốc độ làm mờ đi theo  đường cong
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }
    }

    public void FadeTo(string scene)    // Hàm dùng để load màn chơi và hiệu ứng khi gọi
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeOut(string scene)   // Load hiệu ứng khi rời khỏi màn chơi
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);  // Load màn chơi
    }
}
