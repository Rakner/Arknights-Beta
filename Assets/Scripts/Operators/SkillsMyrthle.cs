using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Reflection;

public class SkillsMyrthle : MonoBehaviour
{
    public Estadisticas stats;
    public IsThisRange pararAtaque;
    public Text DPpoints;
    public Button Skill;
    public int skillTime = 8;
    

    // Start is called before the first frame update
    void Start()
    {
       
        DPpoints = GameObject.Find("Cost").GetComponent<Text>();
        Skill = GameObject.Find("Skill1Myrthle").GetComponent<Button>();
        Skill.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Skill.interactable == false)
        {
           if (stats.initialSPOne == stats.costSPOne)
            {
            Skill.interactable = true;
            } 
        }

        if (skillTime == 0)
        {
            CancelInvoke();
            stats.initialSPOne = 0;
            skillTime = 8;
            stats.block = 1;
            Skill.interactable = false;
            stats.InvokeRepeating("ChargeSkill", 0.1f, 1f);
            
        }
        
    }

    public void SupportOrderTypeB() 
    {
        stats.block = -1;
        
        InvokeRepeating("startSkill", 0f, 1f);
    }


    void startSkill ()
    {
        pararAtaque.reset();
        DPGenerator.DP += 2;
        if (DPGenerator.DP >= 99)
        {
            DPGenerator.DP = 99;
        }
        skillTime -=1;
    }
}
