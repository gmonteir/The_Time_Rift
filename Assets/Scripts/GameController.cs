using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private  GameObject[] World1GameObjects;
    private  GameObject[] World2GameObjects;
    private  GameObject[] World3GameObjects;
    public float timeTravelRate;
    private float timeDelay;

    void Start()
    {
        World1GameObjects = GameObject.FindGameObjectsWithTag("World 1");
        World2GameObjects = GameObject.FindGameObjectsWithTag("World 2");
        World3GameObjects = GameObject.FindGameObjectsWithTag("World 3");
        World1Active();
        World2Deactive();
        World3Deactive();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeDelay)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                World1Active();
                World2Deactive();
                World3Deactive();
                BackgroundColorChange.instance.World1Color();
                timeDelay = Time.time + timeTravelRate;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                World2Active();
                World1Deactive();
                World3Deactive();
                BackgroundColorChange.instance.World2Color();
                timeDelay = Time.time + timeTravelRate;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                World3Active();
                World1Deactive();
                World2Deactive();
                BackgroundColorChange.instance.World3Color();
                timeDelay = Time.time + timeTravelRate;
            }
            
        }
        

    }

    private void World1Active()
    {
        for (int i = 0; i < World1GameObjects.Length; i++)
        {
            World1GameObjects[i].SetActive(true);
        }
    }

    private void World1Deactive()
    {
        for (int i = 0; i < World1GameObjects.Length; i++)
        {
            World1GameObjects[i].SetActive(false);
        }
    }

    private void World2Active()
    {
        
        for (int i = 0; i < World2GameObjects.Length; i++)
        {
            World2GameObjects[i].SetActive(true);
        }
    }

    private void World2Deactive()
    {
        for (int i = 0; i < World2GameObjects.Length; i++)
        {
            World2GameObjects[i].SetActive(false);
        }
    }

    private void World3Active()
    {

        for (int i = 0; i < World3GameObjects.Length; i++)
        {
            World3GameObjects[i].SetActive(true);
        }
    }

    private void World3Deactive()
    {
        for (int i = 0; i < World3GameObjects.Length; i++)
        {
            World3GameObjects[i].SetActive(false);
        }
    }
}
