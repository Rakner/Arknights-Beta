using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DPGenerator : MonoBehaviour
{
    public Text DPpoints;
    public static int DP;
    public int startDP;


    void Start()
    {
      DP = startDP;
      DPpoints = GameObject.Find("Cost").GetComponent<Text>();
      DPpoints.text = DP.ToString();
      InvokeRepeating("generateDP", 1f, 1f);  
    }

    void generateDP()
    {
      if (DP >= 99)
        {
            return;
        }
        DP++;
        DPpoints.text = DP.ToString();
        
    }

}
