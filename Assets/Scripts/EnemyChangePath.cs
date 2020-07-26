using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyChangePath : MonoBehaviour
{
    public GameObject enemy;
    public Transform location;

    public bool chasingPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        enemy.GetComponent<AIDestinationSetter>().enabled = false;
    }   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(!chasingPlayer){
                enemy.GetComponent<Patrol>().enabled = false;
                enemy.GetComponent<AIDestinationSetter>().enabled = true;
                enemy.GetComponent<AIDestinationSetter>().target = location;
                Debug.Log("chasing player");
                chasingPlayer = true;
            }else{
                enemy.GetComponent<Patrol>().enabled = true;
                enemy.GetComponent<AIDestinationSetter>().enabled = false;
                Debug.Log("not chasing player");

                chasingPlayer = false;
            }
        }
    }
}
