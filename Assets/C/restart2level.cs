using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart2level : MonoBehaviour
{
    void meny()
    {
        Application.LoadLevel("morge2");
    }

    void Update()
    {
        Invoke(nameof(meny), 3);
    }
}
