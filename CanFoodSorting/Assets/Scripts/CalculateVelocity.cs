using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateVelocity : MonoBehaviour {

    Vector3 startPos;
    float startTime;
    private Rigidbody currThrowable;
    float power;
    // Use this for initialization
    void Start()
    {
        power = 0f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Store initial values
            startPos = Input.mousePosition;
            startTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            //Get end values
            Vector3 endPos = Input.mousePosition;
            float endTime = Time.time;

            //Mouse positions distance from camera. Might be a better idea to use the cameras near plane
            startPos.z = 10f;
            endPos.z = 10f;

            //Makes the input pixel density independent
            startPos = Camera.main.ScreenToWorldPoint(startPos);
            endPos = Camera.main.ScreenToWorldPoint(endPos);

            //The duration of the swipe
            float duration = endTime - startTime;

            //The direction of the swipe
            Vector3 dir = endPos - startPos;

            //The distance of the swipe
            float distance = dir.magnitude;

            //Faster or longer swipes give higher power
            power = distance / duration;


            Vector3 velocity = (transform.rotation * dir).normalized * power;
            float yVelocity = velocity.z+3f;
            Vector3 updatedVelocity = new Vector3(velocity.x, yVelocity, velocity.y+2f);

            //Debug.Log(velocity);
            //Debug.Log("Power: " + power + "  Dis: " + distance + "  Duration: " + duration + " Uvelocity: "+ updatedVelocity);
            currThrowable = GameObject.FindGameObjectWithTag("CurrThrowable").GetComponent<Rigidbody>();
            currThrowable.velocity = updatedVelocity;
           

        }
       
    }
}
