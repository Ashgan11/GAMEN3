using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject ExitNorth;
    public GameObject ExitEast;
    public GameObject ExitSouth;
    public GameObject ExitWest;

    public void InitExits(bool North, bool East, bool South, bool West){
        if (North)  foreach (Transform child in ExitNorth.transform)    child.gameObject.SetActive(false);
        if (East)   foreach (Transform child in ExitEast.transform)     child.gameObject.SetActive(false);
        if (South)  foreach (Transform child in ExitSouth.transform)    child.gameObject.SetActive(false);
        if (West)   foreach (Transform child in ExitWest.transform)     child.gameObject.SetActive(false);
    }
}
