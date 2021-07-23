using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionToEnd : MonoBehaviour
{
    public Text TLP;
    public Text ALP;
    private string TLPString;
    private string ALPString;
    // Start is called before the first frame update
    void Start()
    {
        TLPString = TLP.text;
        ALPString = ALP.text;
    }

    // Update is called once per frame
    void Update()
    {
        ALPString = ALP.text;
        if(TLPString == ALPString)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
