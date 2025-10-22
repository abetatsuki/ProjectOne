using System;
using UnityEngine;
using UnityEngine.Events;

public class ItemGiver : MonoBehaviour
{
    [SerializeField] private OrbitManager orbitManager;
    [SerializeField] private GameObject itemPrefab;
   

    
    
    public void Add() =>orbitManager.AddRing(itemPrefab, 3, 4f, 60f);
}
