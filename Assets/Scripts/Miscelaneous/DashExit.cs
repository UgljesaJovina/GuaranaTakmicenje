using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DashExit : MonoBehaviour
{
    Coroutine killBoss;
    public SpriteRenderer whitescreen;
    public static int enemiesHit;
    public bool isBoss;
    private void OnTriggerEnter2D()
    {
        if(isBoss)
            PlayerScore.score = 2000 + enemiesHit;
        StartCoroutine(KillBoss());
    }

    IEnumerator KillBoss()
    {
        Color color = whitescreen.color;
        for (float i = 0; i < 1; i += 0.03f)
        {
            color.a = i;
            whitescreen.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");
    }
}
