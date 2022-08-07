using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audi_Its_car : MonoBehaviour
{
    public GameObject son;
    void soud()
    {
        son.active = true;
    }


    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(son), 1);
    }
}
