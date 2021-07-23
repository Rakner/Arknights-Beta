using UnityEngine;

public class Tiles : MonoBehaviour
{
    public string typeTile;
    public Color hoverColor;
    public Color startColor;
    private Renderer rend;
    DeployManager deployManager;
    public GameObject character;
    
    

    void Start()
    {
        character = null;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        deployManager = DeployManager.instance;
    }

    void OnMouseDown()
    {
        if(!deployManager.CanDeploy)
           return;
        
        deployManager.deployOperatorOn(this);

        
    }
}
