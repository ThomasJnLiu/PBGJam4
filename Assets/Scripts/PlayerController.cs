using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput controls;
    float speed = 5f;
    private Rigidbody2D playerRb;
    void Awake(){
        controls = new PlayerInput();
        controls.Enable();

        // add callback function to action
        controls.Player.Horizontal.performed += _ => Move();
        controls.Player.Vertical.performed += _ => Move();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        Debug.Log(controls.Player.Horizontal.ReadValue<float>());
        Debug.Log(controls.Player.Vertical.ReadValue<float>());

        playerRb.velocity = new Vector2(controls.Player.Horizontal.ReadValue<float>() * speed, controls.Player.Vertical.ReadValue<float>() * speed);
    }

    public void Fire(InputAction.CallbackContext context){
        Debug.Log("test");
    }

    public void Move(){
        Debug.Log("move");
    }
}
