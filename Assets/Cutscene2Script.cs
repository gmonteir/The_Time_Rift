using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Cutscene2Script : MonoBehaviour
{
    public Text firstText;
    public Text secondText;
    public GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        firstText.enabled = true;
        firstText.text = "That is, until you somehow find yourself transported to the future right next to a time police facility";
        secondText.enabled = false; 
        StartCoroutine(DisplayText());
    }

    IEnumerator DisplayText()
    {
        yield return new WaitForSeconds(5);
        firstText.enabled = false;
        secondText.enabled = true;
        Vector3 theScale = player.transform.localScale;
        theScale.x *= -1;
        player.transform.localScale = theScale;
        secondText.text = "The solution goes like this: fix all the rifts in time and you get to go back home";
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Tutorial");
    }
}
