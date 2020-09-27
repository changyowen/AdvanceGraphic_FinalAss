using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public Vector3 restPosition; //local position where your camera would rest when it's not bobbing.
    public float transitionSpeed = 20f; //smooths out the transition from moving to not moving.
    public float bobSpeed = 4.8f; //how quickly the player's head bobs.
    public float bobAmount = 0.05f; //how dramatic the bob is. Increasing this in conjunction with bobSpeed gives a nice effect for sprinting.

    float timer = Mathf.PI / 2; //initialized as this value because this is where sin = 1. So, this will make the camera always start at the crest of the sin wave, simulating someone picking up their foot and starting to walk--you experience a bob upwards when you start walking as your foot pushes off the ground, the left and right bobs come as you walk.
    Vector3 camPos;

    public bool playerMoving = true;

    void Awake()
    {
        camPos = transform.localPosition;
    }

    void Update()
    {
        if (playerMoving == false) //stand
        {
            bobSpeed = 1;
            bobAmount = 0.02f;

            timer += bobSpeed * Time.deltaTime;

            //use the timer value to set the position
            Vector3 newPosition = new Vector3(camPos.x, restPosition.y + Mathf.Abs((Mathf.Sin(timer) * bobAmount)), restPosition.z); //abs val of y for a parabolic path
            camPos = newPosition;
        }
        else if(playerMoving == true)
        {
            bobSpeed = 4.5f;
            bobAmount = 0.1f;

            timer += bobSpeed * Time.deltaTime;

            //use the timer value to set the position
            Vector3 newPosition = new Vector3(restPosition.x, restPosition.y + Mathf.Abs((Mathf.Sin(timer) * bobAmount)), Mathf.Cos(timer) * bobAmount); //abs val of y for a parabolic path
            camPos = newPosition;
        }

        if (timer > Mathf.PI * 2) //completed a full cycle on the unit circle. Reset to 0 to avoid bloated values.
            timer = 0;

        transform.localPosition = camPos;
    }
}
