using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter_bullets : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject right_bullet;
    public Transform right_shotSpawn;
    public GameObject left_bullet;
    public Transform left_shotSpawn;
    public float fireRate;
    private bool facing_Right = true;

    private float fire;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) | Input.GetKeyDown(KeyCode.RightArrow))
        {
            facing_Right = true;
        }
        if (Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.LeftArrow))
        {
            facing_Right = false;
        }

        if ((Input.GetKeyDown(KeyCode.F) | Input.GetKeyDown(KeyCode.Space)) && Time.time > fire)
        {
            if (facing_Right)
            {
                fire = Time.time + fireRate;
                Instantiate(right_bullet, right_shotSpawn.position, right_shotSpawn.rotation);
            }
            else if (!facing_Right)
            {
                fire = Time.time + fireRate;
                Instantiate(left_bullet, left_shotSpawn.position, left_shotSpawn.rotation);
            }
        }

    }
}
