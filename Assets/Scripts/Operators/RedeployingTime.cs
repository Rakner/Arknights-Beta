 using UnityEngine;
 using System;
 using System.Collections;
 using System.Reflection;
 using UnityEngine.UI;

public class RedeployingTime : MonoBehaviour
{
    DeployManager deployManager;
    public static bool redeploy = false; 
    public static string nameOperatorButton;

    private static FieldInfo[] redeployToAcess;
    private static RedeployTimes operatorToGetRedeploy;

    private bool checkSiege = true;
    private bool checkMyrthle = true;
    private string siege;
    private string myrthle;

    // Start is called before the first frame update
    void Start()
    {
        deployManager = DeployManager.instance;
        operatorToGetRedeploy = GameObject.Find("GameMaster").GetComponent<RedeployTimes>();
        Type operatorRedeploy = typeof(RedeployTimes);
        FieldInfo[] operators = operatorRedeploy.GetFields();
        redeployToAcess = operators;
    }

    // Update is called once per frame
    void Update()
    {
        if (redeploy == true)
        {
            foreach (FieldInfo redp in redeployToAcess)
            {
                //string name = redp.Name;
                if (redp.Name == nameOperatorButton)
                {
                    object valueredp = redp.GetValue(operatorToGetRedeploy);
                    int result = Convert.ToInt32(valueredp);
                    
                        foreach (GameObject buton in deployManager.buttons)
                        {
                            if (nameOperatorButton == buton.name)
                            {
                                buton.GetComponent<Button>().interactable = false;
                            }
                        }
                        Debug.Log(nameOperatorButton);
                        InvokeRepeating(nameOperatorButton, 0f, 1f); 
                        redeploy = false; 
                }
            }
        }
    }

    public void Siege()
    {
        Text sText = GameObject.Find("SiegeText").GetComponent<Text>();
        if (checkSiege == true)
        {
            siege = nameOperatorButton;
            checkSiege = false;
        }
        foreach (FieldInfo redp in redeployToAcess)
        {
            //string name = redp.Name;
            if (redp.Name == siege)
            {
                object valueredp = redp.GetValue(operatorToGetRedeploy);
                int result = Convert.ToInt32(valueredp);
                sText.text = result.ToString();
                if(result == 0)
                {
                    foreach (GameObject buton in deployManager.buttons)
                    {
                        if (siege == buton.name)
                        {
                            buton.GetComponent<Button>().interactable = true;
                            redp.SetValue(valueredp, 70);
                            checkSiege = true;
                            sText.text = null;
                            CancelInvoke();
                        }
                    }
                }else
                {
                    result -=1;
                    redp.SetValue(valueredp, result); 
                }
            }
        }
    }

    public void Myrthle()
    {
        Text mText = GameObject.Find("MyrthleText").GetComponent<Text>();
        if (checkMyrthle == true)
        {
            myrthle = nameOperatorButton;
            checkMyrthle = false;
        }
        foreach (FieldInfo redp in redeployToAcess)
        {
            string name = redp.Name;
            if (name == myrthle)
            {
                object valueredp = redp.GetValue(operatorToGetRedeploy);
                int result = Convert.ToInt32(valueredp);
                mText.text = result.ToString();
                if(result == 0)
                {
                    foreach (GameObject buton in deployManager.buttons)
                    {
                        if (myrthle == buton.name)
                        {
                            buton.GetComponent<Button>().interactable = true;
                            redp.SetValue(valueredp, 70);
                            checkMyrthle = true;
                            mText.text = null;
                            CancelInvoke();
                        }
                    }
                }else
                {
                   result -=1;
                    redp.SetValue(valueredp, result); 
                }
            }
        }
    }
}
