using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject BASE;
    void Start(){
        BASE = GameObject.FindGameObjectWithTag("BASE");
    }
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position,BASE.transform.position,0.01f);        
    }
 
}
