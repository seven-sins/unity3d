using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enymy : MonoBehaviour
{

    public float speed = 10;
    private Transform[] positions;
    private int index = 0;

    void Start()
    {
        positions = WayPoints.positions;
    }

    void Update()
    {
        Move();

    }

    void Move()
    {
        if (index > positions.Length - 1)
        {
            return;
        }
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.2)
        {
            index++;
        }
    }
}
