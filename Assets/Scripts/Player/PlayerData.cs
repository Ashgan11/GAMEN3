using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float health;
    public Vector3 position;

    public PlayerData(PlayerLife life, CharacterController controller)
    {
        health = life.getCurrentHealth();

        position = new Vector3
        (
            controller.transform.position.x, 
            controller.transform.position.y, 
            controller.transform.position.z
        );
    }
}
