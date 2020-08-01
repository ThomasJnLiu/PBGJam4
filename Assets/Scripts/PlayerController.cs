using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    PlayerInput controls;
    float speed = 5f;
    float totalSpeed;
        private Rigidbody2D playerRb;
    bool canSprint = true;
    public Animator animator;

    public Image sprintCircle;
    //purely for sprint circle graphic lmao
    public float sprintTimer = 500f;

    public int score = 0;

    public TextMeshProUGUI scoreText;
    void Awake(){
        controls = new PlayerInput();
        controls.Enable();

        // add callback function to action
        controls.Player.Horizontal.performed += _ => Move();
        controls.Player.Vertical.performed += _ => Move();
        controls.Player.Sprint.performed += _ => Sprint();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        totalSpeed = Mathf.Abs(playerRb.velocity.x) + Mathf.Abs(playerRb.velocity.y);
        playerRb.velocity = new Vector2(controls.Player.Horizontal.ReadValue<float>() * speed, controls.Player.Vertical.ReadValue<float>() * speed);
        animator.SetFloat("SpeedX", totalSpeed);

        if(playerRb.velocity.x < 0){
            transform.localScale = new Vector3(-1f, 1f, 1f);
        
        }
        if(playerRb.velocity.x > 0){
            transform.localScale = new Vector3(1f, 1f, 1f);
        }


    }

    public void Sprint(){
        if(canSprint){
            canSprint = false;
            animator.SetBool("Running", true);
            animator.SetFloat("AnimSpeed", 2f);
            sprintTimer = 0;
            sprintCircle.fillAmount = 0;
            StartCoroutine("RunTimer");
        }

    }

    public void Move(){
    }

    public IEnumerator RunTimer(){
        speed = 8f;
        yield return new WaitForSeconds(2f);
        animator.SetBool("Running", false);
        animator.SetFloat("AnimSpeed", 1f);
        speed = 5f;
        for(int i = 0; i < 500; i++){
            sprintTimer++;
            sprintCircle.fillAmount = sprintTimer / 500f;
            yield return new WaitForSeconds(0.01f);
        }
        
        canSprint = true;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Treasure"){
            Debug.Log("got treasure");
            score++;
            scoreText.SetText("Treasure: " + score+"/5");
            Destroy(other.gameObject);
        }
    }
}
