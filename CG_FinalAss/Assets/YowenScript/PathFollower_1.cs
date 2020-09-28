using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollower_1 : MonoBehaviour
{
    public PathCreator path1;
    public float speed = 5;
    float distanceTravelled;
    public EndOfPathInstruction end;

    Animator playerAnim;
    bool TriggerTurnAnimation = false;

    public Transform FinalDestination;
    HeadBob headBobScript;

    public GameObject[] MouseOverObject;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        headBobScript = transform.GetChild(0).gameObject.GetComponent<HeadBob>();
    }

    // Update is called once per frame
    void Update() 
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = path1.path.GetPointAtDistance(distanceTravelled, end);

        float dist = Vector3.Distance(FinalDestination.position, transform.position);
        if(dist > 0.05)
        {
            headBobScript.playerMoving = true;
            for(int i = 0; i < 2; i++)
            {
                MouseOverObject[i].GetComponent<Collider>().enabled = false;
            }
        }
        else
        {
            headBobScript.playerMoving = false;
            for (int i = 0; i < 2; i++)
            {
                MouseOverObject[i].GetComponent<Collider>().enabled = true;
            }
        }

        if (distanceTravelled >= 7.5)
        {
            if(!TriggerTurnAnimation)
            {
                playerAnim.SetTrigger("TurnCamera");
                TriggerTurnAnimation = true;
            }
        }
    }
}
