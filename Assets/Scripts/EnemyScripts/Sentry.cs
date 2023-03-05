using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sentry : MonoBehaviour
{
    Coroutine gameOver;
    Color redscreen = Color.red;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerScore.score -= 100;
            Debug.Log(PlayerScore.score);
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerScore.score += 200;
            Destroy(gameObject);
        }
        
    }
    private void Update()
    {
        if (PlayerScore.score < -500)
        {
            StartCoroutine(GameOver());
        }
        transform.Rotate(Vector3.forward, Time.deltaTime * 100);
    }
    IEnumerator GameOver()
    {
      Color color = redscreen;
      for (float i = 0; i < 1; i += 0.03f)
      {
       color.a = i;
       redscreen = color;
       yield return new WaitForSeconds(0.01f);
      }
      yield return new WaitForSeconds(3f);
      SceneManager.LoadScene("EndScreen");
    }

    private void FixedUpdate()
    {
        transform.Translate(transform.right * 20f * Time.deltaTime);
    }
}
