using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject world1Tiles;
    private GameObject world2Tiles;
    private GameObject world1Back;
    private GameObject world2Back;
    public float timeTravelRate;
    private float timeDelay;
    private GameObject tree;
    private GameObject seed;
    private GameObject egg;
    private GameObject egg2;
    private GameObject sword;
    private GameObject sword2;
    private GameObject gate;
    private bool egg_placed = false;
    private GameObject world1Text;
    private GameObject world2Text;
    private bool world1;
    private bool world2;

    void Start()
    {
        world1Tiles = GameObject.FindGameObjectWithTag("World1");
        world2Tiles = GameObject.FindGameObjectWithTag("World2");
        world1Back = GameObject.FindGameObjectWithTag("Background1");
        world2Back = GameObject.FindGameObjectWithTag("Background2");
        world1Text = GameObject.FindGameObjectWithTag("World 1");
        world2Text = GameObject.FindGameObjectWithTag("World 2");

        tree = GameObject.Find("Tree");
        seed = GameObject.Find("Seed");
        egg = GameObject.Find("Egg");
        egg2 = GameObject.Find("Egg2");
        sword = GameObject.Find("Sword");
        sword2 = GameObject.Find("Sword2");
        gate = GameObject.Find("Gate");
        World1Active();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Time.time > timeDelay)
        //{
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (world2)
                {
                    Debug.Log("world1");
                    World1Active();
                    timeDelay = Time.time + timeTravelRate;
                }
                else
                {
                    Debug.Log("world2");
                    World2Active();
                    timeDelay = Time.time + timeTravelRate;
                }
            }
        //}

        //if (Collect.plant == true && Collect.egg == true && !egg_placed)
        //{
        //    egg.SetActive(true);
        //    egg.transform.Translate(GameObject.Find("Player 1 With Shooting").transform.position.x + 2, 0, 0);
        //    egg_placed = true;
        //}
        if (world1 == true && Collect.plant == true && Collect.egg == true)
        {
            egg2.SetActive(true);
        }
        if (world2 == true && Collect.plant == true && Collect.sword == true)
        {
            sword2.SetActive(true);
        }
        if(Collect.plant == true && Collect.egg == true && Collect.sword == true)
        {
            gate.SetActive(false);
        }
    }

    private void World1Active()
    {
        world1Tiles.SetActive(true);
        world1Back.SetActive(true);
        world1Text.SetActive(true);
        world1 = true;
        if (Collect.seed == false)
        {
            seed.SetActive(true);
        }
        if (Collect.sword == false)
        {
            sword.SetActive(true);
        }
        if (Collect.plant == true && Collect.egg == true)
        {
            egg2.SetActive(true);
        }
        World2Deactive();
    }

    private void World1Deactive()
    {
        world1Tiles.SetActive(false);
        world1Back.SetActive(false);
        seed.gameObject.SetActive(false);
        sword.gameObject.SetActive(false);
        world1Text.SetActive(false);
        egg2.SetActive(false);
        world1 = false;

    }

    private void World2Active()
    {
        world2Tiles.SetActive(true);
        world2Back.SetActive(true);
        world2Text.SetActive(true);
        world2 = true;

        if (Collect.plant == true && Collect.seed == true)
        {
            tree.SetActive(true);
            //tree.transform.Translate(GameObject.Find("Player").transform.position.x + 2, 3, 0);
        }
        if (Collect.egg == false)
        {
            egg.SetActive(true);
        }
        if (Collect.plant == true && Collect.sword == true)
        {
            sword2.SetActive(true);
        }

        World1Deactive();
    }

    private void World2Deactive()
    {
        world2Tiles.SetActive(false);
        world2Back.SetActive(false);
        tree.gameObject.SetActive(false);
        world2Text.SetActive(false);
        egg.SetActive(false);
        sword2.SetActive(false);
        world2 = false;
    }
}
