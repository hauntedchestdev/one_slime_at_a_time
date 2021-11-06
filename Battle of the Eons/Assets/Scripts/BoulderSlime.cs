using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSlime : MonoBehaviour
{
    public GameObject smashEffect;
    public GameObject body;
    public PhysicsMaterial2D bouncy;
    // Start is called before the first frame update
    void OnEnable()
    {
        if(!body.GetComponent<PlayerMovement>().boulderSlimeOn) return;
        body.GetComponent<PlayerMovement>().boulderSlimeOn = true;
        body.GetComponent<Rigidbody2D>().sharedMaterial = bouncy;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(smashEffect, transform.position, transform.rotation);
        Destroy(effect, 1);
    }
    private void Update(){
        if(Input.GetButtonDown("Special") && !body.GetComponent<PlayerMovement>().boulderSlimeOn){
            StartCoroutine(boulderSlam(10));
        }
    }
    private IEnumerator boulderSlam(float time){
        Debug.Log("haha funny slime boulder funny");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (mousePos - transform.position);
        dir.z = 0;
        Vector3 dirNormalized = dir.normalized;
        GameObject effect = Instantiate(smashEffect, transform.position, transform.rotation);
        Destroy(effect, 1);
        body.GetComponent<Rigidbody2D>().velocity = dirNormalized * 20;
        body.GetComponent<PlayerMovement>().boulderSlimeOn = true;
        body.GetComponent<Rigidbody2D>().sharedMaterial = bouncy;
        yield return new WaitForSeconds(time);
        body.GetComponent<PlayerMovement>().boulderSlimeOn = false;
        body.GetComponent<Rigidbody2D>().sharedMaterial = null;
    }
}
