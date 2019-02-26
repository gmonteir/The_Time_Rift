using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Death_Time()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player gets shot by an enemy bullet 
        if (collision.gameObject.tag == "Bullet")
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.gameObject.tag == "EnWrld1" | collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            if (this.gameObject.name == "Dinosaur")
            {
                this.GetComponent<Enemy_AI>().enabled = false;
            }
            StartCoroutine(Death_Time());
            
        }
        if (collision.gameObject.tag == "EnWrld1" | collision.gameObject.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }
    */
}
