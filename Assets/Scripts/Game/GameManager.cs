using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton 
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this); 
        }
    }
    #endregion
    Spawner spawner;

    private int row; 
    private int col;
    private int counter = 0;

    public float waitTime = 0.7f; 

    public int size; //size of the matrix, it will be a square matrix
    public Transform spawnPos;

    public GameObject cell;
    
    public float xInit;
    public float yInit;
    public float offset = 1.0f;

    public bool automatic = false;
    [SerializeField]private bool next = true; 
   
    public List<List<GameObject>> cells; //10 lists of ten cells, to a total of 100 cells 

    void Start()
    {
        cells = new List<List<GameObject>>();
 
        spawnPos.transform.position = new Vector3(xInit, yInit, 0f); 
        spawner = new Spawner(spawnPos, cell);
        CreateMatrix(); 
    }

    private void Update()
    {
        if (automatic)
        {
            if (next)
            {
                next = false; 
                NextFrame();
                StartCoroutine(Wait()); 
            }
        }
    }

    void CreateMatrix()
    {
        for(int i = 0; i < size; i++)
        {
            List<GameObject> cellsList = new List<GameObject>();
            for(int j = 0; j < size; j++)
            {
                GameObject obj = spawner.Spawn();
                obj.GetComponent<Cell>().row = i;
                obj.GetComponent<Cell>().col = j;
                spawnPos.transform.position = new Vector3(spawnPos.transform.position.x + offset, spawnPos.transform.position.y, 0); 
                cellsList.Add(obj);                
            }
            cells.Add(cellsList);
            spawnPos.transform.position = new Vector3(xInit, spawnPos.transform.position.y - offset, 0);
        }
    }
    

    public void NextFrame()
    {
        for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                counter = 0; 
                if(!(i - 1 < 0 || j - 1 < 0))
                {
                 
                    if (cells[i - 1][j - 1].GetComponent<Cell>().isAlive)
                    {
                        counter++; 
                    }
                    
                }
                
                if (!(i - 1 < 0))
                {
                   
                    if (cells[i - 1][j].GetComponent<Cell>().isAlive)
                    {
                        counter++;
                    }
                 
                }

                if (!(i - 1 < 0 || j + 1 >= size))
                {
                   
                    if (cells[i - 1][j + 1].GetComponent<Cell>().isAlive)
                    {
                        counter++;
                    }
              
                }

                if (!(j - 1 < 0))
                {
                   
                    if (cells[i][j - 1].GetComponent<Cell>().isAlive)
                    {
                        counter++;
                    }
                 
                }

                if (!(j + 1 >= size))
                {
              
                    if (cells[i][j + 1].GetComponent<Cell>().isAlive)
                    {
                        counter++;
                    }
                    
                }

                if(!(i + 1 >= size || j - 1 < 0))
                {
                  
                    if (cells[i + 1][j - 1].GetComponent<Cell>().isAlive)
                    {
                        counter++;
                    }
                   
                }

                if (!(i + 1 >= size))
                {
              
                    if (cells[i + 1][j].GetComponent<Cell>().isAlive)
                    {
                        counter++;
                    }
                   
                }

                if (!(i + 1 >= size || j + 1 >= size))
                {
                  
                    if (cells[i + 1][j + 1].GetComponent<Cell>().isAlive)
                    {
                        counter++;
                    }
                   
                }
                Debug.Log("Cell at row: " + cells[i][j].GetComponent<Cell>().row + "And col: " + cells[i][j].GetComponent<Cell>().col + "Has counter: " + counter);

                //Checking how is the next state 
                if (cells[i][j].GetComponent<Cell>().isAlive && (counter < 2 || counter > 3))
                {
                    Debug.Log("Die"); 
                    cells[i][j].GetComponent<Cell>().nextState = false;
                }
                else
                {
                    cells[i][j].GetComponent<Cell>().nextState = true;
                }

                if(!cells[i][j].GetComponent<Cell>().isAlive && counter == 3)
                {
                    Debug.Log("revive");
                    cells[i][j].GetComponent<Cell>().nextState = true;
                }
                else if (!cells[i][j].GetComponent<Cell>().isAlive && counter != 3)
                {
                    cells[i][j].GetComponent<Cell>().nextState = false;
                }
                
                
            }

           
        }

        foreach(List<GameObject> c in cells)
        {
            foreach(GameObject go in c)
            {
                if (go.GetComponent<Cell>().nextState)
                {
                    go.GetComponent<Cell>().Revive();
                }
                else
                {
                    go.GetComponent<Cell>().Kill(); 
                }
            }
        }
    }

    public void Clear()
    {
        foreach (List<GameObject> c in cells)
        {
            foreach (GameObject go in c)
            {
                go.GetComponent<Cell>().Kill(); 
            }
        }
    }

    public void SetAutomatic()
    {
        automatic = !automatic; 
    }
    IEnumerator Wait()
    {
       yield return new WaitForSeconds(waitTime);
        next = true;
    }

    public void SetWaitTime(float t)
    {
        waitTime = t; 
    }
    
}
