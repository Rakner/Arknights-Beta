using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System;


public class DeployColor : MonoBehaviour
{
    public operatorBlueprint op;
    public GameObject Hovercolor;
    public Image color;

    private static FieldInfo[] costToA;
    private static Cost operatorToGetCost;

    // Start is called before the first frame update
    void Start()
    {
        color = Hovercolor.GetComponent<Image>();
        operatorToGetCost = GameObject.Find("GameMaster").GetComponent<Cost>();
        Type operatorCosts = typeof(Cost);
        //FieldInfo[] operators = operatorCosts.GetFields();
        //costToA = operators;
        costToA = operatorCosts.GetFields();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (FieldInfo coste in costToA)
        {
            string name = coste.Name;
            object valueCost = coste.GetValue(operatorToGetCost);
            int result = Convert.ToInt32(valueCost);
            if (op.prefab.name== name)
            {
                if (DPGenerator.DP >= result )
                {
                    color.enabled = false;
                }else
                {
                    color.enabled = true;
                }
            }
        }
    }
}
