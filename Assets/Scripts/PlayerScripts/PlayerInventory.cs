using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    GuaranaBase[] inventory = new GuaranaBase[3] { null, null, null };
    [SerializeField] Text[] inventoryText;
    [SerializeField] Animator buttons;
    public bool inShoppingArea = false;
    public static PlayerInventory instance;
    [SerializeField] PlayerSleep player;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && inventory[0] is not null && !inShoppingArea)
        {
            inventory[0].Consume(player);
            inventory[0] = null;
        }
        else if (Input.GetKeyDown(KeyCode.E) && inventory[1] is not null && !inShoppingArea)
        {
            inventory[1].Consume(player);
            inventory[1] = null;
        }
        else if (Input.GetKeyDown(KeyCode.R) && inventory[2] is not null && !inShoppingArea)
        {
            inventory[2].Consume(player);
            inventory[2] = null;
        }

        for (int i = 0; i < 3; i++)
        {
            inventoryText[i].text = inventory[i] is null ? "Slot " + (i + 1) : inventory[i].name;
        }
    }

    public void EnterShopArea()
    {
        buttons.Play("FlyIn");
    }

    public void ExitShopArea() 
    {
        buttons.Play("FlyOut");
    }

    public void BuyGuarana(GuaranaBase guarana)
    {
        print("Bought a " + guarana.GetType());
        for (int i = 0; i < 3; i++)
        {
            if (inventory[i] is null && PlayerScore.money >= guarana.price)
            {
                inventory[i] = guarana;
                PlayerScore.money -= (int)guarana.price;
                return;
            }
        }
    }

}
