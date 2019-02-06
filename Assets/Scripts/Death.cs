﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Death_Time()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            if (this.gameObject.name == "Enemy")
            {
                this.GetComponent<Enemy_AI>().enabled = false;
            }
            StartCoroutine(Death_Time());
            
        }
    }
}
