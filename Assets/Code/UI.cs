using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{ 
    GameObject getReadyText;
    GameObject goText;
    GameObject youDiedText;    


    // Use this for initialization
    void Start ()
    {       
        textsInitialization();
        getReadyText.SetActive(true);
        StartCoroutine(Begin());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!MovementController.getIsFishLives())
        {       
           youDiedText.SetActive(true);
        }
	}

   void textsInitialization()
    {
        getReadyText = GameObject.Find("getReadyText");
        getReadyText.SetActive(false);
        goText = GameObject.Find("goText");
        goText.SetActive(false);
        youDiedText = GameObject.Find("youDiedText");
        youDiedText.SetActive(false);
    }


    IEnumerator Begin()
    {
        yield return new WaitForSeconds(1f);
        getReadyText.SetActive(false);       
        goText.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        goText.SetActive(false);

    }

    
}
