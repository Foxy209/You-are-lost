using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesHadle : MonoBehaviour
{
    [SerializeField] private int _notes;
    [SerializeField] private Transform _eyes;
    [SerializeField] private GameObject _spotlight;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(_eyes.position, _eyes.forward, out hit, 50f))
            {
                if (hit.collider.gameObject.name.Contains("Note"))
                {
                    _notes++;
                    Destroy(hit.collider.gameobject);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            _spotlight.SetActive(!_spotlight.activaSelf);
        }
    }
}
