using UnityEngine;

public enum WeaponType
{
    Melee,
    Axe,
    Gun
}
public abstract class Weapon : MonoBehaviour
{
    public WeaponType weaponType;

    public abstract void Use();
}
