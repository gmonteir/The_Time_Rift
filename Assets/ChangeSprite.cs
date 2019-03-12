using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{

    public Sprite newSprite;
    public SpriteRenderer rend;
    public SpriteRenderer glassRend;
    public Text story;
    public Text end; 
    // Start is called before the first frame update
    void Start()
    {
        glassRend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            Destroy(GetComponent<Animator>());
            rend.sprite = newSprite;
            glassRend.enabled = true;
            StartCoroutine(DisplayText());
        }
    }

    IEnumerator DisplayText()
    {
        story.enabled = true;
        story.text = "You have fixed all the rifts in time and made it back to the present day!";
        yield return new WaitForSeconds(4f);
        story.enabled = false;
        end.enabled = true;
        end.text = "YOU HAVE WON!!!!!!!!!";
    }
}
