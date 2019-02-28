using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bullet;
    private Rigidbody2D rb;
    public float speed;
    public Transform shotSpawn; 

    // Start is called before the first frame update
    void Start()
    {
        rb = bullet.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(wait()); 
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);

    }
}
