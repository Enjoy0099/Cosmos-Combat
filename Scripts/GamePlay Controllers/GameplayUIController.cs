using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIController : MonoBehaviour
{

    public static GameplayUIController instance;

    [SerializeField]
    private Text wave_Info, shipsDestory_InfoTxt, meteorsDestory_InfoTxt;

    private int wave_Count = 0, shipsDestory_Count = 0, meteorsDestory_Count = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public int GetWaveCount()
    {
        return wave_Count;
    }

    public int GetShipsDestoryCount()
    {
        return shipsDestory_Count;
    }

    public int GetMeteorDestoryCount()
    {
        return meteorsDestory_Count;
    }

    public void SetInfoUI(int infoType)
    {
        switch(infoType)
        {
            case 1:
                wave_Count++;
                wave_Info.text = "Wave: " + wave_Count;
                break;

            case 2:
                shipsDestory_Count++;
                shipsDestory_InfoTxt.text = shipsDestory_Count + "x";
                break;

            case 3:
                meteorsDestory_Count++;
                meteorsDestory_InfoTxt.text = meteorsDestory_Count + "x";
                break;
        }
    }












}
