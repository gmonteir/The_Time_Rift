using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class note_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject note;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("Setting Actice");
        if (other.CompareTag("Player"))
        { 
            note.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //print("Deactivating");
        if (other.CompareTag("Player"))
        {
            note.SetActive(false);
        }

    }
}
