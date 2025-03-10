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

    public void UseSkill(float time)
    {
        isUse = true;
        skill.gameObject.SetActive(true);
        skill.sprite = item.icon;
        maxSkillTime = curSkillTime = time;
    }

    public void EndSkill()
    {
        item = null;
        skillTime.fillAmount = 0;
        skill.sprite = null;
        skill.gameObject.SetActive(false);
    }

    public float GetPercentage()
    {
        return  (maxSkillTime - curSkillTime) / maxSkillTime;
    }
}
