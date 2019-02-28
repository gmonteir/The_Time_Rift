using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private bool isWalking = false; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("up"))
        {
            anim.SetTrigger("Jump"); 
        }

        if (Input.GetKey("right") || Input.GetKey("left")) 
        {
            anim.SetTrigger("Walk"); 
          
        }

        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("Shoot");
        }
    }
}
