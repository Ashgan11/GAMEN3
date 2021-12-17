using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    public CharacterController controller;
    public PlayerLife life;
    
    public void SavePlayer()
    {
        float[] positionArr = {controller.transform.position.x, controller.transform.position.y, controller.transform.position.z};

        SaveSystem.SavePlayer(life.getCurrentHealth(), positionArr);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        life.setCurrentHealth(data.health);

        Quaternion rot = controller.transform.rotation;
        Vector3 pos = new Vector3(data.position[0], data.position[1], data.position[2]);
        controller.enabled = false;
        controller.transform.SetPositionAndRotation(pos, rot);
        controller.enabled = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5)){
            SavePlayer();
        }
        else if(Input.GetKeyDown(KeyCode.F6)){
            LoadPlayer();
        }
    }
}
