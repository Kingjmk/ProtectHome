using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public GameObject Player;
    public GameObject Base;

    void Start()
    {
        Player = this.gameObject;
        Base = GameObject.FindGameObjectWithTag("BASE");

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * 0.1f;
        float y = Input.GetAxis("Vertical")* 0.1f;

        transform.Translate(Vector3.right * x);
        transform.Translate(Vector3.up * y);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-5,5),Mathf.Clamp(transform.position.y,-4.5f,5),0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ENEMY"){
            Base.GetComponent<Base>().AddScore();
            Destroy(other.gameObject,0f);
        }
    }    
}
