using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingScript : MonoBehaviour
{
    public bool coroutineAllowed = true;

    public IEnumerator StartPulsing()
    {
        coroutineAllowed = false;

        for(float i = 0; i <= 1f; i += .1f)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.03f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.03f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.z, transform.localScale.z + 0.03f, Mathf.SmoothStep(0f, 1f, i)))
                );
            yield return new WaitForSeconds(0.015f);
        }

        for (float i = 0; i <= 1f; i += .1f)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.03f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.03f, Mathf.SmoothStep(0f, 1f, i))),
                (Mathf.Lerp(transform.localScale.z, transform.localScale.z - 0.03f, Mathf.SmoothStep(0f, 1f, i)))
                );
            yield return new WaitForSeconds(0.015f);
        }

        coroutineAllowed = true;
    }
}
