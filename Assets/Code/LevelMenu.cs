using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour 
{
    public Button level2Button;
    public Button level3Button;
    public Button backButton;
    public Button soundButton;

    public Sprite SoundOffSprite;
    public Sprite SoundOnSprite;

	// Use this for initialization
	void Start () 
    {
        level2Button.onClick.AddListener(level2);
        level3Button.onClick.AddListener(level3);
        soundButton.onClick.AddListener(setSound);
        backButton.onClick.AddListener(back);
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    void level2()
    {
        SceneManager.LoadScene("Scene2");
    }

    void level3()
    {
        SceneManager.LoadScene("Scene3");
    }

    void back()
    {
        SceneManager.LoadScene("Main Menu");
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

    }

   

}
