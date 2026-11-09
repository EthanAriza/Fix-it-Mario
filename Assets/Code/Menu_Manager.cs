using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour
{
    public GameObject startTab, instructionsTab, creditsTab;

    // TIP: All of these are functions that are being used by the in engine unity buttons so if you dont know what the hell im doing here,
    // just scroll down in the inspector for the ui buttons and look what each one calls
    private void Start()
    {
        startTab.SetActive(false);
        instructionsTab.SetActive(false);
        creditsTab.SetActive(false);
    }
    public void Levelselect()
    {
        startTab.SetActive(true);
    }

    public void Instructions()
    {
        instructionsTab.SetActive(true);
    }

    public void Credits()
    {
        creditsTab.SetActive(true);
    }

    public void back()
    {
        startTab.SetActive(false);
        instructionsTab.SetActive(false);
        creditsTab.SetActive(false);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level_3");
    }
}
