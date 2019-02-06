using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;
    public GameObject bullet;
    public Transform shotSpawn;

    public float fireRate;
    private float total_fire_time;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            if (transform.position.x < Player.position.x)
            {
                transform.position = new Vector3(transform.position.x + (MoveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x + (-MoveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (Time.time > total_fire_time)
            {
                total_fire_time = Time.time + fireRate;
                Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

            }
        }
    }
}
