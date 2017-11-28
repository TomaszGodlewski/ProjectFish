using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScenesMenagement : MonoBehaviour {

    // Use this for initialization
    Scene scene;
    string sceneName;
    float time;
    bool switchOnceFlag = false;
    public Button mainMenu;
    

    void Start()//
    {
        mainMenu.onClick.AddListener(menu);
        scene = SceneManager.GetActiveScene();
        //Debug.Log("Active scene is '" + scene.name + "'.");

        if(scene.name == "Scene1")
        {
            time = 36f;
            sceneName = "Scene2";
        }

        if (scene.name == "Scene2")
        {
            time = 38f;
            sceneName = "Scene3";
        }

        if (scene.name == "Scene3")
        {
            time = 38f;
            sceneName = "Scene1";
        }
        
        StartCoroutine(NextSceneLoader(sceneName, time));
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(!MovementController.getIsFishLives()&&!switchOnceFlag)
        {
            StartCoroutine(NextSceneLoader("Scene1", 2f));
            switchOnceFlag = true;
        }

	}

    IEnumerator NextSceneLoader(string sceneName, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }

    void menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
