using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Weapon curEquipWeapon;
    public ItemData curEquipArmor;
    public Transform equipParent;

    private PlayerController controller;
    private PlayerCondition condition;

    void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
        condition = CharacterManager.Instance.Player.condition;
    }

    public void EquipNew(ItemData data)
    {
        int num = data.type == ItemType.Weapon ? 0 : 1;
        UnEquip(num);
        if (num == 0)
        {
            curEquipWeapon = Instantiate(data.equipPrefab, equipParent).GetComponent<Weapon>();
        }
        else if(num == 1)
        {
            curEquipArmor = data;
            CharacterManager.Instance.Player.controller.jumpPower += data.value;
        }
    }

    public void UnEquip(int num)
    {
        if (num == 0)
        {
            if (curEquipWeapon != null)
            {
                Destroy(curEquipWeapon.gameObject);
                curEquipWeapon = null;
            }
        }
        else if(num == 1)
        {
            if(curEquipArmor != null)
            {
                CharacterManager.Instance.Player.controller.jumpPower -= curEquipArmor.value;
                curEquipArmor = null;
            }
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && curEquipWeapon != null && controller.canLook)
        {
            curEquipWeapon.OnAttackInput();
        }
    }
}