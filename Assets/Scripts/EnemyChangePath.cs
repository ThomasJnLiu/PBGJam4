using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyChangePath : MonoBehaviour
{
    public static EnemyChangePath instance;
    public GameObject enemy;
    public Transform location;
    public GameObject tempLocation;

    public bool chasingPlayer = false;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            // A unique case where the Singleton exists but not in this scene
            if (instance.gameObject.scene.name == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
    }

    void Start()
    {
        enemy.GetComponent<AIDestinationSetter>().enabled = false;
    }   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V)){
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

        if(GameManager.instance.playerSpotted){
                enemy.GetComponent<AIPath>().maxSpeed=8f;
                enemy.GetComponent<Patrol>().enabled = false;
                enemy.GetComponent<AIDestinationSetter>().enabled = true;
                enemy.GetComponent<AIDestinationSetter>().target = tempLocation.transform;
                Debug.Log("going to " + tempLocation);
                chasingPlayer = true;
        }

        if(chasingPlayer && enemy.GetComponent<AIPath>().reachedDestination){
                enemy.GetComponent<AIPath>().maxSpeed=3f;
                enemy.GetComponent<Patrol>().enabled = true;
                enemy.GetComponent<AIDestinationSetter>().enabled = false;
                Debug.Log("not chasing player");

                chasingPlayer = false;
        }
        
    }

    public void SetLocation(){
        Debug.Log("setting location");
        tempLocation.transform.position = location.position;

    }
}
