using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mostrarInfo : MonoBehaviour
{
    public GameObject info;

    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.Find("StartLvL0-1");
        info.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarInfo()
    {
        info.SetActive(true);
    }

   
}
