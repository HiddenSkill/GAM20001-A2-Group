using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeMenu : MonoBehaviour
{

    public GameObject escapeMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        escapeMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Cancel") == 1)
        {
            toggleEscapeMenu();
            Debug.Log("Open escape menu");
        }
    }
    private void toggleEscapeMenu()
    {
        escapeMenuUI.SetActive(!escapeMenuUI.activeSelf);
    }
}
