using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;


    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }


    public int GetCurrentAmmo()
    {
        return ammoAmmount;
    }

    public void ReduceCurrentAmmo()
    {
        ammoAmmount--;
    }

}
