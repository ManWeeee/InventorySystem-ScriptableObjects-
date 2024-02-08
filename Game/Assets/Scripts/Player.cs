using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Inventory _inventory;

    public Inventory Inventory { get { return _inventory; } }
}
