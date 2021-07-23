using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsThisRangeHealer : MonoBehaviour
{
    public Transform parent;
    public string nameOperator;
    public Estadisticas actualNeedHealing;
    public Estadisticas stats;
    public int baseATK;
    public float atkSpeed;
    public int menorVida;
    // Start is called before the first frame update

    void Start()
    {
        baseATK = stats.baseATK;
        atkSpeed = stats.atkSpeed;
        menorVida = 999999;
        
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "operator")
        {
            if(collision.GetComponent<Estadisticas>().currentHP < menorVida && collision.GetComponent<Estadisticas>().currentHP < collision.GetComponent<Estadisticas>().baseHP)
                {
                    menorVida = collision.GetComponent<Estadisticas>().currentHP;
                    actualNeedHealing = collision.GetComponent<Estadisticas>();
                    Debug.Log(actualNeedHealing);
                }


            if(actualNeedHealing == null)
            {
                return;
            }else
            {
                if(actualNeedHealing.currentHP < actualNeedHealing.baseHP)
                {
                    InvokeRepeating("Heal", atkSpeed, atkSpeed);
                }
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        reset();
    }

    public void Heal()
    {
        if(actualNeedHealing == null)
        {
            reset();
        } else{
            Debug.Log("cura");
            
            actualNeedHealing.GetHeal(baseATK);
            menorVida = 999999;
            if(actualNeedHealing.currentHP == actualNeedHealing.baseHP)
            {
                reset();
                return;
            }
        }
        
    }

    public void reset()
    {
        CancelInvoke();
        actualNeedHealing = null;
    }


}
