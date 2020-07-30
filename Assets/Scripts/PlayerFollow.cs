using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private Transform PlayerTransform;
    public float cameraZoom = 5.0f;

    void Start()
    {
        PlayerTransform = GameObject.Find("Player").transform;
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 20) / cameraZoom);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, transform.position.z);
    }
}
