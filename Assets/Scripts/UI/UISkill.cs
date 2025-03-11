using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UISkill : MonoBehaviour
{
    public UISkillIcon[] uISkills;

    private void Start()
    {
        uISkills = GetComponentsInChildren<UISkillIcon>();
    }

    public void UseSkill(ItemData item, float time)//스킬아이템 사용
    {
        UISkillIcon emptySkill = GetEmptySkill();
        if (emptySkill != null)
        {
            emptySkill.item = item;
            emptySkill.UseSkill(time);
            return;
        }
        return;
    }

    public UISkillIcon GetEmptySkill()//스킬 아이콘 빈자리가 있는지 여부
    {
        for (int i = 0; i < uISkills.Length; i++) 
        {
            if (uISkills[i].item == null)
            {
                return uISkills[i];
            }
        }
        return null;
    }
}
