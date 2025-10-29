using UnityEngine;

public class EnemyController : Character
{
    public override void Attack(Character target)
    {
        Debug.Log($"{Name} の攻撃！");
        target.TakeDamage(attackPower);
    }
}
