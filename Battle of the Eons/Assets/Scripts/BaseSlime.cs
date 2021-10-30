using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSlime : MonoBehaviour
{
    public bool split = false;
    public GameObject splitSlime;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Special") && !split){
            SplitSlime();
        }
    }

    private void SplitSlime() {
        split = true;
        Vector2 spawnPos = new Vector2(transform.position.x + 1, transform.position.y + 1);
        Instantiate(splitSlime, spawnPos, transform.rotation);
    }

    public void Combine(){
           split = false;
           Destroy(GameObject.Find("Split Slime(Clone)")); 
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Split Slime(Clone)")
            Combine();
    }
}
