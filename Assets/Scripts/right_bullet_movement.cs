﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right_bullet_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody bullet;
    void Start()
    {
        bullet =  GetComponent<Rigidbody>();
        bullet.velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}