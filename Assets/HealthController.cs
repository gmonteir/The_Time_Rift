using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public ProgressBar pb;
    public int bullet_damage;

    // Start is called before the first frame update
    void Start()
    {
        pb.BarValue = 100;

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player gets shot by an enemy bullet
        print("got here"); 
        if (collision.gameObject.tag == "Bullet")
        {
            pb.BarValue -= bullet_damage;
            Destroy(collision);
        }
    }

}
