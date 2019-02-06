using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter_bullets : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public Transform shotSpawn;
    public float fireRate;

    private float fire;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time > fire)
        {
            fire = Time.time + fireRate;
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        }

    }
}
