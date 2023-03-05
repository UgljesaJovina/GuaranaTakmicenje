using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GuaranaBase
{
    public float price;
    public string name;

    public GuaranaBase(float _price, string _name)
    {
        price = _price;
        name = _name;
    }

    public abstract void Consume(PlayerSleep player);
}
