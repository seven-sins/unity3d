using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : Singleton<StaticData> 
{
    Dictionary<int, MonsterInfo> m_Monsters = new Dictionary<int, MonsterInfo>();

    protected override void Awake()
    {
        base.Awake();

        //
        InitMonsters();
        //
        InitTowers();
        //
        InitBullets();
    }
    void InitMonsters()
    {
        m_Monsters.Add(0, new MonsterInfo() { Hp = 1, MoveSpeed = 1f });
        m_Monsters.Add(1, new MonsterInfo() { Hp = 2, MoveSpeed = 1f });
        m_Monsters.Add(2, new MonsterInfo() { Hp = 3, MoveSpeed = 1f });
        m_Monsters.Add(3, new MonsterInfo() { Hp = 5, MoveSpeed = 1f });
    }
    public MonsterInfo GetMonsterInfo(int monsterType)
    {
        return m_Monsters[monsterType];
    }

    void InitTowers()
    {

    }

    void InitBullets()
    {

    }
}
