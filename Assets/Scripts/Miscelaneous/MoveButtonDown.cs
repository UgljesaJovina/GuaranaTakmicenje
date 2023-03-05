using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveButtonDown : MonoBehaviour
{
    float time;
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, 376), time);
        time += Time.deltaTime;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
