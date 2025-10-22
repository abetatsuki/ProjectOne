using UnityEngine;

public class OrbitRing
{
    private GameObject[] _blocks;
    private GameObject _prefab;
    private int _count;
    private float _radius;
    private float _rotateSpeed;
    private float _currentAngle;
    private Transform _parent;

    public OrbitRing(GameObject prefab, int count, float radius, float speed, Transform parent)
    {
        _prefab = prefab;
        _count = count;
        _radius = radius;
        _rotateSpeed = speed;
        _parent = parent;

        InitializeBlocks();
    }

    private void InitializeBlocks()
    {
        _blocks = new GameObject[_count];

        for (int i = 0; i < _count; i++)
        {
            GameObject obj = Object.Instantiate(_prefab, _parent);
            _blocks[i] = obj;
        }
    }

    public void UpdateRing(Transform player)
    {
        _currentAngle = Mathf.Repeat(_currentAngle + _rotateSpeed * Time.deltaTime, 360f);

        float step = 360f / _count;
        for (int i = 0; i < _count; i++)
        {
            float angle = (i * step + _currentAngle) * Mathf.Deg2Rad;
            Vector3 dir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * _radius;

            _blocks[i].transform.position = player.position + dir;
            _blocks[i].transform.rotation = Quaternion.identity;
        }
    }
}