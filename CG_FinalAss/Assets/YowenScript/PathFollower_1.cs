using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
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
    bool colliderEnabled = false;

    public PostProcessVolume volume;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        headBobScript = transform.GetChild(0).gameObject.GetComponent<HeadBob>();
        StartCoroutine(OpeningEffect());
    }

    // Update is called once per frame
    void Update() 
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = path1.path.GetPointAtDistance(distanceTravelled, end);

        float dist = Vector3.Distance(FinalDestination.position, transform.position);
        if(dist > 0.01)
        {
            headBobScript.playerMoving = true;
            if(!colliderEnabled)
            {
                StartCoroutine(enableCollider());
                colliderEnabled = true;
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

    IEnumerator enableCollider()
    {
        yield return new WaitForSeconds(.75f);
        for (int i = 0; i < 2; i++)
        {
            MouseOverObject[i].GetComponent<Collider>().enabled = false;
        }
    }

    IEnumerator OpeningEffect()
    {
        AutoExposure autoExposure;
        volume.profile.TryGetSettings(out autoExposure);
        while (autoExposure.keyValue.value < 1)
        {
            autoExposure.keyValue.value += .2f * Time.deltaTime; 
            yield return null;
        }
    }
}
