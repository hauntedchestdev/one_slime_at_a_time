using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSlime : MonoBehaviour
{
    public GameObject body;
    public PhysicsMaterial2D bouncy;
    // Start is called before the first frame update
    void OnEnable()
    {
        body.GetComponent<PlayerMovement>().boulderSlimeOn = true;
        body.GetComponent<Rigidbody2D>().sharedMaterial = bouncy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
