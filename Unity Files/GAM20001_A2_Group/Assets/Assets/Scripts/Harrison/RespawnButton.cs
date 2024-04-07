using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnButton : MonoBehaviour
{
    #region Fields

    private Button _button;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(RespawnPlayer); 
    }

    void RespawnPlayer()
    {
        Debug.Log("Respawn");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(-14.3f, 0.01f, -2f);
            player.transform.rotation = Quaternion.identity;
        }
    }
}
