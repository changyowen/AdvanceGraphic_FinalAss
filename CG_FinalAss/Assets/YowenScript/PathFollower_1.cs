using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using PathCreation;
using UnityEngine.Playables;

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

    public PlayableDirector opening_2, opening_3;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        headBobScript = transform.GetChild(0).gameObject.GetComponent<HeadBob>();

        if(OpeningManager.OpeningIndex == 1)
        {
            StartCoroutine(OpeningEffect());
        }
        else if (OpeningManager.OpeningIndex == 2)
        {
            transform.position = path1.path.GetPoint(58);
            opening_2.Play();
        }
        else if (OpeningManager.OpeningIndex == 3)
        {
            transform.position = path1.path.GetPoint(58);
            opening_3.Play();
        }
    }

    // Update is called once per frame
    void Update() 
    {
        if(OpeningManager.OpeningIndex == 1)
        {
            Opening_1_anim();
        }
        else if (OpeningManager.OpeningIndex == 2 || OpeningManager.OpeningIndex == 3)
        {
            Opening_2();
        }
    }

    void Opening_1_anim()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = path1.path.GetPointAtDistance(distanceTravelled, end);

        float dist = Vector3.Distance(FinalDestination.position, transform.position);
        if (dist > 0.01)
        {
            headBobScript.playerMoving = true;
            if (!colliderEnabled)
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
            if (!TriggerTurnAnimation)
            {
                playerAnim.SetTrigger("TurnCamera");
                TriggerTurnAnimation = true;
            }
        }
    }

    void Opening_2()
    {
        headBobScript.playerMoving = false;
        transform.position = path1.path.GetPoint(58);

        if(opening_2.state != PlayState.Playing && opening_3.state != PlayState.Playing)
        {
            for (int i = 0; i < 2; i++)
            {
                MouseOverObject[i].GetComponent<Collider>().enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                MouseOverObject[i].GetComponent<Collider>().enabled = false;
            }
        }
        
        if (!TriggerTurnAnimation)
        {
            playerAnim.SetTrigger("TurnCamera");
            TriggerTurnAnimation = true;
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
