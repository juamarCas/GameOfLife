using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils.Raycasting
{
   
    public class RaycastHelper
    {
        private Camera cam; 
        public RaycastHelper()
        {
            cam = Camera.main; 
        }

        public GameObject RayTo(LayerMask desiredLayer, bool is3d = true)
        {
           
            
                if (is3d)
                {
                     RaycastHit hit;
                     Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                     if (Physics.Raycast(ray, out hit, Mathf.Infinity, desiredLayer))
                     {
                         return hit.transform.gameObject;
                     }
                }
                else
                {
                    RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, desiredLayer);
                    if(hit.collider != null)
                    {
                          return hit.collider.gameObject; 
                    }
                    
                }
            

            return null;
        }

        public Vector3 RayTo(LayerMask desiredMask, Transform t) //overcharge
        {

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, desiredMask))
                {
                    return hit.transform.position; 
                }
            }
            return t.position;
        }
    }
}