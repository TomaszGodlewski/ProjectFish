using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public Sprite firstForm;
    public Sprite secondForm;
    private SpriteRenderer spriteRenderer;
    bool colliderTrigered = false;
    

    // Use this for initialization
    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //DefaultForm();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void DefaultForm()
    {
        spriteRenderer.sprite = firstForm;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (tag == "Enemy")
        {
            if (coll.gameObject.tag == "Player")
            {
                //Debug.Log("Bum!");
               // spriteRenderer.sprite = secondForm;
            }
        }
        if(tag == "Player")
        {
            if (coll.gameObject.tag == "Enemy"&& !colliderTrigered)
            {
                //Debug.Log("Fish Died");                
                spriteRenderer.sprite = secondForm;                
                transform.rotation = Quaternion.Euler(0, 180, 180);
                colliderTrigered = true;
            }
        }
    }


}
