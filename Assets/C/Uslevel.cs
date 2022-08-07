using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uslevel : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") ;
        Application.LoadLevel("morgeUs");
    }
}
