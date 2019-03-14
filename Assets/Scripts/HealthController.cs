using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public ProgressBar pb;
    public int bullet_damage;
    public int egg_damage;
    public int boss_collision_damage;
    public int small_dino_collision_damage;
    public int knight_damage;
    public float hazard_damage;
    public int heart_healing;

    // Start is called before the first frame update
    void Start()
    {
        pb.BarValue = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if (pb.BarValue <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (pb.BarValue >= 100)
        {
            pb.BarValue = 100;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player gets shot by an enemy bullet
        if (collision.gameObject.tag == "Bullet")
        {
            print("got here");
            pb.BarValue -= bullet_damage;
            Destroy(collision);
        }
        if (collision.gameObject.tag == "Boss_Egg")
        {
            pb.BarValue -= egg_damage;
            Destroy(collision);
        }
        if (collision.gameObject.tag == "Boss_1")
        {
            pb.BarValue -= boss_collision_damage;
        }
        if (collision.gameObject.tag == "Kill")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (collision.gameObject.tag == "Small_Dino_Flying")
        {
            pb.BarValue -= small_dino_collision_damage;
        }
        if (collision.gameObject.tag == "Knight")
        {
            pb.BarValue -= knight_damage;
        }
        if (collision.gameObject.tag == "Heart")
        {
            Debug.Log("here");
            pb.BarValue += heart_healing;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazards")
        {
            pb.BarValue -= hazard_damage;
        }
    }
}
