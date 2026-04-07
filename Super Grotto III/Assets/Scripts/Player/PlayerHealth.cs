using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings for Player")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private Image healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(healthBar);
            Destroy(gameObject);
        }
    }
}