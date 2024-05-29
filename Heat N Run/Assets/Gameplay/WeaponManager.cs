using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> weapons; // List of all weapons (melee and ranged)
    private Weapon activeWeapon;

    public Animator playerAnimator; // Reference to the player's Animator component
    public int baseLayerIndex = 0; // Index of the base animation layer
    public int axeLayerIndex = 1; // Index of the axe animation layer
    public int gunLayerIndex = 2; // Index of the gun animation layer

    void Start()
    {
        if (weapons.Count > 0)
        {
            SetActiveWeapon(null); // Default to no weapon initially
        }
    }

    void Update()
    {
        // Example of switching weapons using number keys (1, 2, 3, etc.)
        for (int i = 0; i < weapons.Count; i++)
        {
            if (Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha1 + i)))
            {
                SetActiveWeapon(weapons[i]);
                UpdateAnimationLayer();
            }
        }

        // Example: No weapon selected (melee combat)
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SetActiveWeapon(null);
            UpdateAnimationLayer();
        }
    }

    public void SetActiveWeapon(Weapon weapon)
    {
        if (activeWeapon != null)
        {
            activeWeapon.gameObject.SetActive(false); // Deactivate the current weapon
        }

        activeWeapon = weapon;

        if (activeWeapon != null)
        {
            activeWeapon.gameObject.SetActive(true); // Activate the new weapon
        }
    }

    public Weapon GetActiveWeapon()
    {
        return activeWeapon;
    }

    private void UpdateAnimationLayer()
{
    if (activeWeapon != null)
    {
        Debug.Log("Active weapon type: " + activeWeapon.weaponType);
        
        // Determine which animation layer corresponds to the active weapon
        switch (activeWeapon.weaponType)
        {
            case WeaponType.Melee:
                playerAnimator.SetLayerWeight(baseLayerIndex, 1f);
                playerAnimator.SetLayerWeight(axeLayerIndex, 0f);
                playerAnimator.SetLayerWeight(gunLayerIndex, 0f);
                Debug.Log("Switched to Melee layer.");
                break;
            case WeaponType.Axe:
                playerAnimator.SetLayerWeight(baseLayerIndex, 0f);
                playerAnimator.SetLayerWeight(axeLayerIndex, 1f);
                playerAnimator.SetLayerWeight(gunLayerIndex, 0f);
                Debug.Log("Switched to Axe layer.");
                break;
            case WeaponType.Gun:
                playerAnimator.SetLayerWeight(baseLayerIndex, 0f);
                playerAnimator.SetLayerWeight(axeLayerIndex, 0f);
                playerAnimator.SetLayerWeight(gunLayerIndex, 1f);
                Debug.Log("Switched to Gun layer.");
                break;
            default:
                Debug.LogError("Unknown weapon type");
                break;
        }
    }
    else
    {
        // No active weapon, set all layer weights to 0
        playerAnimator.SetLayerWeight(baseLayerIndex, 0f);
        playerAnimator.SetLayerWeight(axeLayerIndex, 0f);
        playerAnimator.SetLayerWeight(gunLayerIndex, 0f);
        Debug.Log("No active weapon.");
    }
}

}
