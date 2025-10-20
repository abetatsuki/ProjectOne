using UnityEngine;
/// <summary>
/// �v���C���[�̋������Ǘ�����N���X
/// </summary>
public class PlayerManager : MonoBehaviour
{
    public  PlayerStatus CurrentStatus => _currentStatus;
    private PlayerStatus _currentStatus;
    private int _level;
    private PlayerData _data;

    private void Awake()
    {
        _data = GetComponent<PlayerData>();
        _currentStatus =  _data[_level];
        

    }
    public void LevelUp()
    {
        _level++;
        _currentStatus = _data[_level];
    }
}
