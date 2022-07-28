using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morge : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") ;
        Application.LoadLevel("morge2");
    }
}
