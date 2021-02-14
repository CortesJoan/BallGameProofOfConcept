using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public int score;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        this.transform.position = new Vector3(this.transform.position.x + 0.01f, this.transform.position.y, 0);
     
    }
 

    public void ChangePos(Collider other)
    {
      
        if (other.gameObject.layer==9 || other.gameObject.tag.Equals("Level"))
        {
          
          this.transform.position = new Vector3(UnityEngine.Random.Range(-3.50f, 3.40f), UnityEngine.Random.Range(0.4f, 0.6f), UnityEngine.Random.Range(-3.50f,3.40f)); } 
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangePos(other);
        if (other.transform.tag.Equals("Player"))
        {
            gameManager.AddScore(score);
      
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        ChangePos(other);
    }

    private void OnTriggerStay(Collider other)
    {
        ChangePos(other);
    }
}
