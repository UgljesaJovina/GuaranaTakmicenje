using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAS : Potion
{
    public Gun player;
    [SerializeField] float asMultiplier;
    public override void PotionEffect()
    {
        player.asMultiplier = asMultiplier;
    }

}
