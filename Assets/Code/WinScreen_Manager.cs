using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen_Manager : MonoBehaviour
{
    public TextMeshProUGUI FixedScore;

    private void Start()
    {
        FixedScore.text = Playermain.Fixed_items.ToString();
    }

    public void Return()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
