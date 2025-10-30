using UnityEngine;
using System.Collections.Generic;

public class PlayerController : Character
{
   [SerializeField]private float defenseRate = 0.5f;
    private BattleManager battleManager;
    private bool isDefending = false; //  防御状態フラグ

    private void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();
    }

    public override void Attack(Character target)
    {
        Debug.Log($"{Name} の攻撃！");
        target.TakeDamage(attackPower);
    }

    public void Skill(List<EnemyController> enemies)
    {
        Debug.Log($"{Name} のスキル発動！");
        foreach (var e in enemies)
        {
            if (!e.IsDead)
                e.TakeDamage(attackPower / 2);
        }
    }

    public void Defend()
    {
        Debug.Log($"{Name} は防御の姿勢を取った！");
        isDefending = true;
    }

    // 🟢 Character の TakeDamage をオーバーライド
    public override void TakeDamage(int damage)
    {
        if (isDefending)
        {
            damage = Mathf.FloorToInt(damage * defenseRate); // 半減
            Debug.Log($"{Name} は防御してダメージを軽減！");
        }

        base.TakeDamage(damage);
    }

    // 🟢 防御解除メソッド（BattleManagerから呼ばれる）
    public void ResetDefend()
    {
        if (isDefending)
        {
            Debug.Log($"{Name} は防御を解いた。");
            isDefending = false;
        }
    }
}
