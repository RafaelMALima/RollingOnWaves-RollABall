using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpBar : MonoBehaviour
{
    public int maxHp;
    private int curHp;
    public Slider slider;
    void Start()
    {
        curHp = maxHp;
    }
    public void TakeDamage(int dmg)
    {
        curHp = curHp - dmg;
        slider.value = (float) 1f - ((float)curHp / (float)maxHp);
    }
}
