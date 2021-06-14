using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsManager 
{
   public static int GetHighScore()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            return PlayerPrefs.GetInt("HighScore");
        }
        return 0;
    }
    public static void SetHighScore(int newHighScore)
    {
        PlayerPrefs.SetInt("HighScore", newHighScore);
    }
    public static int GetFirstTime()
    {
        if (PlayerPrefs.HasKey("FirstTime"))
        {
            return PlayerPrefs.GetInt("FirstTime");
        }
        return 0;
    }
    public static void SetFirstTime(int time)
    {
        PlayerPrefs.SetInt("FirstTime", time);
    }
}
