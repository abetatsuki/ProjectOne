using System;
using UnityEngine;

public class OrbitManager : MonoBehaviour
{
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private GameObject _ItemPrefab;
    [SerializeField] private int _BlockCount = 1;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private float _rotateSpeed = 90f;

    private GameObject[] _blocks;
    private float _currentAngle;
    private float _angleStep;

    private void Start()
    {
        _angleStep = 360f / _BlockCount; 
        InitializeBlocks();
    }

    private void Update()
    {
        RotateBlocksAroundPlayer();
    }
/// <summary>
/// ブロックを初期化(生成と参照保持)
/// </summary>
    private void InitializeBlocks()
    {
        _blocks = new GameObject[_BlockCount];
        for (int i = 0; i < _BlockCount; i++)
        {
            GameObject newBlock = Instantiate(_ItemPrefab, transform);
            _blocks[i] = newBlock;
        }
    }
/// <summary>
/// ブロック全体を回転更新
/// </summary>
    private void RotateBlocksAroundPlayer()
    {
        UpdateAngle();
        UpdateBlockPositions();
    }

    private void UpdateAngle()
    {
        _currentAngle = Mathf.Repeat(_currentAngle + _rotateSpeed * Time.deltaTime, 360f);
    }

    private void UpdateBlockPositions()
    {
        for (int i = 0; i < _BlockCount; i++)
        {
            float angle = (i*_angleStep +  _currentAngle) * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle),0)*_radius;
            
            _blocks[i].transform.position = _playerPosition.position + direction;
            _blocks[i].transform.rotation = Quaternion.identity;
        }
    }
    
}
