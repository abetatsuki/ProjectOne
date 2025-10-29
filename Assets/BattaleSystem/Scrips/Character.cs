using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected string characterName;
    [SerializeField] protected int maxHp = 100;
    [SerializeField] protected int attackPower = 10;
    protected int currentHp;

    public bool IsDead => currentHp <= 0;
    public string Name => characterName;
    public int CurrentHp => currentHp;

    protected virtual void Awake()
    {
        currentHp = maxHp;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        Debug.Log($"{characterName} は {damage} ダメージを受けた！ 残りHP: {currentHp}");
    }

    public abstract void Attack(Character target);
}
