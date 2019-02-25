using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public Transform Player;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;
    public GameObject bullet;
    public Transform shotSpawn;
    public float bulletSpeed;

    public float fireRate;
    public float nextFire = 0;


    private float total_fire_time;
    private Rigidbody2D rbb; 

    void Start()
    {
        rbb = bullet.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lTemp = transform.localScale;
        if (Vector3.Distance(transform.position, Player.position) >= MinDist && 
            Vector3.Distance(transform.position, Player.position) <= MaxDist)
        {
            //enemy move right
            if (transform.position.x < (Player.position.x))
            {
                transform.position = new Vector3(transform.position.x + (MoveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
                //if enemy facing left, start facing right 
                if (lTemp.x < 0)
                {
                    lTemp.x *= -1;
                    transform.localScale = lTemp;
                }
                //transform.localScale *= -1; 
            }
            //enemy move left
            else
            {
                transform.position = new Vector3(transform.position.x + (-MoveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
                //if enemy facing right, start facing left
                if (lTemp.x > 0)
                {
                    lTemp.x *= -1;
                    transform.localScale = lTemp;
                }
            }
        }
        /****Amy*****/
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        } 
    }
}
