using UnityEngine;

public class ClickTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log($"クリックヒット: {hit.collider.name}");
                Destroy(hit.collider.gameObject);
                Debug.Log("Destroy");
            }
            else
            {
                Debug.Log("何にも当たってない");
            }
        }
    }
}