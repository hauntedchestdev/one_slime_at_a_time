using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSlime : MonoBehaviour
{
    public GameObject combineEffect;
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
        float ranY = Random.Range(-0.75f,0.75f);
        float ranX = Random.Range(-0.75f,0.75f);
        ranY += ranY > 0 ? 0.5f: -0.5F;
        ranX += ranX > 0 ? 0.5f: -0.5F;
        Vector2 spawnPos = new Vector2(transform.position.x + ranX, transform.position.y + ranY);
        Instantiate(splitSlime, spawnPos, transform.rotation);
    }

    public void Combine(bool changeSlime){
            GameObject slimeKill = GameObject.Find("Split Slime(Clone)");
            if(!changeSlime){
                GameObject effect = Instantiate(combineEffect, slimeKill.transform.position, slimeKill.transform.rotation);
                Destroy(effect,1);
            }
           split = false;
           Destroy(slimeKill);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Split Slime(Clone)")
            Combine(false);
    }
}
