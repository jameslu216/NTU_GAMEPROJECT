using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data : ScriptableObject
{
    public int hasBoom = 1;
    public float clockTime = 600;
    public float boomTime = 60;
    public int win_P1 =0;
    public int win_P2 =0;
}
