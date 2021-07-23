using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsThisRange : MonoBehaviour
{
    public Transform parent;
    public string nameOperator;
    public EnemyStats actualEnemy;
    public Estadisticas stats;
    public int baseATK;
    public float atkSpeed;
    public int damage;
    public int enemyDef;
    public int minimunDamage;

    //Skills
    public SkillBar skillbar;


    // Start is called before the first frame update
    void Start()
    {
        baseATK = stats.baseATK;
        atkSpeed = stats.atkSpeed;
    }

    void OnTriggerEnter(Collider collision) 
    {
        if (collision.tag != "enemy")
        {
            return;
        }else
        {
            if (actualEnemy == null)
            {
                actualEnemy = collision.GetComponent<EnemyStats>();
                InvokeRepeating("MakeDamage", atkSpeed, atkSpeed);
            }
        }

    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.tag != "enemy")
        {
            return;
        }else
        {
           if (actualEnemy == null)
            {
                actualEnemy = collision.GetComponent<EnemyStats>();
                InvokeRepeating("MakeDamage", atkSpeed, atkSpeed);
            } 
        }
    }

    void OnTriggerExit(Collider collision)
    {
        reset();
    }

    public void MakeDamage()
    {
        
        if(actualEnemy == null)
        {
            reset();
        }
        else
        {
            nameOperator = parent.name;
            enemyDef = actualEnemy.def;
            damage = baseATK - enemyDef;
            minimunDamage = (baseATK*5)/100;
            if(damage <= 0)
            {
                damage = minimunDamage;
            }
            if (stats.skillTypeOfCharge=="onAttack")
            {
                stats.initialSPOne++;
                skillbar.setSkill(stats.initialSPOne);
            }
            actualEnemy.TakeDamage(damage, nameOperator);
        }
        
    }

    public void reset()
    {
        CancelInvoke();
        actualEnemy = null;
    }
}
