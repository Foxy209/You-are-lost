using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.Examples;

public class NotesHadle : MonoBehaviour
{
    [SerializeField] private Text textScore;
    public GameObject mon;
    public GameObject monstr;
    [SerializeField] private int _notes;
    [SerializeField] private Transform _eyes;
    [SerializeField] private GameObject _spotlight;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(_eyes.position, _eyes.forward, out hit, 15f))
            {
                if (hit.collider.gameObject.name.Contains("Note"))
                {
                    _notes++;
                    Destroy(hit.collider.gameObject);
                    textScore.text = "Note = " + _notes.ToString();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            _spotlight.SetActive(!_spotlight.activeSelf);
        }
        if (_notes == 6)
        {
            monstr.active = true;
            Destroy(mon);
        }
    }
}
