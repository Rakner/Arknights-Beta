using UnityEngine;
using System.Collections;
using System.Threading;

public class WaveSpawner : MonoBehaviour
{
   public Transform slugPrefab;
   public Transform soldierPrefab;
   public Transform spwanPoint;
   public static int ID; 

   public static float[] waves = new float[11] {5f, 11f, 2f, 11f, 0.7f, 4.3f, 11f, 0.7f, 6.3f, 0.7f, 11.7f};

   private int indice = 0;

   private void Start()
     {
        
     }

   void Update()
   {
        if (waves[indice] <= 0f)
        {
            spawnWave();       
        }
        waves[indice] -= Time.deltaTime;
    }
       
   void spawnWave()
   {
        spawnEnemy();
        if (indice == 10)
        {
            enabled = false;
        }else
        {
          indice++;  
        }
   }

   void spawnEnemy()
   {
      if(indice == 10){
        ID += 1;
        Instantiate(soldierPrefab, spwanPoint.position, spwanPoint.rotation);
        
      }else{
        ID += 1;
        Instantiate(slugPrefab, spwanPoint.position, spwanPoint.rotation);
        
      } 
   }
}
