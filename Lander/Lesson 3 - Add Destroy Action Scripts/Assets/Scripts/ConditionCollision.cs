using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ConditionCollision : MonoBehaviour
{

    public Action Action;
    public bool filterByTag = false;
    public string filterTag = "Player";

    // This function will be called when something touches the trigger collider
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(filterTag) || !filterByTag)
        {
            Action.ExecuteAction(collision.gameObject);
        }
    }


}
