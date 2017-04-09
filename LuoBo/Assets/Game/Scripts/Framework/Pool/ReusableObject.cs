using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public abstract class ReusableObject : MonoBehaviour, Reusable
{
    public abstract void OnSpawn();

    public abstract void OnUnspawn();
}
