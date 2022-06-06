using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndForest : MonoBehaviour
{
   
    void Start()
    {
        
    }
    void meny()
    {
        Application.LoadLevel("Menu");
    }
    
    void Update()
    {
        Invoke(nameof(meny), 13);
    }
}
    
