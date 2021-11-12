using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    public CharacterController controller;
    public PlayerLife life;
    
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(life, controller);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        life.setCurrentHealth(data.health);

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        controller.transform.position = position;
    }
}
