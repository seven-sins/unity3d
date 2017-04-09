using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelect : View
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    #endregion

    #region 属性
    public override string Name
    {
        get { return Consts.V_Select; }
    }
    #endregion

    #region 方法
    // 返回到开始界面
    public void GoBack()
    {
        Game.Instance.LoadScene(1); // 开始场景序号 = 1
    }
    // 选中关上游戏
    public void ChooseLevel()
    {
        StartLevelArgs e = new StartLevelArgs()
        {
            LevelIndex = 0
        };

        SendEvent(Consts.E_StartLevel, e);
    }
    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    public override void HandleEvent(string eventName, object data)
    {
        
    }
    #endregion

    #region 帮助方法
    #endregion

}
