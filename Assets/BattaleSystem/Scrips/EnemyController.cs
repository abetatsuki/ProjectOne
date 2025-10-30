using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : Character
{
    private BattleManager battleManager;
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        battleManager = FindObjectOfType<BattleManager>();
        rigidBody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

    }

    public override void Attack(Character target)
    {
        Debug.Log($"{Name} の攻撃！");
        target.TakeDamage(attackPower);
    }

    // 🟢 マウスクリックで呼ばれる
    private void OnMouseDown()
    {
        
        // 攻撃対象選択中なら BattleManager に通知
        battleManager.OnEnemyClicked(this);
    }
}