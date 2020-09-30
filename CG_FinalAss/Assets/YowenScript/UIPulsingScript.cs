using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPulsingScript : MonoBehaviour
{
    private bool mouse_over = false;
    public Animator UIanim;

    // Start is called before the first frame update
    void Start()
    {
        UIanim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void MagnifyingFunction()
    {
        UIanim.SetBool("Magnifying", true);
    }

    public void NormalFunction()
    {
        UIanim.SetBool("Magnifying", false);
    }
}
