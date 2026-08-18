//プレイヤー　強化　表示

using UnityEngine;
using TMPro;

public class PowerUpDisplay : MonoBehaviour
{
    public TextMeshProUGUI powerUpText;
    
    public void ShowPowerUp(string message)
    {
        powerUpText.text = message;

        powerUpText.gameObject.SetActive(true);
    }

    public void HidePowerUp()
    {
        powerUpText.gameObject.SetActive(false);
    }
}
