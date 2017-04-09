using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour 
{
    public float Time = 1; // 一次循环所需要的时间(秒)
    public float OffsetY = 7; // Y方向浮动偏移
	void Start () {
        iTween.MoveBy(this.gameObject, iTween.Hash(
            "y", OffsetY,
            "easeType", iTween.EaseType.easeInOutSine,
            "loopType", iTween.LoopType.pingPong, // a->b    b->a     loop
            "time", Time
            ));
	}
}
