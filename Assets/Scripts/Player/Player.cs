using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Raycasting; 

public class Player : MonoBehaviour
{

    RaycastHelper raycastHelper;
    [SerializeField] private LayerMask layer; 
    // Start is called before the first frame update
    void Start()
    {
        raycastHelper = new RaycastHelper(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             GameObject cell = raycastHelper.RayTo(layer, false);
            if(cell != null)
            {
                cell.GetComponent<Cell>().Revive();            
            }
        }
    }
}
