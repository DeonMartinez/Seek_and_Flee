using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameOver = false;
    public float delay = 1f;

    public GameObject winUI;

    public void CompleteLevel ()
    {
        winUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameOver == false)
        {
            gameOver = true;
            Invoke("Restart", delay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
