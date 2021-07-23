using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsSiege : MonoBehaviour
{
    public Estadisticas stats;
    public Text DPpoints;

    // Start is called before the first frame update
    void Start()
    {
       
        DPpoints = GameObject.Find("Cost").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.initialSPOne == stats.costSPOne)
        {
            if (DPGenerator.DP == 99)
            {
                stats.initialSPOne = 0;
                return;
            }
            DPGenerator.DP += 12;
            if (DPGenerator.DP > 99)
            {
                DPGenerator.DP = 99;
            }
            stats.initialSPOne = 0;
        }
    }
}
