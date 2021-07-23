 using UnityEngine;
 using System;
 using System.Collections;
 using System.Reflection;
 using UnityEngine.UI;

public class Deploy : MonoBehaviour
{
    DeployManager deployManager;


    public operatorBlueprint Mrythle;
    public operatorBlueprint Siege;
    public operatorBlueprint Jessica;
    public operatorBlueprint Shining;
    private bool activeSiege;
    private bool activeMrythle;
    private bool activeJessica;
    private bool activeShining;
    public string range;
    public GameObject[] tiles;
    private Renderer rend;
    public Color hoverColor;
    public Color startcolor;

    //Referencias al coste
    private static FieldInfo[] costToA;
    private static Cost operatorToGetCost;
    
    void Start()
    {
        deployManager = DeployManager.instance;
        activeMrythle = true;
        activeSiege = true;
        activeJessica = true;
        activeShining = true;

        operatorToGetCost = GameObject.Find("GameMaster").GetComponent<Cost>();
        Type operatorCosts = typeof(Cost);
        //FieldInfo[] operators = operatorCosts.GetFields();
        //costToA = operators;
        costToA = operatorCosts.GetFields();
    }
 
    public void DeploySiegeOperator()
    {
        deployManager.selectOperatorToDeploy(Siege);
        foreach (FieldInfo coste in costToA)
        {
            string name = coste.Name;
            object valueCost = coste.GetValue(operatorToGetCost);
            int result = Convert.ToInt32(valueCost);
            if (Siege.prefab.name == name)
            {
                if (DPGenerator.DP >= result)
                {
                    //Activar las casillas en verde al pulsar la cara del personaje en la barra de deploy
                    if (activeSiege == true)
                    {
                        range = Siege.prefab.GetComponent<Estadisticas>().typeOfTyle;
                        tiles = GameObject.FindGameObjectsWithTag(range);
                        foreach (GameObject tile in tiles)
                        {
                            rend = tile.GetComponent<Renderer>();
                            rend.material.color = hoverColor;
                        } 
                        activeSiege = false;
                    }
                    //Desactivar las casillas en verde al pulsar otra vez la cara del personaje en la barra de deploy
                    else
                    {
                        deployManager.selectOperatorToDeploy(null);
                        range = Siege.prefab.GetComponent<Estadisticas>().typeOfTyle;
                        tiles = GameObject.FindGameObjectsWithTag(range);
                        foreach (GameObject tile in tiles)
                        {
                            rend = tile.GetComponent<Renderer>();
                            rend.material.color = startcolor;
                        } 
                        activeSiege = true;
                    }
                }
            }  
        }
    }

    public void DeployMyrthleOperator()
    {
        deployManager.selectOperatorToDeploy(Mrythle);
        foreach (FieldInfo coste in costToA)
        {
            string name = coste.Name;
            object valueCost = coste.GetValue(operatorToGetCost);
            int result = Convert.ToInt32(valueCost);
            if (Mrythle.prefab.name == name)
            {
                if (DPGenerator.DP >= result)
                {
                    if (activeMrythle == true)
                    {
                        range = Mrythle.prefab.GetComponent<Estadisticas>().typeOfTyle;
                        tiles = GameObject.FindGameObjectsWithTag(range);
                        foreach (GameObject tile in tiles)
                        {
                            rend = tile.GetComponent<Renderer>();
                            rend.material.color = hoverColor;
                        } 
                        activeMrythle = false;
                    }else
                    {
                        deployManager.selectOperatorToDeploy(null);
                        range = Mrythle.prefab.GetComponent<Estadisticas>().typeOfTyle;
                        tiles = GameObject.FindGameObjectsWithTag(range);
                        foreach (GameObject tile in tiles)
                        {
                            rend = tile.GetComponent<Renderer>();
                            rend.material.color = startcolor;
                        } 
                        activeMrythle = true;
                    }
                }
            }  
        }
    }

    public void DeployJessicaOperator()
    {
        deployManager.selectOperatorToDeploy(Jessica);
        foreach (FieldInfo coste in costToA)
        {
            string name = coste.Name;
            object valueCost = coste.GetValue(operatorToGetCost);
            int result = Convert.ToInt32(valueCost);
            if (Jessica.prefab.name == name)
            {
                if (DPGenerator.DP >= result)
                {
                    if (activeJessica == true)
                    {
                        range = Jessica.prefab.GetComponent<Estadisticas>().typeOfTyle;
                        tiles = GameObject.FindGameObjectsWithTag(range);
                        foreach (GameObject tile in tiles)
                        {
                            rend = tile.GetComponent<Renderer>();
                            rend.material.color = hoverColor;
                        } 
                        activeJessica = false;
                    }else
                    {
                        deployManager.selectOperatorToDeploy(null);
                        range = Jessica.prefab.GetComponent<Estadisticas>().typeOfTyle;
                        tiles = GameObject.FindGameObjectsWithTag(range);
                        foreach (GameObject tile in tiles)
                        {
                            rend = tile.GetComponent<Renderer>();
                            rend.material.color = startcolor;
                        } 
                        activeJessica = true;
                    }
                }
            }  
        }
    }

    public void DeployShiningOperator()
    {
        deployManager.selectOperatorToDeploy(Shining);
        foreach (FieldInfo coste in costToA)
        {
            string name = coste.Name;
            object valueCost = coste.GetValue(operatorToGetCost);
            int result = Convert.ToInt32(valueCost);
            if (Shining.prefab.name == name)
            {
                if (DPGenerator.DP >= result)
                {
                    if (activeShining == true)
                    {
                        range = Shining.prefab.GetComponent<Estadisticas>().typeOfTyle;
                        tiles = GameObject.FindGameObjectsWithTag(range);
                        foreach (GameObject tile in tiles)
                        {
                            rend = tile.GetComponent<Renderer>();
                            rend.material.color = hoverColor;
                        } 
                        activeShining = false;
                    }else
                    {
                        deployManager.selectOperatorToDeploy(null);
                        range = Shining.prefab.GetComponent<Estadisticas>().typeOfTyle;
                        tiles = GameObject.FindGameObjectsWithTag(range);
                        foreach (GameObject tile in tiles)
                        {
                            rend = tile.GetComponent<Renderer>();
                            rend.material.color = startcolor;
                        } 
                        activeShining = true;
                    }
                }
            }  
        }
    }
}
