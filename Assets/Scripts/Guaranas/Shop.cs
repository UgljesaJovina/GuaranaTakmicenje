using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour, IFriendlyDamagable
{
    public float health = 150f;
    public float currentHealth;
    bool shopping = false;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) SceneManager.LoadScene(3);
    }

    void Start()
    {
        currentHealth = health;
    }

    private void Update()
    {
        if (!shopping) return;

        if (Input.GetKeyDown(KeyCode.Q))
            PlayerInventory.instance.BuyGuarana(new HpGuarana(45, "Guarana"));
        else if (Input.GetKeyDown(KeyCode.E))
            PlayerInventory.instance.BuyGuarana(new StatGuarana(90, "Stats"));
        else if (Input.GetKeyDown(KeyCode.R))
            PlayerInventory.instance.BuyGuarana(new TimeSlowGuarana(110, "TimeSlow", 5, .1f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerInventory.instance.EnterShopArea();
            PlayerInventory.instance.inShoppingArea = true;
            shopping = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerInventory.instance.ExitShopArea();
            PlayerInventory.instance.inShoppingArea = false;
            shopping = false;
        }
    }
}
