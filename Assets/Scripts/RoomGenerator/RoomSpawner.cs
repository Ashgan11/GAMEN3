using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    GameObject[,] rooms = new GameObject[4, 4];

    public GameObject roomPrefab;

    void Start(){
        Vector3 startPos = transform.position;
        Debug.Log(startPos);
        for (int i = 0; i<4; i++){
            for (int j = 0; j<4; j++){
                rooms[i,j] = Instantiate(roomPrefab, new Vector3(startPos.x+i*10, 0, startPos.z+j*10), Quaternion.identity);
    	        rooms[i,j].GetComponent<Room>().InitExits(!(j-1<0), !(i-1<0), !(j+1>3), !(i+1>3));
            }
        }
        rooms[0,0].GetComponent<Room>().InitExits(true, true, true, true);
    }
}
