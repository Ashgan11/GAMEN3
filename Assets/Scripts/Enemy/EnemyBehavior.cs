using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject player;
    private Rigidbody RB;
    public float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, direction, out hit)){            
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject == player) {
                //Debug.Log("Alert");
                FollowPlayer(direction);
            }
            else {
                //Debug.Log("Calm");
            }
        }

        //Raycast to player
        //TRUE
            //Move and shoot toward player
        //FALSE
            //Move to random location
    }

    void MoveToRandomLocation(){

    }

    void FollowPlayer(Vector3 direction){
        RB.AddForce(direction*speed,ForceMode.Force);
        Vector3 lookPos = new Vector3( player.transform.position.x, this.transform.position.y, player.transform.position.z);
        transform.LookAt(lookPos);
    }

    void AttackPlayer(){

    }
}
