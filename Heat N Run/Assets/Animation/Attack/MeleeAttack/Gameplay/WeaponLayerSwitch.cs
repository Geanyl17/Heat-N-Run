using UnityEngine;

public class WeaponAnimationLayerSwitcher : MonoBehaviour
{
    public Animator animator;
    public int baseLayerIndex = 0; // Index of the base animation layer
    public int axeLayerIndex = 1; // Index of the axe animation layer
    public int gunLayerIndex = 2; // Index of the gun animation layer

    // Method to switch to the base animation layer
    public void SwitchToBaseLayer()
    {
        SetLayerWeight(baseLayerIndex, 1f); // Set base layer weight to 1
        SetLayerWeight(axeLayerIndex, 0f); // Set other layers' weights to 0
        SetLayerWeight(gunLayerIndex, 0f);
    }

    // Method to switch to the axe animation layer
    public void SwitchToAxeLayer()
    {
        SetLayerWeight(baseLayerIndex, 0f); // Set other layers' weights to 0
        SetLayerWeight(axeLayerIndex, 1f); // Set axe layer weight to 1
        SetLayerWeight(gunLayerIndex, 0f);
    }

    // Method to switch to the gun animation layer
    public void SwitchToGunLayer()
    {
        SetLayerWeight(baseLayerIndex, 0f); // Set other layers' weights to 0
        SetLayerWeight(axeLayerIndex, 0f);
        SetLayerWeight(gunLayerIndex, 1f); // Set gun layer weight to 1
    }

    // Helper method to set the weight of a specific animation layer
    private void SetLayerWeight(int layerIndex, float weight)
    {
        animator.SetLayerWeight(layerIndex, weight);
    }
}
