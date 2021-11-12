using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health;
    public float[] position;

    public PlayerData(PlayerLife life, CharacterController controller)
    {
        health = life.getCurrentHealth();

        position = new float[3];
        position[0] = controller.transform.position.x;
        position[1] = controller.transform.position.y;
        position[2] = controller.transform.position.z;
    }
}
