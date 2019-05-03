using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public bool player = true;
    public BallMovement ball;
    public Text scoreText1, scoreText2;
    public Transform scorePanel1, scorePanel2;
    public int score;

    void Start()
    {
        Find();
    }

    void Find(){
        ball = GameObject.Find("Ball").GetComponent<BallMovement>();
        scorePanel1 = GameObject.Find("Panel 1").transform;
        scorePanel2 = GameObject.Find("Panel 2").transform;
        scoreText1 = scorePanel1.GetChild(0).GetComponent<Text>();
        scoreText2 = scorePanel2.GetChild(0).GetComponent<Text>();
    }

    void Update()
    {
        MovePlayer();
        UpdateScore();
        SetQueueColor();
    }

    void SetQueueColor(){
        if(Values.queue){
            scorePanel1.GetComponent<Image>().color = new Color(0,1,0,0.8f);
            scorePanel2.GetComponent<Image>().color = new Color(1,1,1,0.33f);
        } else {
            scorePanel2.GetComponent<Image>().color = new Color(0,1,0,0.8f);
            scorePanel1.GetComponent<Image>().color = new Color(1,1,1,0.33f);
        }
    }

    void UpdateScore(){
        if(player){
            scoreText1.text = "Score : " + Values.player1score;
        } else {
            scoreText2.text = "Score : " + Values.player2score;
        }
    }

    void MovePlayer(){
        if(!Values.started && Input.GetKey(KeyCode.Return)){
            ball.PlayerStart(Values.queue);
            Values.started = true;
        }

        if(player){
            if(Input.GetKey(KeyCode.UpArrow)){
                Vector3 pos = transform.position;
                transform.position = new Vector3(pos.x, Mathf.Clamp(pos.y + Values.playerSpeed, -8.5f, 8.5f), pos.z);
            } else if(Input.GetKey(KeyCode.DownArrow)){
                Vector3 pos = transform.position;
                transform.position = new Vector3(pos.x, Mathf.Clamp(pos.y - Values.playerSpeed, -8.5f, 8.5f), pos.z);
            }
        } else {
            if(Input.GetKey(KeyCode.W)){
                Vector3 pos = transform.position;
                transform.position = new Vector3(pos.x, Mathf.Clamp(pos.y + Values.playerSpeed, -8.5f, 8.5f), pos.z);
            } else if(Input.GetKey(KeyCode.S)){
                Vector3 pos = transform.position;
                transform.position = new Vector3(pos.x, Mathf.Clamp(pos.y - Values.playerSpeed, -8.5f, 8.5f), pos.z);
            }
        }
    }
}
