 using UnityEngine;
 using System;
 using System.Collections;
 using System.Reflection;
 using UnityEngine.UI;
public class EnemyStats : MonoBehaviour
{
    //Stats
    public float speed = 1f;
    private int blockNeed = 1;
    public int baseHP = 550;
    public int currentHP;
    public int atk = 130;
    public float atkSpeed = 1.7f;
    public int def = 0;
    public int res = 0;
    private int wavepointIndex = 0;
    public int ID;
    //References 
    public HealthBar healthbar;
    private Transform target;
    public Transform parent;
    public string enemyName;
    public LifeCount lifecount;
    public GameObject[] enemies;
    public EnemyStats enemiesID;
    public Transform me;
    //References for dmg
    public Estadisticas operatorBlocking;
    public int damage;
    public int operatorDef;
    public int minimunDamage;
    //Reset de daño
    public IsThisRange reset;
    public int originalBlock;



   void Start()
   {
       ID = WaveSpawner.ID;
       lifecount = GameObject.Find("GameMaster").GetComponent<LifeCount>();
       target = Waypoints.points[wavepointIndex];
       currentHP = baseHP;
       healthbar.setMaxHealth(baseHP);
   }

   void Update()
   {
       Vector3 dir = target.position - transform.position;
       transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

       if (Vector3.Distance(transform.position, target.position) <= 0.2f)
       {
            if(enemyName == "Soldier(Clone)" && wavepointIndex == 0)
            {
                StartCoroutine(GetNetxWaypointWithWait());  
            }else
            {
                GetNetxWaypoint();
            }
       }

       if (operatorBlocking == null || operatorBlocking.block == -1)
       {
           speed = 1f;
       }
   }

   void GetNetxWaypoint()
   {
       if (wavepointIndex >= Waypoints.points.Length - 1)
       {
           lifecount.adjustLifeCount();
           Destroy(gameObject);
           return; 
       }
       if(enemyName == "Soldier(Clone)" && wavepointIndex == 0 )
       {
           return;
       }else
       {
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];  
       }

   }

   IEnumerator GetNetxWaypointWithWait()
    {
        yield return new WaitForSeconds(3);
        if(wavepointIndex == 0)
        {
            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
        }else
        {
            yield return null;
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        operatorBlocking = collision.GetComponent<Estadisticas>();
    }

    void OnTriggerStay(Collider collision) 
    { 
        if (operatorBlocking == null){}
        else
        {
            if (speed == 0)
            {
                
            }else
            {
              if (operatorBlocking.block >= blockNeed)
                {
                    speed = 0;
                    enemies =  GameObject.FindGameObjectsWithTag("enemy");
                    if(enemies.Length == 1){}
                    else
                    {
                        foreach (GameObject enem in enemies)
                        {
                            enemiesID = enem.GetComponent<EnemyStats>();
                            if(Vector3.Distance(enem.transform.position, me.position) <= 0.2f && ID != enemiesID.ID){transform.position = transform.position + new Vector3(0 , 0, 0.2f);}
                        }
                    }
                    operatorBlocking.block -=blockNeed;
                    InvokeRepeating("MakeDamage", 0.1f, atkSpeed); 
                }  
            }
            
        }
    }

    /*void OnTriggerExit()
    {
        operatorBlocking = null;
    }*/

    public void TakeDamage(int damage, string name)
    {
        currentHP -= damage;
        healthbar.setHealth(currentHP);
        if(currentHP <= 0)
        {
            if (speed == 0 && operatorBlocking.block < operatorBlocking.blockInicial)
            {
                operatorBlocking.block += blockNeed;           
            }
            reset = GameObject.FindGameObjectWithTag(name).GetComponent<IsThisRange>();
            reset.reset();
            lifecount.enemyDefeated();
            Destroy(gameObject);
            return; 
        }
    }

    public void MakeDamage()
    {
        if (operatorBlocking == null)
        {
            CancelInvoke();
            return;
        }
        operatorDef = operatorBlocking.baseDEF;
        damage = atk - operatorDef;
        minimunDamage = (atk*5)/100;
        if(damage <= 0)
        {
            damage = minimunDamage;
        } 
        operatorBlocking.TakeDamage(damage);
    }
}
