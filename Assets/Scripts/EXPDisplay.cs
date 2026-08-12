using UnityEngine;
using TMPro;

public class EXPDisplay : MonoBehaviour
{
    public TextMeshProUGUI expText; // 経験値表示用のTextMeshProUGUI

    void Update()
    {
        int exp = LevelManager.Instance.GetExp(); // 現在の経験値を取得

        int requiredExp = LevelManager.Instance.GetRequiredExp(); // レベルアップに必要な経験値を取得

        expText.text = "EXP: " + exp + " / " + requiredExp; // 経験値表示を更新
    }
}
