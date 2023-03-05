using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHP : Potion
{
    public PlayerSleep player;
    [SerializeField] float healAmount;
    public override void PotionEffect()
    {
        player.TakeDamage(-healAmount);
    }

}
