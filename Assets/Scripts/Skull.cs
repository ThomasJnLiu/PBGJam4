using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    public Animator animator;
    public bool playerHere = false;
    public bool playerSpotted = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            EnemyChangePath.instance.SetLocation();
            playerHere = true;
            if(other.gameObject.tag == "Player"){
                Debug.Log("found player");
                animator.SetFloat("PlayerVisionTime", 1f);
            }
            StartCoroutine("PlayerCountdown");
        }

    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            StopCoroutine("PlayerCountdown");
            if(other.gameObject.tag == "Player"){
                Debug.Log("player left");
                if(!playerSpotted){
                    animator.SetFloat("PlayerVisionTime", 0f);
                }
                playerHere = false;
            }
        }

    }
    public IEnumerator PlayerCountdown(){
        switch(PlayerController.instance.score){
            case 0:
                Debug.Log("0");
                yield return new WaitForSeconds(2f);
                break;   
            case 1:
                Debug.Log("1");
                yield return new WaitForSeconds(1.8f);
                break;               
            case 2:
                Debug.Log("2");
                yield return new WaitForSeconds(1.6f);
                break;   
            case 3:
                Debug.Log("3");
                yield return new WaitForSeconds(1.4f);
                break;            
            case 4:
                Debug.Log("4");
                yield return new WaitForSeconds(1.2f);
                break;
            case 5:
                Debug.Log("5");
                yield return new WaitForSeconds(1.0f);
                break;
            default:
            break;
        }

        // 2 when easiest, 1.1 when hardest
        PlayerCheck();
    }

    private void PlayerCheck(){
        if(playerHere && !playerSpotted){
            Debug.Log("player spotted");
            playerSpotted = true;
            GetComponent<AudioSource>().Play();
            GameManager.instance.playerSpotted = true;
            animator.SetFloat("PlayerVisionTime", 2f);
            // StartCoroutine("StopAnimation");
            GameManager.instance.AlertMusic();
        }
    }

    // public IEnumerator StopAnimation(){
    //     yield return new WaitForSeconds(3f);
    //     animator.SetFloat("PlayerVisionTime", 0f);
    //     playerSpotted = false;
    //     GameManager.instance.playerSpotted = false;
    // }
    // private void OnCollisionEnter2D(Collision2D other){
    //     Debug.Log("found player");
    //     if(other.gameObject.tag == "Player"){
    //         Debug.Log("found player");
    //         animator.SetFloat("PlayerVisionTime", 1f);
    //     }
    // }
}
