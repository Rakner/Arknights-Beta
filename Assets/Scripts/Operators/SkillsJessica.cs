using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsJessica : MonoBehaviour
{
    public Transform parent;
    public string nameOperator;
    public Estadisticas stats;
    public SkillBar skillbar;
    public IsThisRange atack;
    public int damage;
    public int minimunDamage;
    public bool habilidadReady;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (stats.initialSPOne == stats.costSPOne && habilidadReady == true && atack.actualEnemy != null)
        { PowerfulStrikeTypeB(); }
    }

    public void PowerfulStrikeTypeB()
    {
            Debug.Log("habilidad");
            atack.CancelInvoke();
            damage = (stats.baseATK*170)/100;
            habilidadReady = false;
            Invoke("MakeDamageSkill", stats.atkSpeed);
            //MakeDamageSkill();
        
    }

    public void MakeDamageSkill()
    {
        nameOperator = parent.name;
        minimunDamage = (damage*5)/100;
        damage = damage - atack.actualEnemy.def;
        
        if(damage <= 0)
        {
            damage = minimunDamage;
        }
        if(atack.actualEnemy == null)
        {
            atack.reset();
        } else{
            if (stats.skillTypeOfCharge=="onAttack")
            {
                stats.initialSPOne = 0;
                skillbar.setSkill(stats.initialSPOne);
            }
            atack.actualEnemy.TakeDamage(damage, nameOperator);
            atack.InvokeRepeating("MakeDamage", atack.atkSpeed, atack.atkSpeed);
            habilidadReady = true;
        }
        
    }
}
