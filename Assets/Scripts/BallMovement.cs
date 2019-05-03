using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 velocity;

    void Start()
    {
        Find();
    }

    void Find(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        velocity = rb.velocity;
    }

    public void PlayerStart(bool queue){
        if(queue){
            GetComponent<Rigidbody>().velocity = new Vector3(Values.ballSpeed,Random.Range(-Values.ballSpeed, Values.ballSpeed),0);
        } else {
            GetComponent<Rigidbody>().velocity = new Vector3(-Values.ballSpeed,Random.Range(-Values.ballSpeed, Values.ballSpeed),0);
        }
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Left" || col.gameObject.tag == "Right"){
            if(col.gameObject.tag == "Left"){
                transform.position = new Vector3(0,0,0);
                rb.velocity = new Vector3(0,0,0);
                Values.player2score += 20;
                Values.queue = !Values.queue;
                Values.started = false;
                Values.ballSpeed = 15; 
            }

            if(col.gameObject.tag == "Right"){
                transform.position = new Vector3(0,0,0);
                rb.velocity = new Vector3(0,0,0);
                Values.player1score += 20;
                Values.queue = !Values.queue;
                Values.started = false;
                Values.ballSpeed = 15;
            }
        } else {
            if(col.gameObject.tag == "Player"){
                Values.ballSpeed += 1;
            }
            var direction = Vector3.Reflect(velocity.normalized, col.contacts[0].normal);
            rb.velocity = direction * Values.ballSpeed;
        }
    }
}
