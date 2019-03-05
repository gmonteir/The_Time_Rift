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

    void Start()
    {
        world1Tiles = GameObject.FindGameObjectWithTag("World1");
        world2Tiles = GameObject.FindGameObjectWithTag("World2");
        world1Back = GameObject.FindGameObjectWithTag("Background1");
        world2Back = GameObject.FindGameObjectWithTag("Background2");

        World1Active();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeDelay)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("world1");
                World1Active();
                timeDelay = Time.time + timeTravelRate;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("world2");
                World2Active();
                timeDelay = Time.time + timeTravelRate;
            }
        }
    }

    private void World1Active()
    {
        world1Tiles.SetActive(true);
        world1Back.SetActive(true);

        World2Deactive();
    }

    private void World1Deactive()
    {
        world1Tiles.SetActive(false);
        world1Back.SetActive(false);
    }

    private void World2Active()
    {
        world2Tiles.SetActive(true);
        world2Back.SetActive(true);

        World1Deactive();
    }

    private void World2Deactive()
    {
        world2Tiles.SetActive(false);
        world2Back.SetActive(false);
    }
}
