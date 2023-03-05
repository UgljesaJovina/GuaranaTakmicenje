using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpGuarana : GuaranaBase
{
    [SerializeField] float healAmount = 30f;

    public HpGuarana(float _price, string _name) : base(_price, _name) { }

    public override void Consume(PlayerSleep player)
    {
        player.TakeDamage(-healAmount);
    }
}
