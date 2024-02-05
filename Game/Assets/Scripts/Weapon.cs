using UnityEngine;

public class Weapon : Item
{
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _strength;

    public void DealDamage()
    {
        //Some Logic
    }
}
