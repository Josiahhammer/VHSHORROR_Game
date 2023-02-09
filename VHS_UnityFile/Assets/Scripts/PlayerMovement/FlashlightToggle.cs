using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
