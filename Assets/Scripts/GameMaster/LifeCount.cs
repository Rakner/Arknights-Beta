using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Text lifepoints;
    public Text enemies;
    public int enemiesDefeated = 0;
    public int lifepoint = 20;

    void Start()
   {
       lifepoints = GameObject.Find("LifePoints").GetComponent<Text>();
       enemies = GameObject.Find("Enemies Defeated").GetComponent<Text>();
   }

      public void adjustLifeCount()
    {
        enemiesDefeated++;
        lifepoint--;
        enemies.text = enemiesDefeated.ToString();
        lifepoints.text = lifepoint.ToString();
    }

    public void enemyDefeated()
    {
        enemiesDefeated++;
        enemies.text = enemiesDefeated.ToString();
    }
}
