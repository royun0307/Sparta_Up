using UnityEngine;

public class WeaponTool : Weapon
{
    public float attackRate;
    private bool attacking;
    public float attackDistance;

    [Header("Combat")]
    public bool doesDealDamage;
    public int damage;

    private Animator animator;
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
        animator = GetComponent<Animator>();
    }

    public override void OnAttackInput()
    {
        if (!attacking)
        {
            attacking = true;
            animator.SetTrigger("Attack");
            Invoke("OnCanAttack", attackRate);
        }
    }

    void OnCanAttack()
    {
        attacking = false;
    }

    public void OnHit()
    {
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackDistance))
        {
            if (doesDealDamage && hit.collider.TryGetComponent(out IDamgable target))
            {
                CharacterManager.Instance.Player.controller.Attack();
                target.TakePhysicalDamage(damage);
            }
        }
    }
}