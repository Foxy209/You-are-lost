using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alternatuva : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        Application.LoadLevel("rai");
    }
}
