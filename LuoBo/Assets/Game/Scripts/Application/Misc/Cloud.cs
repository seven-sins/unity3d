using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float OffsetX = 1888; // x方向偏移
    public float Duration = 7f; // 周期时间

    void Start()
    {
        iTween.MoveBy(this.gameObject, iTween.Hash(
            "x", OffsetX,
            "easeType", iTween.EaseType.linear,
            "loopType", iTween.LoopType.loop, // a->b loop
            "time", Duration
            ));
    }
}
