using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class UISkillIcon : MonoBehaviour
{
    public ItemData item;
    public Image skill;
    public Image skillTime;
    private float maxSkillTime;
    [SerializeField]private float curSkillTime;
    private bool isUse = false;

    private void Start()
    {
        item = null;
        skillTime = this.GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        if (isUse)
        {
            curSkillTime -= Time.deltaTime;
            skillTime.fillAmount = GetPercentage();
            if (curSkillTime <= 0)
            {
                isUse = false;
                EndSkill();
            }
        }
    }

    public void UseSkill(float time)//스킬 아이템 사용
    {
        isUse = true;
        skill.gameObject.SetActive(true);
        skill.sprite = item.icon;
        maxSkillTime = curSkillTime = time;
    }

    public void EndSkill()//스킬 아이템 종료
    {
        item = null;
        skillTime.fillAmount = 0;
        skill.sprite = null;
        skill.gameObject.SetActive(false);
    }

    public float GetPercentage()//0 에서 1로 증가
    {
        return  (maxSkillTime - curSkillTime) / maxSkillTime;
    }
}
