using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Base : MonoBehaviour
{
    public int Hits = 0;
    public int Score = 0;
    public float multiplayer = 1;
    public bool gameended = false;

    public GameObject EnemyPrefab;
    public TextMeshProUGUI text;

    void Start(){
        InvokeRepeating("CreateEnemies",1f,2f);
        text = GameObject.FindGameObjectWithTag("TEXTBOX").GetComponent<TextMeshProUGUI>();
        text.SetText("0");
    }
    void FixedUpdate()
    {
        if(Hits > 3){
            Endgame();
        }

        if(Input.GetKey(KeyCode.Escape)){
            ExitGame();
        }

        //Update 
        if(!gameended){
            text.SetText("" + Score);
        }
    }

    void Endgame(){
        Debug.Log("End Game");
        Destroy(GameObject.Find("PLAYER"));
        Time.timeScale = 0;
        gameended = true;
        //EXIT GAME
        text.SetText("GAMEOVER");
        Invoke("ExitGame",6);
    }

    void ExitGame(){
        Application.Quit();
    }

    void CreateEnemies(){
        var side = (Random.value > 0.5)? true: false;
        float xpos =(Random.value > 0.5)? -5 : 5;
        float ypos =(Random.value > 0.5)? -5 : 5;
        

        for(int i =1;i <= Mathf.Floor(multiplayer);i++){
            if(side){
                xpos =(Random.value > 0.5)? -5 : 5;
                ypos = Random.value  * ((Random.value > 0.5f) ? -5f : 5f);
            } else {
                xpos = Random.value * ((Random.value > 0.5f) ? -5f : 5f);
                ypos =(Random.value > 0.5)? -5 : 5;
            }
            var temp = Instantiate(EnemyPrefab,new Vector3(xpos,ypos,0),EnemyPrefab.transform.rotation);  
        }      
        if(multiplayer < 10){
            multiplayer+=0.1f;
        }

    }   

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ENEMY"){
            Hits++;
            Destroy(other.gameObject,0f);
        }
    }
    public void AddScore(){
        Score++;
        Debug.Log("+1 Score");

    }
}
