﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Collect : MonoBehaviour
{
    public static bool seed;
    public static bool plant;
    public static bool egg;
    public static bool sword;

    void Start()
    {
        seed = false;
        plant = false;
        egg = false;
        sword = false;
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
        if (other.gameObject.CompareTag("Sword"))
        {
            other.gameObject.SetActive(false);
            sword = true;
        }
        if(other.gameObject.CompareTag("End"))
        {
            Debug.Log("hi");
            SceneManager.LoadScene("Jurassic Boss"); 
        }

    }

}
