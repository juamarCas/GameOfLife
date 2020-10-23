using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{

    //properties  
    [SerializeField] private Color deadColor;
    [SerializeField] private Color aliveColor; 

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

    public void Kill()
    {
        isAlive = false;
        renderer.material.SetColor("_Color", deadColor);
      
    }

    public void Revive()
    {
        isAlive = true;
        renderer.material.SetColor("_Color", aliveColor);
        
    }
 

}
