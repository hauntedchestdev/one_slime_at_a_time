using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntedSlimeControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Defence")){
            StartCoroutine(Ghost());
        }
    }

    IEnumerator Ghost(){
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
