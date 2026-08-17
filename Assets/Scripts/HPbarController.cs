//敵　HP表示

using UnityEngine;
using UnityEngine.UI;

public class HPbarController : MonoBehaviour
{
    public Slider slider;

    //最大HP
    public void SetMaxHP(int hp)
    {
        slider.maxValue = hp;

        slider.value = hp;  
    }

    public void SetHP(int hp)
    {  
        slider.value = hp;
    }
}
