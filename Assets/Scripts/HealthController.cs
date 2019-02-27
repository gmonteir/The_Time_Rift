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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player gets shot by an enemy bullet
        if (collision.gameObject.tag == "Bullet")
        {
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
    }

}
