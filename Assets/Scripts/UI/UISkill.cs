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

    public void UseSkill(ItemData item, float time)
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

    public UISkillIcon GetEmptySkill()
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
