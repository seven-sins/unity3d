using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour {

    public float speed = 1;
    public float mouseSpeed = 60;

	void Update () {
        // 键盘方向键
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 鼠标滚轮
        float mouse = Input.GetAxis("Mouse ScrollWheel");

        transform.Translate(new Vector3(h, mouse * mouseSpeed, v) * Time.deltaTime * speed, Space.World);
        
	}
}
