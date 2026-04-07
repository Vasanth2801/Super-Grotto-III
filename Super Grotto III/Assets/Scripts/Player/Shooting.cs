using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private float bulletForce = 20f;

    [Header("References")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private ObjectPooler pooler;
    [SerializeField] private Animator animator;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        animator.SetTrigger("Shoot");
        yield return new WaitForSeconds(0.3f);
        GameObject bullet = pooler.SpawnFromPools("Bullet", firePoint.position,firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}