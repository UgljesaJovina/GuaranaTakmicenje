using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText, moneyText;

    void Update()
    {
        scoreText.text = $"Score: {PlayerScore.score}";
        moneyText.text = $"Money: {PlayerScore.money}";
    }
}
