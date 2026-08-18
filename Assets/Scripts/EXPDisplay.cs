//経験値表示

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXPDisplay : MonoBehaviour
{
    public Slider expBar; 
    public TextMeshProUGUI expText; // 経験値表示用のTextMeshProUGUI

    void Update()
    {
        if(LevelManager.Instance == null)
        {
            return;
        }

        int exp = LevelManager.Instance.GetExp(); // 現在の経験値を取得

        int requiredExp = LevelManager.Instance.GetRequiredExp(); // レベルアップに必要な経験値を取得

        expBar.maxValue = requiredExp;

        expBar.value = exp;

        expText.text = "EXP: " + exp + " / " + requiredExp; // 経験値表示を更新
    }
}
