using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamgable
{
    void TakePhysicalDamage(int damage);
}
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

        if(!health.isFull && Time.time - lastHealTime >= healRate)//체력이 최대치가 아니면 배고픔을 소모해 체려 회복
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

    public bool UseStamina(float amount)
    {
        if (stamina.curValue - amount < 0f)
        {
            return false;
        }
        stamina.Substract(amount);
        return true;
    }

    public void Skill(float amount, float time)//스킬 시전
    {
        CharacterManager.Instance.Player.controller.moveSpeed += amount;
        StartCoroutine(SkillEnd(amount, time));
    }

    IEnumerator SkillEnd(float amount, float time)//스킬 종료
    {
        yield return new WaitForSeconds(time);

        CharacterManager.Instance.Player.controller.moveSpeed -= amount;
    }
}
