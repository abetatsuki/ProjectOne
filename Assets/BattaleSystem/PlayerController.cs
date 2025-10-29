using UnityEngine;
using System.Collections.Generic;

public class PlayerController : Character
{
  [SerializeField] private BattleManager battleManager;


   

    public override void Attack(Character target)
    {
        Debug.Log($"{Name} の攻撃！");
        target.TakeDamage(attackPower);
    }

    public void SelectCommand(List<EnemyController> enemies)
    {
        // とりあえず最初の敵を攻撃（のちにUIで選択できるように）
        Attack(enemies[0]);
        battleManager.EndPlayerTurn();
    }
}
