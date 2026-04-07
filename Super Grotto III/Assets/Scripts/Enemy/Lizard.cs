using UnityEngine;

public class Lizard : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float bulletForce = 20f;

    [Header("References")]
    [SerializeField] private GameObject firePoint;
    [SerializeField] private Transform player;
    [SerializeField] private ObjectPooler pooler;

    [Header("Shooting Settings")]
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float nextFireRate;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        pooler = FindAnyObjectByType<ObjectPooler>();
    }

    private void FixedUpdate()
    {
        if(nextFireRate < Time.time)
        {
            GameObject enemyBullet = pooler.SpawnFromPools("EnemyBullet",firePoint.transform.position,Quaternion.identity);
            Rigidbody2D rb = enemyBullet.GetComponent<Rigidbody2D>();
            if( rb!= null)
            {
                rb.AddForce(-transform.right * bulletForce, ForceMode2D.Impulse);
            }

            nextFireRate = Time.time + fireRate;
        }
    }
}