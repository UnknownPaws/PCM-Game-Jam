using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnInteract : MonoBehaviour
{
    [SerializeField] private GameObject toDelete;
    [SerializeField] private CrosshairChange crosshair;

    private void Start()
    {
        if (toDelete == null)
        {
            toDelete = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = crosshair.GetRaycast();

        if (Input.GetAxis("Fire1") > 0.5 && crosshair.CheckHit() && hit.collider.CompareTag("Canvas"))
        {
//            toDelete.SetActive(false); // This would deactivate any firther potential to run other scripts on the same gameObject

            // This on the other hand allows scripts on the object to run (to open canvas HUD) but it will disapear for player
            toDelete.GetComponent<MeshRenderer>().enabled = false;
            toDelete.GetComponent<SphereCollider>().enabled = false;
        }
    }
}