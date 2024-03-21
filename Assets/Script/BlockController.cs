using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockController : MonoBehaviour
{
    public int blockCount = 4;
    public static BlockController instance;
    public GameObject WinPopUp;
    public GameObject LosePopUp;
    public GameObject Scores;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        blockCount = gameObject.transform.childCount;
    }

    public void ActiveWinPopUp()
    {
        Time.timeScale = 0;
        WinPopUp.SetActive(true);
        Scores.SetActive(true);
    }

    public void ActiveLostPopUp()
    {
        Time.timeScale = 0;
        LosePopUp.SetActive(true);
        Scores.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
