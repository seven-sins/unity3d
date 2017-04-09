using System;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : View
{
    public override string Name
    {
        get { return Consts.V_Start; }
    }

    public void GotoSelect()
    {
        Game.Instance.LoadScene(2); // 序号2为select场景
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }
}
