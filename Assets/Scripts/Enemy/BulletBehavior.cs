using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private GameObject player;
    public float damage = 10;
    public void setPlayer(GameObject player){
        this.player = player;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Collision.Equals)
    }

    void OnCollisionEnter(Collision collision){
        if(collision.collider.gameObject == player){
            player.GetComponent<PlayerLife>().changeHealth(0-damage);
        }
        Destroy(this.gameObject);
        //Debug.Log("Collide!");
    }
}
