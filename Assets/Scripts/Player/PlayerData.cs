using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health;
    public float[] position;

    public PlayerData(float life, float[] position)
    {
        health = life;

        this.position = position;
    }
}
