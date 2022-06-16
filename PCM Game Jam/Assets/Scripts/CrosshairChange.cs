using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairChange : MonoBehaviour
{

    //can this script can be used for other things other than canvas?
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject interact;
    [SerializeField] [Range(0f, 20f)] private float rayDistance;

    private RaycastHit hit;

    private void Update()
    {

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * rayDistance),
            CheckHit() ? Color.green : Color.red, 0.01f);
        if (CheckHit())
        {
            interact.SetActive(true);
            circle.SetActive(false);
        }
        else
        {
            interact.SetActive(false);
            circle.SetActive(true);
        }
    }

    public bool CheckHit()
    {
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, LayerMask.GetMask("Interactable"));
    }

    public RaycastHit GetRaycast()
    {
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayDistance, LayerMask.GetMask("Interactable"));
        return hit;
    }

    private void FixedUpdate()
    {
        GetRaycast();
    }
}