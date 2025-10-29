using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private List<EnemyController> enemies;
    [SerializeField] private UIManager uiManager;

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
        uiManager.ShowCommands();
    }

    public void OnPlayerCommandSelected(string command)
    {
        Debug.Log($"プレイヤーのコマンド: {command}");

        switch (command)
        {
            case "Attack":
                player.Attack(enemies[0]); // 仮で最初の敵を攻撃
                break;
            case "Skill":
                player.Skill(enemies);
                break;
            case "Defend":
                player.Defend();
                break;
        }

        EndPlayerTurn();
    }

    public void EndPlayerTurn()
    {
        if (CheckBattleEnd()) return;
        StartCoroutine(EnemyTurn());
    }

    private IEnumerator EnemyTurn()
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

        // 🟢 敵のターン終了後に防御解除
        player.ResetDefend();

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
