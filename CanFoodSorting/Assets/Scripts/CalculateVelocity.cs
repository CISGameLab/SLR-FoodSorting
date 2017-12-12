using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateVelocity : MonoBehaviour {

    Vector3 startPos;
    float startTime;
    private Rigidbody currThrowable;
    // Use this for initialization
    void Start() {

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
            float power = distance / duration;

            //expected values are what power you get when you try 
            //desired values are what you want
            //you might want these as public values so they can be set from the inspector
            const float expectedMin = 1;
            const float expectedMax = 2;
            const float desiredMin = 20;
            const float desiredMax = 35;

            /*
            //Measure expected power here
            

            //change power from the range 50...60 to 0...1
            power -= expectedMin;
            power /= expectedMax - expectedMin;

            //clamp value to between 0 and 1
            power = Mathf.Clamp01(power);
            Debug.Log("Clamped Power: " + power);
            //change power to the range 15...20
            power *= desiredMax - desiredMin;
            power += desiredMin;
            */
            //take the direction from the swipe. length of the vector is the power

            Vector3 velocity = (transform.rotation * dir).normalized * power;
            float yVelocity = velocity.z+2f;
            Vector3 updatedVelocity = new Vector3(velocity.x, yVelocity, velocity.y+2f);

            //Debug.Log(velocity);
            //Debug.Log("Power: " + power + "  Dis: " + distance + "  Duration: " + duration + " Uvelocity: "+ updatedVelocity);
            currThrowable = GameObject.FindGameObjectWithTag("CurrThrowable").GetComponent<Rigidbody>();
            currThrowable.velocity = updatedVelocity;

        }
    }
}
