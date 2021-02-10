using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public float factor;

    private bool inpuInThisFrame;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }
    public void HandleInputs()
    {
        Quaternion rotation = this.transform.rotation;
        if (Input.GetKey(KeyCode.W))
        {
            rotation= new Quaternion(rotation.x + factor, rotation.y , rotation.z,1);
        
            this.transform.rotation = rotation;
            inpuInThisFrame = true;
        } 
        if (Input.GetKey(KeyCode.S)){
          rotation=new Quaternion(rotation.x - factor, rotation.y , rotation.z,1); 
          inpuInThisFrame = true;
        }
        
        if (Input.GetKey(KeyCode.A)){
            rotation= new Quaternion(rotation.x , rotation.y , rotation.z+factor,1);
            inpuInThisFrame = true;
        } 
        if (Input.GetKey(KeyCode.D)){
            
            rotation= new Quaternion(rotation.x , rotation.y , rotation.z-factor,1);

            inpuInThisFrame = true;

        }

        if (inpuInThisFrame)
        {
            rb.MoveRotation(rotation.normalized);
            inpuInThisFrame = false;
        }
        

    }
}
