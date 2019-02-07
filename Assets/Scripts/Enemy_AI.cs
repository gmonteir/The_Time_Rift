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
    public float offset;

    public float fireRate;
    private float total_fire_time;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) >= MinDist && 
            Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            //enemy move right
            if (transform.position.x < (Player.position.x - offset))
            {
                transform.position = new Vector3(transform.position.x + (MoveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            }
            //enemeny move left
            else
            {
                transform.position = new Vector3(transform.position.x + (-MoveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
            }
        }
        else
        {
            if (Time.time > total_fire_time && shotSpawn != null && bullet != null)
            {
                total_fire_time = Time.time + fireRate;
                Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

            }
        }
    }
}
