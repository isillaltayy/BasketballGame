using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemType itemType;

    public Material material;
    public Vector3 scale;
    public float mass;
    public float PingPongVelocity;

    private void Start()
    {
        material = itemType.material;
        scale = itemType.scale;
        mass = itemType.mass;
        PingPongVelocity = itemType.PingPongVelocity;
    }
}
