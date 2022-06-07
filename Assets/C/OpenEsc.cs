using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEsc : MonoBehaviour
{
    public bool jaja = false;
    public GameObject aoao;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           jaja =! jaja;
        }
        if (jaja)
        {
            
           

            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.visible = jaja;
        aoao.SetActive(jaja);
    }

}
