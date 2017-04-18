using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnterSceneCommand : Controller
{
    public override void Execute(object data)
    {
        SceneArgs e = data as SceneArgs;
        // 注入视图(View)
        switch (e.SceneIndex)
        {
            case 0: // init
                break;
            case 1: // start
                RegisterView(GameObject.Find("UIStart").GetComponent<UIStart>());
                break;
            case 2: // select
                RegisterView(GameObject.Find("UISelect").GetComponent<UISelect>());
                break;
            case 3: // level
                RegisterView(GameObject.Find("UIBoard").GetComponent<UIBoard>());
                // 隐藏对象不能直接Find查找， 只能通过父级查找
                RegisterView(GameObject.Find("Canvas").transform.Find("UICountDown").GetComponent<UICountDown>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UIWin").GetComponent<UIWin>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UILost").GetComponent<UILost>());
                RegisterView(GameObject.Find("Canvas").transform.Find("UISystem").GetComponent<UISystem>());
                break;
            case 4: // complete
                RegisterView(GameObject.Find("UIComplete").GetComponent<UIComplete>());
                break;
            default:
                break;
        }
    }
}
