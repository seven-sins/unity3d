using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class Server
{
    public static int GetProgress()
    {
        return PlayerPrefs.GetInt(Consts.GameProgress, -1);
    }
    public static void SetProgress(int levelIndex)
    {
        PlayerPrefs.SetInt(Consts.GameProgress, levelIndex);
    }
}