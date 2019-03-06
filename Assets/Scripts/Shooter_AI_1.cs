using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_AI_1 : MonoBehaviour
{
    public Transform Player;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 7;
    public GameObject bullet_right;
    public GameObject bullet_left;
    public Transform shotSpawn;
    public float bulletSpeed;

    public float fireRate;
    public float nextFire = 0;


    private float total_fire_time;
    private Rigidbody2D rbb;
    //private Animator anim;
    private bool facingRight = true;

    void Start()
    {
        rbb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>(); 
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
                rbb.velocity = new Vector3(MoveSpeed, 0, 0);
                //if enemy facing left, start facing right 
                if (lTemp.x < 0)
                {
                    lTemp.x *= -1;
                    transform.localScale = lTemp;
                    facingRight = true;
                }
            }
            //enemy move left
            else
            {
                rbb.velocity = new Vector3(-MoveSpeed, 0, 0);
                //if enemy facing right, start facing left
                if (lTemp.x > 0)
                {
                    lTemp.x *= -1;
                    transform.localScale = lTemp;
                    facingRight = false;
                }
            }

            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                StartCoroutine(wait());
                //anim.SetTrigger("Shoot"); 
                if (facingRight)
                {
                    Instantiate(bullet_right, shotSpawn.position, shotSpawn.rotation);
                }
                else
                {
                    Instantiate(bullet_left, shotSpawn.position, shotSpawn.rotation);
                }
            }
        }
    }

    //If enemy gets shot by player's bullet 
    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f); 
    }
}
