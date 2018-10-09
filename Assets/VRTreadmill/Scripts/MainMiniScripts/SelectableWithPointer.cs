using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableWithPointer : MonoBehaviour
{

    public Jumpable jumpStatus;
    public GameObject highlighter;
    public PlayerMovement playerMovement;

    public void selected()
    {
        Debug.Log("got in selected");
        if (playerMovement == null)
        {
            playerMovement = GameObject.FindGameObjectWithTag("PlayerMovement").GetComponent<PlayerMovement>();
        }

        if (jumpStatus.jumpable)
        {
            highlighter.SetActive(true);
            playerMovement.toLocation = gameObject.transform;
        }
    }

    public void unselected()
    {
        Debug.Log("got in UNselected");
        highlighter.SetActive(false);
        playerMovement.toLocation = null;
    }

}
