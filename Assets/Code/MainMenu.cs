using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public Button playButton;
    public Button quitButton;
    public Button soundButton;
    public Button storeButton;

    public Sprite SoundOffSprite;
    public Sprite SoundOnSprite;

	// Use this for initialization
	void Start () 
    {
        playButton.onClick.AddListener(play);
        quitButton.onClick.AddListener(quitGame);
        soundButton.onClick.AddListener(setSound);
        storeButton.onClick.AddListener(store);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void play()
    {
        SceneManager.LoadScene("Scene1");
    }

    void quitGame()
    {
        Application.Quit();
    }

    void setSound()
    {

        if (AudioListener.pause)
        {
            AudioListener.pause = false;
            soundButton.image.sprite = SoundOnSprite;

        }
        else
        {
            AudioListener.pause = true;
            soundButton.image.sprite = SoundOffSprite;
        }

        //Debug.Log("Sounds pause: " +pauseAudio());

    }

    void store()
    {
        SceneManager.LoadScene("Level Menu");
    }
}
