using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{

    [SerializeField] private Animator doorHinge;
    [SerializeField] private GameObject door;
    [SerializeField] private CrosshairChange rayCast;

    private void Start()
    {
        doorHinge = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = rayCast.GetRaycast();

        if (Input.GetAxis("Fire1") > 0.5 && rayCast.CheckHit() && hit.collider.CompareTag("Door"))
        {
            StartCoroutine(nameof(DoorAnim));
        }
    }

    private IEnumerator DoorAnim()
    {
        door.layer = LayerMask.NameToLayer("Ignore Raycast");
        doorHinge.SetBool("opened", true);
        yield return new WaitForSeconds(5);
        doorHinge.SetBool("opened", false);
        door.layer = LayerMask.NameToLayer("Interactable");
    }
}
