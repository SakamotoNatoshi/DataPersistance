using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public void NameInput(string s)
    {
        if (DataHandler.Instance != null)
        {
            DataHandler.Instance.username = s;
            Debug.Log("Username defined as: " + s);
        }
    }
    
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        if (DataHandler.Instance != null)
        {
            bestScoreText.text = "Best Score: " + DataHandler.Instance.bestScore;
        }
    }
}
