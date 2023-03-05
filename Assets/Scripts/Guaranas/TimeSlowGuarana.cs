using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TimeSlowGuarana : GuaranaBase
{
    float buffDuration = 5f;
    float timeSlowStrength = .1f;

    public TimeSlowGuarana(float _price, string _name, float buffDuration, float timeSlowStrength) 
        : base(_price, _name) { this.buffDuration = buffDuration; this.timeSlowStrength = timeSlowStrength; }

    public override void Consume(PlayerSleep player)
    {
        SlowDownTime();
    }

    async void SlowDownTime()
    {
        Time.timeScale = timeSlowStrength;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        await Task.Delay((int)(buffDuration * 1000));
        Time.timeScale = 1;
        Time.fixedDeltaTime = .02f;
    }
}
