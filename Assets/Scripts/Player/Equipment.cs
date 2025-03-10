using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Weapon curEquipWeapon;
    public Weapon curEquipArmor;
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
        UnEquip();
        curEquipWeapon = Instantiate(data.equipPrefab, equipParent).GetComponent<Weapon>();
    }

    public void UnEquip()
    {
        if (curEquipWeapon != null)
        {
            Destroy(curEquipWeapon.gameObject);
            curEquipWeapon = null;
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