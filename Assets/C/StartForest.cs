using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartForest : MonoBehaviour
{
    void meny()
    {
        Application.LoadLevel("Forest");
    }

    void Update()
    {
        Invoke(nameof(meny), 4);
    }
}
