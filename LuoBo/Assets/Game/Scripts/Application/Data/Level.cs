using System;
using System.Collections.Generic;
using System.Text;

public class Level
{
    // 名字
    public string Name;
    //卡片
    public string CardImage;
    // 背景图片
    public string Background;
    // 路径
    public string Road;
    // 初始金币
    public int InitScore;
    // 炮塔可放置位置
    public List<Point> Holder = new List<Point>();
    // 怪物行走路线
    public List<Point> Path = new List<Point>();
    // 回合数
    public List<Round> Rounds = new List<Round>();
}
