using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public  PlayerStatus this[int i] =>playerStatuses[i];
   [SerializeField] private PlayerStatus[] playerStatuses;

}
[Serializable]public  struct PlayerStatus
{
    public int MaxHealth =>_maxhealth;
    public int Speed => _speed;
    [SerializeField,Min(1)] private int _maxhealth;
    [SerializeField,Min(1)] private int _speed;
}