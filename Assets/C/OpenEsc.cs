using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenEsc : MonoBehaviour
{

    public GameObject aoao;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            aoao.SetActive(!aoao.activeSelf);
        }
    }
}
