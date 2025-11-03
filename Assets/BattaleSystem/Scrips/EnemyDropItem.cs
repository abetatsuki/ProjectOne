using UnityEngine;

[System.Serializable]
public class DropItemData
{
    public GameObject itemPrefab;
    [Range(0f, 1f)] public float dropChance = 0.5f;
}

public class EnemyDropItem : MonoBehaviour
{
    [SerializeField] private DropItemData[] dropItems;

    public void TryDropItems(Vector3 position)
    {
        foreach (var drop in dropItems)
        {
            float random = Random.value;
            if (random <= drop.dropChance)
            {
                Instantiate(drop.itemPrefab, position, Quaternion.identity);
                Debug.Log($"🪙 {drop.itemPrefab.name} をドロップ！");
            }
        }
    }
}