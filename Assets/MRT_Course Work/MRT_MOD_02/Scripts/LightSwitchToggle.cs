using UnityEngine;

public class LightSwitchToggle : MonoBehaviour
{
    public Light targetLight;
    public Material offMaterial;
    public Material onMaterial;

    private Renderer switchRenderer;
    private bool lightIsOn = true;

    private void Start()
    {
        switchRenderer = GetComponent<Renderer>();
        UpdateLightState();
    }

    public void ToggleLight()
    {
        lightIsOn = !lightIsOn;
        UpdateLightState();
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