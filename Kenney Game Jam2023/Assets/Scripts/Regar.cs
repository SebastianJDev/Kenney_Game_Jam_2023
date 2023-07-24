using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Regar : MonoBehaviour
{
    public Transform Slot;
    public UnityEvent OnRegar;


    public void Comprobar()
    {
        if (Slot.childCount == 1)
        {
            Destroy(Slot.GetChild(0).gameObject);
            OnRegar.Invoke();
        }
    }
}
