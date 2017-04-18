using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICountDown : View
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
        get { return Consts.V_CountDown; }
    }
    public Image Count;
    public Sprite[] Numbers;
    #endregion

    #region 方法
    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    public void StartCountDown()
    {
        this.Show();
        StartCoroutine("DisplayCount");
    }
    IEnumerator DisplayCount()
    {
        int count = 3;
        while (count > 0)
        {
            // 显示
            Count.sprite = Numbers[count - 1];
            // 自减
            count--;
            // 等待一秒
            yield return new WaitForSeconds(1);
            if (count <= 0)
            {
                break;
            }
        }
        //
        this.Hide();
        // 倒计时结束
        SendEvent(Consts.E_CountDownComplete);
    }
    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    public override void RegisterEvents()
    {
        this.AttationEvents.Add(Consts.E_EnterScene);
    }
    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Consts.E_EnterScene:
                SceneArgs e = (SceneArgs)data;
                if (e.SceneIndex == 3)
                {
                    this.StartCountDown();
                }
                break;
            default: 
                break;
        }
    }
    #endregion

    #region 帮助方法
    #endregion



}
