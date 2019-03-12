using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* @author: Kevin Graves
 * 
 * 
 * 
 */ 

public class New_Boss_Mechanics : MonoBehaviour
{
    public GameObject egg;
    public Transform drop_location;
    public int drop_rate;
    public Vector3 pos1;
    public Vector3 pos2;
    public float speed = 1.0f;
    public int phase1_boss_hp = 10;

    public int phase2_boss_hp = 10;
    public Vector3 phase2_pos1;
    public Vector3 phase2_pos2;
    public Vector3 phase2_pos3;
    public Vector3 phase2_pos4;
    public Vector3 moving_Towards;
    public float phase2_speed = 1.0f;
    public float phase2_transition_speed = 1.0f;

    public Vector3 phase3_pos1;
    public Vector3 phase3_pos2;
    public float phase3_speed = 1.0f;
    public int phase3_boss_hp = 10;
    public float phase3_transition_speed = 1.0f;


    private int phase;
    private int count;
    private bool phase2_start = true;
    private GameObject Phase_1_Walls;
    private GameObject Phase_2_Walls;
    private bool left;
    private float t1;

    private bool phase3_start = true;

    void Start()
    {
        phase = 1;
        Phase_1_Walls = GameObject.FindGameObjectWithTag("Phase 1");
        Phase_2_Walls = GameObject.FindGameObjectWithTag("Phase 2");

    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 1)
            Phase_1();
        if (phase == 2)
            Phase_2();
        if (phase == 3)
            Phase_3();
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && phase == 1)
        {
            phase1_boss_hp -= 1;
        }
        if (collision.gameObject.tag == "Bullet" && phase == 2)
        {
            phase2_boss_hp -= 1;
        }

    }

    private void Phase_1()
    {
        if (phase1_boss_hp <= 0)
        {
            phase = 2;
        }
        else
        {
            count++;
            if (count >= drop_rate)
            {
                Instantiate(egg, drop_location.position, drop_location.rotation);
                count = 0;
            }
            transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
        }
    }

    private void Phase_2()
    {
        //move boss to new area
        if (phase2_start)
        {
            float step = Time.time * phase2_transition_speed;
            transform.position = Vector3.MoveTowards(transform.position, phase2_pos1, step);
            if (transform.position == phase2_pos1)
            {
                phase2_start = false;
                Phase_1_Walls.SetActive(false);
                moving_Towards = phase2_pos2;
                left = true;
                t1 = Time.time;
            }
        }
        //start of new mechanics
        else
        {
            float step2 = (Time.time - t1) * phase2_speed;
            if (moving_Towards == phase2_pos1)
            {
                transform.position = Vector3.MoveTowards(transform.position, moving_Towards, step2);
                if (transform.position == moving_Towards)
                {
                    if (left)
                        moving_Towards = phase2_pos2;
                    else
                    {
                        moving_Towards = phase2_pos2;
                        left = true;
                    }
                }

            }

            else if (moving_Towards == phase2_pos2)
            {
                transform.position = Vector3.MoveTowards(transform.position, moving_Towards, step2);
                if (transform.position == moving_Towards)
                {
                    if (left)
                        moving_Towards = phase2_pos3;
                    else
                        moving_Towards = phase2_pos1;
                }

            }
            else if (moving_Towards == phase2_pos3)
            {
                transform.position = Vector3.MoveTowards(transform.position, moving_Towards, step2);
                if (transform.position == moving_Towards)
                {
                    if (left)
                        moving_Towards = phase2_pos4;
                    else
                        moving_Towards = phase2_pos2;
                }

            }
            else if (moving_Towards == phase2_pos4)
            {
                transform.position = Vector3.MoveTowards(transform.position, moving_Towards, step2);
                if (transform.position == moving_Towards)
                {
                    if (left)
                    {
                        moving_Towards = phase2_pos3;
                        left = false;
                    }
                    else
                        moving_Towards = phase2_pos3;
                }

            }

        }
        if (phase2_boss_hp <= 0)
        {
            phase = 3;
        }
    }

    private void Phase_3()
    {
        if (phase3_start)
        {
            float step = Time.time * phase3_transition_speed;
            transform.position = Vector3.MoveTowards(transform.position, phase3_pos1, step);
            if (transform.position == phase3_pos1)
            {
                phase3_start = false;
                Phase_2_Walls.SetActive(false);
            }
        }
    }

}
