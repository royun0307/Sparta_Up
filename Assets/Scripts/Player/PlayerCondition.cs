using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition hunger {  get { return uiCondition.hunger; } }
    Condition stamina {  get { return uiCondition.stamina; } }

    public float healByHunger;
    private float lastHealTime = 0f;
    public float healRate;

    private void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if(!health.isFull && Time.time - lastHealTime >= healRate)
        {
            lastHealTime = Time.time;
            Heal(healByHunger);
            hunger.Substract(1f);
        }
        if(health.curValue <= 0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }


    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public void Die()
    {
        Debug.Log("플레이어가 죽었다.");
    }
}
