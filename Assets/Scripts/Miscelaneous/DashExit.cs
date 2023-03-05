using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DashExit : MonoBehaviour
{
    public static int enemiesHit;
    public bool isBoss;
    private void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("SampleScene");
        if(isBoss)
            PlayerScore.score = 2000 + enemiesHit;
    }
}
