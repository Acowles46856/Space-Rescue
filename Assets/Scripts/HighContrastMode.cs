using UnityEngine;
using UnityEngine.InputSystem;

public class HighContrastMode : MonoBehaviour
{
    public Material normalMaterial;
    public Material highContrastMaterial;
    public Renderer playerRenderer;

    private bool highContrastOn = false;

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.hKey.wasPressedThisFrame)
        {
            highContrastOn = !highContrastOn;
            if (highContrastOn)
            {
                playerRenderer.material = highContrastMaterial;
            }
            else 
            {
            playerRenderer.material = normalMaterial;
            }
        }
    }
}