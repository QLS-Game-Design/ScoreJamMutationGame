using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float destroyDelay = 1f;

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    private void private void OnTriggerEnter(Collider other) {
        
    }(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<EnemyScript>(out EnemyScript enemy)) {
            enemy.TakeDamage(1);
            Debug.Log("hit");
        }
        Destroy(gameObject);
    }

}
