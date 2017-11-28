using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour 
{
    public Rigidbody2D body;
    float speed = 10f;
    private Vector3 previousPos;
    public Camera cam;
    Vector3 viewPos;
    Vector3 targetPosition;
    Vector3 newPosition;
    static bool isFishLives = true;



    //private Vector3 offset;
    private const float MIN_VIEW_POS_X = 0.01f;
    private const float MAX_VIEW_POS_X = 0.99f;
    private const float MIN_VIEW_POS_Y = 0.01f;
    private const float MAX_VIEW_POS_Y = 0.99f;


	// Use this for initialization
	void Start () 
    {
        //Debug.Log("Start!");
        isFishLives = true;
        previousPos = transform.position;
        targetPosition = transform.position;
        newPosition = transform.position;
        //Debug.Log("Sounds pause: " +SoundOnOff.pauseAudio());
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(isFishLives)
        {
            mousePosition();
            if (isMoving()) 
            {
                mouseMovement();
                lookDirection(); 
            }
            else
            {
                defaultDirection();
            }
        }
	}

    bool isMoving()
    {
        return transform.position != targetPosition;
    }

    void keyboardMovement()
    {
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float dy = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        if (dx != 0 || dy != 0)
        {
            Vector3 newPosition = transform.position + new Vector3(dx, dy, 0);
            viewPos = cam.WorldToViewportPoint(newPosition);

            if (viewPos.x > MIN_VIEW_POS_X && viewPos.x < MAX_VIEW_POS_X
           && viewPos.y > MIN_VIEW_POS_Y && viewPos.y < MAX_VIEW_POS_Y)
            {
                transform.position = newPosition;
            }
        }
    }

    void lookDirection()
    {
        Vector3 diff = previousPos - transform.position;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        if (rot_z >= -90 && rot_z <= 90)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 180 - rot_z);
        }
        previousPos = transform.position;
    }

    void defaultDirection()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void mousePosition()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0;
            // Debug.Log(targetPosition);
        }
    }

    void mouseMovement()
    {
        viewPos = cam.WorldToViewportPoint(targetPosition);

        if (viewPos.x > MIN_VIEW_POS_X && viewPos.x < MAX_VIEW_POS_X
       && viewPos.y > MIN_VIEW_POS_Y && viewPos.y < MAX_VIEW_POS_Y)
        {
            newPosition = targetPosition;
        }

        transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * speed);
    
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            //Debug.Log("Fish Died!");
            isFishLives = false;
            body.constraints = RigidbodyConstraints2D.None;
            //Destroy(gameObject, 0.5f);
        }
    }

    public static bool getIsFishLives()
    {
        return isFishLives;
    }
}
