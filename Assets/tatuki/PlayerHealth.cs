using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerManager _playerManager;

    private int currenthealth;
    private int _maxhealth;
    

    public void Start()
    {
        SetMaxStatus();
        currenthealth = _playerManager.CurrentStatus.MaxHealth;
        
    }

    public void SetMaxStatus()
    {
        _maxhealth = _playerManager.CurrentStatus.MaxHealth;
        

    }
}
