 using UnityEngine;
 using System;
 using System.Collections;
 using System.Reflection;
 using UnityEngine.UI;
 using UnityEngine.EventSystems;

public class Estadisticas : MonoBehaviour
{
    //deploy 
    DeployManager deployManager;
    //Stats
    public int stars;
    public int level;
    public int baseHP;
    public int currentHP;
    public int baseATK;
    public int baseDEF;
    public int cost;
    public int costCheck;
    public float atkSpeed;
    public int block;
    public int blockInicial;

    //Skills
    public string skillTypeOfCharge; 
    public int initialSPOne;
    public int costSPOne;


    public string typeOfTyle;
    public int redeployT;
    //References
    public HealthBar healthbar;
    public SkillBar skillbar;
    public SkillPoints skillText;
    public GameObject[] range;
    public Transform parent;
    public GameObject destroyThis;
    public string nameOperator;

    private static FieldInfo[] costToAcess;
    private static Cost operatorToGetCost;


    public Text texto;
    

    void Start()
    {
        deployManager = DeployManager.instance;
        nameOperator = parent.name;
        blockInicial = block;
        range = GameObject.FindGameObjectsWithTag(nameOperator);
        foreach (GameObject tile in range)
        {
            tile.GetComponent<Renderer>().enabled = false;
        }

        //Bars 

        currentHP = baseHP;
        healthbar.setMaxHealth(baseHP);
        skillbar.setInitialSkill(costSPOne, initialSPOne);
        
        //Skills
        if (skillTypeOfCharge == "automatic")
        {
            InvokeRepeating("ChargeSkill", 0.1f, 1f);
        }
        
        //Cost
        operatorToGetCost = GameObject.Find("GameMaster").GetComponent<Cost>();
        Type operatorCosts = typeof(Cost);
        FieldInfo[] operators = operatorCosts.GetFields();
        costToAcess = operators;
        foreach (FieldInfo coste in costToAcess)
        {
            string name = coste.Name;
            object valueCost = coste.GetValue(operatorToGetCost);
            int result = Convert.ToInt32(valueCost);
            if (name == nameOperator)
            {
                cost = result;
            }
        }
    }

    

    void ChargeSkill()
    {
        initialSPOne++;
        //Debug.Log(initialSPOne);
        if (initialSPOne == costSPOne)
        {
            skillText.setTextSkill(initialSPOne);
            CancelInvoke();
            return;
        }
        skillbar.setSkill(initialSPOne);
        skillText.setTextSkill(initialSPOne);
        
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        healthbar.setHealth(currentHP);
    }

    public void GetHeal(int heal)
    {
        currentHP += heal;
        if(currentHP >= baseHP)
        {
            currentHP = baseHP;
        }
        healthbar.setHealth(currentHP);
    }

    public void retreat()
    {
        ResetButton();
        Destroy(destroyThis);
    }

    public void ResetButton()
    {
        
        foreach (GameObject buton in deployManager.buttons)
        {
            if (nameOperator == buton.name)
            {
                ChangeStats();
                buton.SetActive(true);
                
            }
        }
    }

    public void ChangeStats()
    {
        int DPcostRetrat = cost/2;
        DPGenerator.DP += DPcostRetrat;
        foreach (FieldInfo coste in costToAcess)
        {
            string name = coste.Name;
            object valueCost = coste.GetValue(operatorToGetCost);
            int result = Convert.ToInt32(valueCost);
            if (name == nameOperator)
            {
                if (result == costCheck * 2)
                {
                    RedeployingTime.redeploy = true;
                    RedeployingTime.nameOperatorButton = nameOperator;
                    return;
                }
                result = cost * 2;
                coste.SetValue(valueCost, result);
                foreach (GameObject buton in deployManager.buttons)
                {
                    if (nameOperator == buton.name)
                    {
                        int RVB = 0;
                        int indexForReoder = 0;
                        buton.transform.SetSiblingIndex(indexForReoder);
                        string reoderValueButon;
                        texto = buton.GetComponentInChildren<Text>();
                        texto.text = result.ToString();
                        RedeployingTime.redeploy = true;
                        RedeployingTime.nameOperatorButton = nameOperator;
                        
                        foreach (GameObject butonReoder in deployManager.buttons)
                        {
                            reoderValueButon = butonReoder.GetComponentInChildren<Text>().text;
                            RVB = Convert.ToInt32(reoderValueButon);
                            if (result > RVB)
                            {
                                indexForReoder += 1;
                                buton.transform.SetSiblingIndex(indexForReoder);
                            }
                        }
                    }
                }
            }
        }
    }
}
