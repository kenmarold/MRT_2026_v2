using System.Collections;
using UnityEngine;

public class LightSwitchToggle : MonoBehaviour
{
    public Light targetLight;
    public Material offMaterial;
    public Material onMaterial;

    [Header("Physical Switch Cooldown")]
    public float physicalSwitchCooldown = 0.5f;

    private Renderer switchRenderer;
    private bool lightIsOn = true;
    private bool physicalSwitchCanToggle = true;

    private void Start()
    {
        switchRenderer = GetComponent<Renderer>();
        UpdateLightState();
    }

    // Use this for the UI button.
    // No cooldown.
    public void ToggleLight()
    {
        lightIsOn = !lightIsOn;
        UpdateLightState();
    }

    // Use this for the physical cube switch.
    // Includes cooldown to prevent double-triggering from poke jitter.
    public void ToggleLightWithCooldown()
    {
        if (!physicalSwitchCanToggle)
        {
            return;
        }

        lightIsOn = !lightIsOn;
        UpdateLightState();

        StartCoroutine(PhysicalSwitchCooldown());
    }

    private IEnumerator PhysicalSwitchCooldown()
    {
        physicalSwitchCanToggle = false;
        yield return new WaitForSeconds(physicalSwitchCooldown);
        physicalSwitchCanToggle = true;
    }

    private void UpdateLightState()
    {
        if (targetLight != null)
        {
            targetLight.enabled = lightIsOn;
        }

        if (switchRenderer != null && offMaterial != null && onMaterial != null)
        {
            switchRenderer.material = lightIsOn ? onMaterial : offMaterial;
        }
    }
}