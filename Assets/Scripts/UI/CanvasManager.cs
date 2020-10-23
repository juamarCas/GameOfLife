using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public  GameManager instance;
    public GameObject inputText; 
  
    public void Next()
    {
        if(!instance.automatic)
            instance.NextFrame(); 
    }

    public void Clear()
    {
        instance.Clear(); 
    }

    public void UpdateText()
    {
        
        string text = inputText.GetComponent<TMP_InputField>().text;
        float val = float.Parse(text, System.Globalization.CultureInfo.InvariantCulture);
        instance.SetWaitTime(val); 
    }

    public void Toggle()
    {
        instance.SetAutomatic(); 
    }
}
