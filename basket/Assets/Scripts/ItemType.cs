using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemType : ScriptableObject
{
    public Material material;
    public Vector3 scale;
    public float mass;
    public float PingPongVelocity;
}
