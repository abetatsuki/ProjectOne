using UnityEngine;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private List<EnemyController> enemies;

    private enum BattleState { PlayerTurn, EnemyTurn, Win, Lose }
    private BattleState currentState = BattleState.PlayerTurn;

    private void Start()
    {
        StartPlayerTurn();
    }

    private void StartPlayerTurn()
    {
        Debug.Log("プレイヤーのターン！");
        currentState = BattleState.PlayerTurn;

        // コマンド選択（今は仮で自動攻撃）
        player.SelectCommand(enemies);
    }

    public void EndPlayerTurn()
    {
        if (CheckBattleEnd()) return;
        StartCoroutine(EnemyTurn());
    }

    private System.Collections.IEnumerator EnemyTurn()
    {
        currentState = BattleState.EnemyTurn;
        Debug.Log("敵のターン！");

        foreach (var enemy in enemies)
        {
            if (!enemy.IsDead)
            {
                enemy.Attack(player);
                yield return new WaitForSeconds(1f);
            }
        }

        if (!CheckBattleEnd())
        {
            StartPlayerTurn();
        }
    }

    private bool CheckBattleEnd()
    {
        if (player.IsDead)
        {
            Debug.Log("プレイヤーは敗北した...");
            currentState = BattleState.Lose;
            return true;
        }

        if (enemies.TrueForAll(e => e.IsDead))
        {
            Debug.Log("敵をすべて倒した！");
            currentState = BattleState.Win;
            return true;
        }

        return false;
    }
}
