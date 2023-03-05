using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DashExit : MonoBehaviour
{
    public SpriteRenderer whitescreen;
    public SpriteRenderer sword;
    public static int enemiesHit;
    [SerializeField] GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D()
    {
        PlayerScore.score += 2000;
        StartCoroutine(KillBoss());
        player.GetComponent<DashMove>().enabled = false;
        player.transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }

    IEnumerator KillBoss()
    {
        Color color = whitescreen.color;
        for (float i = 0; i < 1; i += 0.03f)
        {
            color.a = i;
            whitescreen.color = color;
            sword.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("EndScreen");
    }
}
