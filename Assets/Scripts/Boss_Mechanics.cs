using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Mechanics : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject egg;
    public Transform drop_location;
    public int drop_rate;
    public Vector3 pos1;
    public Vector3 pos2;
    public float speed = 1.0f;
    public int boss_hp = 10;

    private int count;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boss_hp <= 0)
        {
            Destroy(this.gameObject);
        }

        count++;
        if (count >= drop_rate)
        {
            Instantiate(egg, drop_location.position, drop_location.rotation);
            count = 0;
        }
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            boss_hp -= 1;
        }
    }
}
