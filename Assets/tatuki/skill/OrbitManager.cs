using System.Collections.Generic;
using UnityEngine;

public class OrbitManager : MonoBehaviour
{
    [SerializeField] private Transform _player;
    
    private List<OrbitRing> _rings = new List<OrbitRing>();

    private void Update()
    {
        foreach (var ring in _rings)
        {
            ring.UpdateRing(_player);
        }
    }

    /// <summary>
    /// 新しいリングを追加
    /// </summary>
    public void AddRing(GameObject prefab, int count, float radius, float speed)
    {
        OrbitRing newRing = new OrbitRing(prefab, count, radius, speed, transform);
        _rings.Add(newRing);
    }
}