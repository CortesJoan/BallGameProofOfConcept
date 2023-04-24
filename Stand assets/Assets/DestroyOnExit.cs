using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnExit : MonoBehaviour
{
    public UnityEvent onExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            other.GetComponentInChildren<ParticleSystem>().Play();
            Destroy(other.gameObject);
            onExit?.Invoke();
            
        }
    }
}
