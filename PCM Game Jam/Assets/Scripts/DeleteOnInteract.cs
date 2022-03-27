using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnInteract : MonoBehaviour
{
    [SerializeField] private GameObject toDelete;
    [SerializeField] private CrosshairChange crosshair;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        var hit = crosshair.CheckHit();

        if (hit && Input.GetAxis("Fire1") != 0)
        {
            toDelete.SetActive(false);
        }
    }
}