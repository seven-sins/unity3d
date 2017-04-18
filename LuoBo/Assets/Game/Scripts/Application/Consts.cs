using System;
using System.Collections.Generic;
using UnityEngine;

public static class Consts
{
    // 关卡目录
    public static string LevelDir = Application.dataPath + "/Resources/Res/Level/";
    public static string MapDir = Application.dataPath + "/Resources/Res/Scene/Map/";
    public static string CardDir = Application.dataPath + "/Resources/Res/Cards/";
    // 存档
    public const string GameProgress = "GameProgress";
    // Model
    public const string M_GameModel = "M_GameModel";
    // View
    public const string V_Start = "V_Start";
    public const string V_Select = "V_Select";
    public const string V_Board = "V_Board";
    public const string V_Complete = "V_Complete";
    public const string V_CountDown = "V_CountDown";
    public const string V_Win = "V_Win";
    public const string V_Lost = "V_Lost";
    public const string V_System = "V_System";

    // Controller
    public const string E_StartUp = "E_StartUp";

    public const string E_EnterScene = "E_EnterScene";
    public const string E_ExitScene = "E_ExitScene";

    public const string E_StartLevel = "E_StartLevel"; // 开始关卡
    public const string E_EndLevel = "E_EndLevel"; // 结束关卡


    // 倒计时结束
    public const string E_CountDownComplete = "E_CountDownComplete";
}

public enum GameSpeed
{
    One,
    Two
}