using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 获取所有路径点
/// </summary>
public class WayPoints : MonoBehaviour
{

    public static Transform[] positions;

    void Awake()
    {
        positions = new Transform[transform.childCount];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = transform.GetChild(i);
        }
    }
}
