using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ocultarInfo : MonoBehaviour
{
     public GameObject[] info;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        info = GameObject.FindGameObjectsWithTag("informacionDelNivel");
    }
    
    public void DesactivarInfo()
    {
        if(info == null)
        {

        }else
        {
            foreach (GameObject nivel in info)
            {
               nivel.SetActive(false); 
            }
            
        }
        
    }
}
