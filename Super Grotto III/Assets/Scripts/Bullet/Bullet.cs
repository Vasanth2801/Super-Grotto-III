using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyHealth eh = collision.gameObject.GetComponent<EnemyHealth>();
            if(eh != null)
            {
                eh.TakeDamage(10);
            }
        }
        gameObject.SetActive(false);
    }
}
