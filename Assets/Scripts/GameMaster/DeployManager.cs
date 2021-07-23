 using UnityEngine;
 using System;
 using System.Collections;
 using System.Reflection;
 using UnityEngine.UI;

public class DeployManager : MonoBehaviour
{
    public static DeployManager instance;
    public operatorBlueprint operatorToDeploy;
    public string range;
    public GameObject[] tiles;
    public GameObject[] buttons;
    private Renderer rend;
    public bool puedoHacerDeploy = false; 
    private static FieldInfo[] costToA;
    private static Cost operatorToGetCost;

    void Start(){ operatorToDeploy = null;}

    void Awake ()
    {
        instance = this;
        buttons = GameObject.FindGameObjectsWithTag("DeployButton");
        operatorToGetCost = GameObject.Find("GameMaster").GetComponent<Cost>();
        Type operatorCosts = typeof(Cost);
        costToA =  operatorCosts.GetFields();
        
    }

    public bool CanDeploy {get { return operatorToDeploy != null;} }


    public void selectOperatorToDeploy (operatorBlueprint operatorBP)
    {
        operatorToDeploy = operatorBP;
    }

    public void deployOperatorOn (Tiles tile)
    {
        if (operatorToDeploy == null){}
        else
        {
            foreach (FieldInfo coste in costToA)
            {
                string name = coste.Name;
                object valueCost = coste.GetValue(operatorToGetCost);
                int result = Convert.ToInt32(valueCost);
                if (name == operatorToDeploy.prefab.name)
                {
                    if(DPGenerator.DP < result)
                    {
                        return;
                    }
                    range = operatorToDeploy.prefab.GetComponent<Estadisticas>().typeOfTyle;
                    if (range != tile.typeTile )
                    {
                        return;
                    }
                    DPGenerator.DP -= result;
                    GameObject operatorForDeploy = (GameObject)Instantiate(operatorToDeploy.prefab, tile.transform.position, tile.transform.rotation = Quaternion.AngleAxis(Rotation.positionToRotate, Vector3.up));
                    tile.character = operatorForDeploy;
                    tile.character.name = operatorToDeploy.prefab.name;
                    //Devolver el color
                    tiles = GameObject.FindGameObjectsWithTag(range);
                    foreach (GameObject til in tiles)
                    {
                        rend = til.GetComponent<Renderer>();
                        rend.material.color = tile.startColor;
                    }
                    //Quitar el boton
                    ButtonOff();
                }  
            }
        }
        operatorToDeploy = null;
    }

    private void ButtonOff()
    {
        foreach (GameObject buton in buttons)
        {
            if (operatorToDeploy.prefab.name == buton.name)
            {
                buton.SetActive(false);
               
            }
        }
         
    }
}
