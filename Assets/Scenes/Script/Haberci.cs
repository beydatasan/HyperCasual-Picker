using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Haberci : MonoBehaviour
{
    [SerializeField] private GameManager _GameManager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ToplayiciSýnýrObjesi"))
        {
            _GameManager.SiniraGelindi();

        }
    } 
    

}
