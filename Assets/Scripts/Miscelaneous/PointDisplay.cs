using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointDisplay : MonoBehaviour
{
    float time;
    TextMeshProUGUI tmp;
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = "Score: " + PlayerScore.score;
    }

    void LateUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, 576), time);
        time += Time.deltaTime;
    }
}
