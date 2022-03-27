using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairChange : MonoBehaviour
{
    [SerializeField]
    private GameObject circle;
    [SerializeField]
    private GameObject interact;
    [SerializeField]
    private LayerMask layer;
    [SerializeField] [Range(0f, 20f)]
    private float rayDistance;

    private bool hit;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * rayDistance), hit ? Color.green : Color.red, 0.01f);
        if (hit)
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

    private void FixedUpdate()
    {
        hit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), rayDistance, layer);
    }
}
