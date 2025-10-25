using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.iOS;

public class ItemGiver : MonoBehaviour
{
    [SerializeField] private OrbitManager orbitManager;
    [SerializeField] private GameObject itemPrefab;
    private int count = 3;




    public void Add()
    {
        orbitManager.AddRing(itemPrefab, count, count, 60f);
        count += 3;
    }
}
