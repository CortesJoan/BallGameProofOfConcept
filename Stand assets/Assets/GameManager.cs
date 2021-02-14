using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Transform endText;
    public Text scoreText;
    public Transform coin;
    public float totalCoins;
    public int numPickUpItems;
    public float time;
    public Text timerText;
    public Text bestTimeText;
    private float bestTime;
    // Start is called before the first frame update
    void Start()
    { 
      bestTime=   PlayerPrefs.GetFloat("BestTime" );
      StartCoroutine("GenerateCoins");
      bestTimeText.text = "Best Time: " + bestTime;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timerText.text = "Time: " + time ;
    }

    IEnumerator GenerateCoins()
    {
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < totalCoins; i++)
        {
          Transform g=  Instantiate(coin,   FindObjectOfType<SceneController>().transform.Find("PickupItems").transform );

          g.position = new Vector3(UnityEngine.Random.Range(-3.50f, 3.40f), UnityEngine.Random.Range(0.4f, 0.6f), UnityEngine.Random.Range(-3.50f,3.40f));
         
          numPickUpItems++;
        }
    }

  
 
    public void AddScore(int score)
    {
        numPickUpItems--;
        this.score += score;
        UpdateUI();
        
    }

    private void UpdateUI()
    {
        scoreText.GetComponent<Animation>().Play();
        scoreText.text = "Score " + score;
        if (numPickUpItems==0)
        {
            endText.gameObject.SetActive(true);

            if (time<bestTime || bestTime==0)
            {
                PlayerPrefs.SetFloat("BestTime",time);
                PlayerPrefs.Save();
            }
          
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void EndGame()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
    }
}
