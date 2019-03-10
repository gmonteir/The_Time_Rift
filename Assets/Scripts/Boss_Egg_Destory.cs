using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Egg_Destory : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Bounds")
        {
            Destroy(this.gameObject);
        }
    }

}
