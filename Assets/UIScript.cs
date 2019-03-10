using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class UIScript : MonoBehaviour
{
    public Text firstText;
    public Text secondText;

    // Start is called before the first frame update
    void Start()
    {
        //firstText = GetComponent<Text>();
        //secondText = GetComponent<Text>();
        firstText.enabled = true;
        firstText.text = "You are a 30 - year - old police officer from modern day";
        secondText.enabled = false; 
        StartCoroutine(DisplayText()); 
    }


    IEnumerator DisplayText()
    {
        yield return new WaitForSeconds(5);
        firstText.enabled = false;
        secondText.enabled = true; 
        secondText.text = "City crime is at an all - time low, and work life has been pretty stagnant";
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("TutorialCutscene2");
    }
}
