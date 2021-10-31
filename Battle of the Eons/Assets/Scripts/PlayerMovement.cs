using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //Summoning Variables
    [SerializeField] GameObject summonUI;
    [SerializeField] InputField summonInput;
    [SerializeField] GameObject[] slimes;
    [SerializeField] string[] slimeNames;

    public float moveSpeed;
    private bool canMove = true;

    public Rigidbody2D rb;
    public Animator am;

    Vector2 movement;

    void Start(){
        ActivateSlimes("slime");
    }

    // Start is called before the first frame update
    void Update()
    {
        canMove = !summonUI.activeSelf;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        am.SetFloat("Horizontal", movement.x);
        am.SetFloat("Vertical", movement.y);
        am.SetFloat("Speed", movement.sqrMagnitude);

        //Summoning
        if (Input.GetButtonDown("Summon"))
        {
            summonUI.SetActive(!summonUI.activeSelf);
            summonInput.Select();
            summonInput.ActivateInputField();
            summonInput.text = "";
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(canMove){
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void DeactivateSlimes(){
        if(GameObject.Find("Base Slime"))
            GameObject.Find("Base Slime").GetComponent<BaseSlime>().Combine(true);
        for(int i = 0; i < slimes.Length; i++){
            slimes[i].SetActive(false);
        }
    }

    private void ActivateSlimes(string name){
        DeactivateSlimes();
        bool slimeActive = false;
        for(int i = 0; i < slimes.Length; i++){
            if(slimeNames[i] == name){
                slimeActive = true;
                slimes[i].SetActive(true);
                break;
            }
        }
        if(!slimeActive)
            slimes[0].SetActive(true);
    }

    public void InputSummon(){
        ActivateSlimes(summonInput.text.ToLower());
    }


}
