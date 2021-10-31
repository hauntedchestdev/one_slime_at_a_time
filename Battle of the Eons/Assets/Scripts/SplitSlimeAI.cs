using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitSlimeAI : MonoBehaviour
{
    public GameObject combineEffect;
    public float speed;
    private Transform player;
    public float maxDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Base Slime").transform;
        GameObject effect = Instantiate(combineEffect, transform.position, transform.rotation);
        Destroy(effect,1);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if(distance > maxDistance)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
