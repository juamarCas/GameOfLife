using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    //properties  
    [SerializeField] private Color deadColor;
    [SerializeField] private Color aliveColor;
    [SerializeField] private Color DebugColor;
    [SerializeField] private Color PrevColor;

    public bool isAlive;
    public bool nextState; 
    public int row { get; set; }
    public int col { get; set; }

    private Renderer renderer; 
    // Start is called before the first frame update
    void Start()
    {
        isAlive = false;
        nextState = false; 
        deadColor = Color.black;
        aliveColor = Color.white; 
        renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", deadColor); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill()
    {
        isAlive = false;
        renderer.material.SetColor("_Color", deadColor);
        PrevColor = deadColor; 
    }

    public void Revive()
    {
        isAlive = true;
        renderer.material.SetColor("_Color", aliveColor);
        PrevColor = aliveColor; 
    }


    public void Debug()
    {
        renderer.material.SetColor("_Color", DebugColor);
    }

    public void ClearDebug()
    {
        renderer.material.SetColor("_Color", PrevColor);
    }


}
