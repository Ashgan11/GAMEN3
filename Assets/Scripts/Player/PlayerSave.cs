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

        Vector3 position = data.position;

        controller.transform.position = position;
    }
}
