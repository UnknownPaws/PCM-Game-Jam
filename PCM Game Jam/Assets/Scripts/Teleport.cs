using System;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [SerializeField] private Transform p_transform;
    [SerializeField] private Transform topHorseshoe;
    [SerializeField] private Transform bottomHorseshoe;
    [SerializeField] private Transform realHorseshoe;

    public string[] collidedWith = { "Real", "false" };
    private float xDiff;
    private float zDiff;

    // Update is called once per frame
    private void Update()
    {
        if (Convert.ToBoolean(collidedWith[2]))
        {

        }
    }
}
