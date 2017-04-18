using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameModel : Model
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    // 所有的关卡
    List<Level> m_Levels = new List<Level>();
    // 当前游戏关卡索引
    int m_PlayLevelIndex = -1;
    // 最大通关关卡索引
    int m_GameProgress = -1;
    // 游戏当前分数
    int m_score = 0;
    // 是否游戏中
    bool m_isPlaying = true;
    #endregion

    #region 属性
    public override string Name
    {
        get { return Consts.M_GameModel; }
    }
    public int Score
    {
        get { return m_score; }
        set { m_score = value; }
    }
    public bool IsPlaying
    {
        get { return m_isPlaying; }
        set { m_isPlaying = value; }
    }
    // 关卡总数量
    public int LevelCount
    {
        get { return m_Levels.Count; }
    }
    public bool IsGamePassed
    {
        get { return GameProgress >= LevelCount - 1; }
    }
    public int GameProgress
    {
        get { return m_GameProgress; }
    }
    public int PlayLevelIndex
    {
        get { return m_PlayLevelIndex; }
        set { m_PlayLevelIndex = value; }
    }
    public List<Level> AllLevels
    {
        get { return m_Levels; }
    }
    public Level PlayLevel
    {
        get {
            if (m_PlayLevelIndex < 0 || m_PlayLevelIndex > m_Levels.Count - 1)
            {
                return null;
            }
            return m_Levels[m_PlayLevelIndex]; 
        }
    }
    #endregion

    #region 方法
    // 初始化
    public void Initialize()
    {
        List<FileInfo> files = Tools.GetLevelFiles();
        List<Level> levels = new List<Level>();

        for (int i = 0; i < files.Count; i++)
        {
            Level level = new Level();
            Tools.FillLevel(files[i].FullName, ref level);
            levels.Add(level);
        }
        m_Levels = levels;
        // 读取游戏进度
        m_GameProgress = Server.GetProgress();
    }
    // 游戏开始
    public void StartLevel(int levelIndex)
    {
        m_PlayLevelIndex = levelIndex;
        m_isPlaying = true;
    }
    // 游戏结束
    public void StopLevel(bool isWin)
    {
        if (isWin && PlayLevelIndex > GameProgress)
        {
            Server.SetProgress(PlayLevelIndex);
        }
        m_isPlaying = false;
    }
    // 清档
    public void ClearProcess()
    {
        m_PlayLevelIndex = -1;
        m_isPlaying = false;
        m_GameProgress = -1;
        Server.SetProgress(-1);
    }
    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    #endregion

    #region 帮助方法
    #endregion
}
