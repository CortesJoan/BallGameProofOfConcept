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

    public int numPickUpItems;
    // Start is called before the first frame update
    void Start()
    { 
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
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
