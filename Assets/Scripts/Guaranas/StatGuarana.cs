using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StatGuarana : GuaranaBase
{
    float statBuffDuration = 15f;
    float statBuff = 0.5f;

    public StatGuarana(float _price, string _name) : base(_price, _name) { }

    public override void Consume(PlayerSleep player)
    {
        GiveStats();
    }

    async void GiveStats()
    {
        Gun.instance.dmgMultiplier = statBuff;
        Gun.instance.asMultiplier = statBuff;
        await Task.Delay((int)(statBuffDuration * 1000f));
        Gun.instance.dmgMultiplier = 0;
        Gun.instance.asMultiplier = 0;
    }
}
