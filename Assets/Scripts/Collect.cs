using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public static bool seed;
    public static bool plant;
    public static bool egg;

    void Start()
    {
        seed = false;
        plant = false;
        egg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            plant = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seed"))
        {
            other.gameObject.SetActive(false);
            seed = true;
        }
        if (other.gameObject.CompareTag("Egg"))
        {
            other.gameObject.SetActive(false);
            egg = true;
        }

    }

}
