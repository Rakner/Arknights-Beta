using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPoints : MonoBehaviour
{
    public Text SkillPoint;

    
    public void setTextSkill(int initialSPOne)
    {
        SkillPoint.text = initialSPOne.ToString();
    }
}
