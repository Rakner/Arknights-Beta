using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour
{
    public Slider slider;
    
    public void setInitialSkill(int skillMaxSP, int initialSP)
    {
        slider.maxValue = skillMaxSP;
        slider.value = initialSP;
    }

    public void setSkill(int skill)
    {
        slider.value = skill;
    }
}
