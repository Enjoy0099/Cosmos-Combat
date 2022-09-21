using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Canvas mainMenuCanvas, highScoreCanvas;

    [SerializeField]
    private Text shipsDestroyedHighScore, meteorsDestroyedHighScore, wavesSurvivedHighScore;

    public void GamePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenCloseHighScoreCanvas(bool open)
    {
        mainMenuCanvas.enabled = !open;
        highScoreCanvas.enabled = open;

        if(open)
            DisplayHighscore();
    }

    void DisplayHighscore()
    {
        shipsDestroyedHighScore.text = "x" + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        meteorsDestroyedHighScore.text = "x" + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        wavesSurvivedHighScore.text = "Wave: " + DataManager.GetData(TagManager.WAVE_NUMBER_DATA);
    }

}
