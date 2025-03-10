using UnityEngine;

public enum ItemType
{
    Armor,
    Weapon,
    Hunger,
    Skill
}

[CreateAssetMenu(fileName = "Item", menuName = "new Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public float value;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header ("Equip")]
    public GameObject equipPrefab;
}
