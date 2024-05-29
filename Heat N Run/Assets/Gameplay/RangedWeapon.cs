using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedWeapon : Weapon
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private WeaponManager weaponManager;
    private Animator animator;

    void Start()
    {
        weaponManager = FindObjectOfType<WeaponManager>();
    }

    void Update()
    {
        if (weaponManager.GetActiveWeapon() == this && Input.GetButtonDown("Fire1"))
        {
            Use();
        }
    }

    public override void Use()
    {
         if (animator != null)
        {
            animator.SetTrigger("Shoot");
        }
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
