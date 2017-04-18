using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class UISelect : View
{
    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段
    public Button btnStart;

    List<Card> m_Cards = new List<Card>();
    int m_SelectIndex = -1;
    GameModel m_GameModel = null;
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
            LevelIndex = m_SelectIndex
        };

        SendEvent(Consts.E_StartLevel, e);
    }
    void LoadCards()
    {
        // 获取Level集合
        List<Level> levels = m_GameModel.AllLevels;

        // 构建Card集合
        List<Card> cards = new List<Card>();
        for (int i = 0; i < levels.Count; i++)
        {
            Card card = new Card()
            {
                LevelId = i,
                CardImage = levels[i].CardImage,
                IsLocked = i > 0 //m_GameModel.GameProgress
            };
            cards.Add(card);
        }
        this.m_Cards = cards;
        // 监听关卡点击事件
        UICard[] uiCards = this.transform.Find("UICards").GetComponentsInChildren<UICard>();
        foreach (UICard uiCard in uiCards)
        {
            uiCard.OnClick += (card) =>
            {
                SelectCard(card.LevelId);
            };
        }
        // 默认选择第1个关卡
        SelectCard(0);
    }
    void SelectCard(int index)
    {
        if (m_SelectIndex == index)
        {
            return;
        }
        m_SelectIndex = index;
        // 计算索引号
        int left = m_SelectIndex - 1;
        int current = m_SelectIndex;
        int right = m_SelectIndex + 1;
        // 绑定数据
        // 左边
        Transform container = this.transform.Find("UICards");
        if (left < 0)
        {
            container.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            container.GetChild(0).gameObject.SetActive(true);
            container.GetChild(0).GetComponent<UICard>().IsTransparent = true;
            container.GetChild(0).GetComponent<UICard>().DataBind(m_Cards[left]);
        }
        // 当前
        container.GetChild(1).GetComponent<UICard>().DataBind(m_Cards[current]);
         // 控制开始按钮状态
        btnStart.gameObject.SetActive(!m_Cards[current].IsLocked);
        
        // 右边
        if (right >= m_Cards.Count)
        {
            container.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            container.GetChild(2).gameObject.SetActive(true);
            container.GetChild(2).GetComponent<UICard>().IsTransparent = true;
            container.GetChild(2).GetComponent<UICard>().DataBind(m_Cards[right]);
        }
       

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
                SceneArgs e = data as SceneArgs;
                if (e.SceneIndex == 2)
                {
                    // 获取更新数据
                    m_GameModel = GetModel<GameModel>();
                    // 初始化关卡列表
                    LoadCards();
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
