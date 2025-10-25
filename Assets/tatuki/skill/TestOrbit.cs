
using System;
using UnityEngine;
using System.Collections.Generic;

public class TestOrbit : MonoBehaviour
{
    [SerializeField] private OrbitManager orbitManager;
    [SerializeField] private GameObject blockPrefab;

   

    
    public void AddSkill() => orbitManager.AddRing(blockPrefab, 5, 3f, 30f);
}

