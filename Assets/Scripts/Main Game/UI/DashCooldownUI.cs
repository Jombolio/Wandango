using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldownUI : MonoBehaviour
{
    public PlayerDash playerDash; // INPUT_REQUIRED {Link this to the PlayerDash component in the inspector}
    public Image cooldownImage; // INPUT_REQUIRED {Link this to the UI Image component in the inspector}
    
    void Update()
    {
        cooldownImage.fillAmount = playerDash.CooldownPercentage();
    }
}
