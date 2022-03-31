using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] private Transform p_transform;
    [SerializeField] private Transform topHorseshoe;
    [SerializeField] private Transform bottomHorseshoe;
    [SerializeField] private Transform realHorseshoe;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private float tpWaitTime;

    [HideInInspector] public string[] collidedWith /* = new string[2]*/; //for some reason the commented code does not work for me
    private float xDiff;

    private void Start()
    {
        collidedWith = new string[2];
        /*collidedWith[0] = "Real";
        collidedWith[1] = "false";*/
    }

    private void Update()
    {
        if (Convert.ToBoolean(collidedWith[1]))
        {
            collidedWith[1] = "false";

            //Take the difference in x and z coords between the horseshoe collidor and the player then teleport them to the real horsehsoe to the position they were relative to the other horseshoe
            if (collidedWith[0] == ("Top"))
            {
                xDiff = topHorseshoe.position.x - p_transform.position.x;

                StartCoroutine("TeleportPlayer");
            }
            else if (collidedWith[0] == ("Bottom"))
            {
                xDiff = bottomHorseshoe.position.x - p_transform.position.x;

                StartCoroutine("TeleportPlayer");
            }

            //Debug.Log("Horseshoe: " + collidedWith[0] + "\nxDiff: " + xDiff);
        }
    }

    private IEnumerator TeleportPlayer()
    {
        Debug.Log(p_transform.eulerAngles.y);
        float y = p_transform.eulerAngles.y;
        movement.disabled = true;
        yield return new WaitForSeconds(tpWaitTime/2);
        p_transform.position = new Vector3(realHorseshoe.position.x + xDiff - 0.109f, realHorseshoe.position.y, realHorseshoe.position.z-0.88f); //These extra subtractions exist for fine tuning the telport
        p_transform.rotation = Quaternion.Euler(0, y + 180f, 0);
        yield return new WaitForSeconds(tpWaitTime/2);
        movement.disabled = false;
    }
}
