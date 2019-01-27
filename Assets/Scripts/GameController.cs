using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private  GameObject[] World1GameObjects;
    private  GameObject[] World2GameObjects;
    void Start()
    {
        World1GameObjects = GameObject.FindGameObjectsWithTag("World 1");
        World2GameObjects = GameObject.FindGameObjectsWithTag("World 2");
        World1Active();
        World2Deactive();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            World1Active();
            World2Deactive();
            BackgroundColorChange.instance.World1Color();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            World2Active();
            World1Deactive();
            BackgroundColorChange.instance.World2Color();
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
}
