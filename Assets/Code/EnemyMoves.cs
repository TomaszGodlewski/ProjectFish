using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour
{
    public float speed = 5f;
    public float pointBX = 5f;
    public bool defaultBX = true;
    public float pointBY = -5f;
    public bool defaultBY = true; 
    public float delayTime = 1f;
    public float destroyTime = 2f;
    // Use this for initialization

    void Start()
    {
        StartCoroutine(Begin());       
        Destroy(gameObject, delayTime+destroyTime);
      
    }

    IEnumerator Begin()
    {
        yield return new WaitForSeconds(delayTime);
        var pointA = transform.position;
        var pointB = new Vector3(defaultBX ? transform.position.x : pointBX, defaultBY ? transform.position.y : pointBY, transform.position.z);
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));         
        }
        
        
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = speed / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);           
            yield return null;            
        }
      
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
           // Destroy(gameObject, 0.5f);
        }
    }
}
