using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wayr : MonoBehaviour
{
    private Animator _Aim;
    void Start()
    {
        WayOpen = false;
        _Aim = GetComponent<Animator>();
    }
    public bool WayOpen = false;

    // Update is called once per frame
    void Update()
    {
        if (WayOpen)
            _Aim.SetBool("Open", WayOpen);
     
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            WayOpen = true;
    }
}
