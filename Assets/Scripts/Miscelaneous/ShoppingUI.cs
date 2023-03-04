using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingUI : MonoBehaviour
{
    public Button[] buttons = new Button[3];
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindWithTag("Player"))
        {
            foreach (Button button in buttons)
            {
                button.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindWithTag("Player"))
        {
            foreach (Button button in buttons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}
