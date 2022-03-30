using UnityEngine;

public class TriggerCollision : MonoBehaviour
{
    [SerializeField] private Teleport tp;

    private void OnTriggerEnter(Collider other)
    {
        tp.collidedWith[0] = other.tag;
        tp.collidedWith[1] = "true";
    }
}
