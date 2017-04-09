﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(Sound))]
[RequireComponent(typeof(StaticData))]
public class Game : ApplicationBase<Game> 
{
    // 全局访问功能
    public ObjectPool ObjectPool = null; // 对象池
    public Sound Sound = null; // 声音控制
    public StaticData StaticData = null; // 静态数据

    // 全局方法
    public void LoadScene(int level)
    {
        // --退出上一个场景

        // 事件参数
        SceneArgs e = new SceneArgs();
        e.Level = SceneManager.GetActiveScene().buildIndex;
        // 发布事件
        SendEvent(Consts.E_ExitScene, e);

        // --加载新场景
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
    // 当前场景加载完成后触发
    void OnLevelWasLoaded(int level)
    {
        Debug.Log("OnLevelWasLoaded: " + level);
        // 事件参数
        SceneArgs e = new SceneArgs();
        e.Level = level;
        // 发布事件
        SendEvent(Consts.E_EnterScene, e);
    }
    // 游戏入口
	void Start () 
    {
        // 确保Game对象一直存在(c#: object, unity: Object)
        Object.DontDestroyOnLoad(this.gameObject);
        // 全局单例赋值
        ObjectPool = ObjectPool.Instance;
        Sound = Sound.Instance;
        StaticData = StaticData.Instance;
        // 注册启动命令
        RegisterController(Consts.E_StartUp, typeof(StartUpCommand));
        // 启动游戏 
        SendEvent(Consts.E_StartUp);
	}

}
