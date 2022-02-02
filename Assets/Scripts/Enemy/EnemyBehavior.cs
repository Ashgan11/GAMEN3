using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject player;
    private Rigidbody RB;    
    public GameObject bullet;
    public float speed = 100;
    public float attackSpeed = 1f;
    private float lastFire = 0;

    public float moveInterval = 6f;
    private float lastMove = 0;
    private Vector3 randomMoveDirection = new Vector3();
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
            if (hit.collider.gameObject == player) {
                FollowPlayer(direction);
                AttackPlayer(direction);
                //MoveToRandomLocation();
            }
            else {
                MoveToRandomLocation();
            }
        }
    }

    void MoveToRandomLocation(){
        //Vector3 moveDirection = new Vector3();
        if (lastMove + moveInterval <= Time.time || lastMove == 0){
            randomMoveDirection = new Vector3(Random.value*2-1, 0, Random.value*2-1);
            lastMove = Time.time;
        }
        RB.AddForce(randomMoveDirection*speed*0.75f*Time.timeScale, ForceMode.Force);
        
        //Debug.Log(randomMoveDirection);

        Vector3 lookPos = new Vector3(randomMoveDirection.x, this.transform.position.y, randomMoveDirection.z);
        transform.LookAt(lookPos);
    }

    void FollowPlayer(Vector3 direction){
        Vector3 moveDirection = new Vector3(direction.x, 0, direction.z);
        RB.AddForce(moveDirection*speed*Time.timeScale, ForceMode.Force);

        Vector3 lookPos = new Vector3( player.transform.position.x, this.transform.position.y, player.transform.position.z);
        transform.LookAt(lookPos);
    }

    void AttackPlayer(Vector3 direction){
        if (lastFire + attackSpeed <= Time.time){
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            Physics.IgnoreCollision(newBullet.GetComponent<Collider>(), GetComponent<Collider>());

            Vector3 bulletForce = new Vector3(direction.x*100, 10, direction.z*100);
            newBullet.GetComponent<Rigidbody>().AddForce(bulletForce, ForceMode.Impulse);
            newBullet.GetComponent<BulletBehavior>().setPlayer(player);
            lastFire = Time.time;
        }        
    }
}
