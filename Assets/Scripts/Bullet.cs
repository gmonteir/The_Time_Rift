using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        /**************Amy************/ 
        Vector3 lTemp = enemy.transform.localScale;
        if (lTemp.x > 0)

        {
            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = transform.right * speed * -1;
        }
    }
        /////////////////////////////
}
