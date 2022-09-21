using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{

    public static GameOverUIController instance;

    [SerializeField]
    private Canvas playerInfoCanvas, shipsAndMeteorInfoCanvas, gameOverCanvas;

    [SerializeField]
    private Text shipsDestoryedFinalInfoTxt, meteorsDestoryedFinalInfoTxt, waveFinalInfoTxt;

    [SerializeField]
    private Text shipsDestoryedHighscoreTxt, meteorsDestoryedHighscoreTxt, waveHighscoreTxt;



    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void OpenGameOverPanel()
    {
        Invoke("_OpenGameOverPanel", 2.4f);
    }

    public void _OpenGameOverPanel()
    {
        playerInfoCanvas.enabled = shipsAndMeteorInfoCanvas.enabled = false;
        gameOverCanvas.enabled = true;

        int shipsDestroyedFinal = GameplayUIController.instance.GetShipsDestoryCount();
        int meteorsDestroyedFinal = GameplayUIController.instance.GetMeteorDestoryCount();
        int waveCountFinal = GameplayUIController.instance.GetWaveCount();

        waveCountFinal--;

        shipsDestoryedFinalInfoTxt.text = "x" + shipsDestroyedFinal;
        meteorsDestoryedFinalInfoTxt.text = "x" + meteorsDestroyedFinal;
        waveFinalInfoTxt.text = "Wave: " + waveCountFinal;

        CalculateHighScore(shipsDestroyedFinal, meteorsDestroyedFinal, waveCountFinal);
    }


    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


    void CalculateHighScore(int shipsDestroyedCurrent, int meteorsDestroyedCurrent, int waveCurrent)
    {
        int shipsDestroyed_HighScore = DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        int meteorsDestroyed_HighScore = DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        int wave_HighScore = DataManager.GetData(TagManager.WAVE_NUMBER_DATA);

        if (shipsDestroyedCurrent > shipsDestroyed_HighScore)
            DataManager.SaveData(TagManager.SHIPS_DESTROYED_DATA, shipsDestroyedCurrent);

        if (meteorsDestroyedCurrent > meteorsDestroyed_HighScore)
            DataManager.SaveData(TagManager.METEORS_DESTROYED_DATA, meteorsDestroyedCurrent);

        if (waveCurrent > wave_HighScore)
            DataManager.SaveData(TagManager.WAVE_NUMBER_DATA, waveCurrent);

        shipsDestoryedHighscoreTxt.text = "x"+ DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        meteorsDestoryedHighscoreTxt.text = "x" + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        waveHighscoreTxt.text = "Wave: " + DataManager.GetData(TagManager.WAVE_NUMBER_DATA);


    }




}
