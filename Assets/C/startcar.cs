using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startcar : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    // Start is called before the first frame update
    void aaa()
    {
      one.active =  true;
      two.active = false;
        Destroy(two);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(aaa), 12);
    }
}
