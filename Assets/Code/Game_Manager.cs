using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 120f;

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("0");

        if (timer <= 0)
        {
            timerText.text = "0";
            Invoke(nameof(Endgame), 0.1f);
        }
    }

    void Endgame()
    {
        SceneManager.LoadScene("Level_1");
    }
}
