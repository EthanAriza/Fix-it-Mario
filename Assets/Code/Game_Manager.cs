using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI FixedText;
    private float timer = 120f;

    public GameObject Goal;
    public Playermain playerscript;

    private void Start()
    {
        Goal.SetActive(false);
    }

    void Update() //simple timer that will reset the level upon reaching 0 + do an animation of the player character failing ** ALSO DOES IT FOR FIXED ITEMS
    {

        if (Playermain.Fixed_items >= 3) // The player can exit when they do the bare minimum of three repairs
        {
            Goal.SetActive(true);
        }

        timer -= Time.deltaTime;
        timerText.text = timer.ToString("0");
        FixedText.text = Playermain.Fixed_items.ToString("0");

        if (timer <= 0)
        {
            timerText.text = "0";
            Invoke(nameof(Endgame), 1f); // Will call on the endgame function after a certain amount of time specified
        }
    }

    void Endgame() // takes the current scene and just resets
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
