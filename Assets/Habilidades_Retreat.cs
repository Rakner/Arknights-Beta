using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Habilidades_Retreat : MonoBehaviour
{
    public string nombreRetratAndSkill;
    public string nombreRango;
    public GameObject menu;
    public GameObject rango;
    void Start()
    {
        menu = GameObject.Find(nombreRetratAndSkill);
        rango = GameObject.Find(nombreRango);
        menu.SetActive(false);
        rango.SetActive(false);
    }

    void OnMouseDown()
    {
        if(menu.activeSelf)
        {
            menu.SetActive(false);
            rango.SetActive(false); 
        }else
        {
            menu.SetActive(true);
            rango.SetActive(true);
        }
    }
}
