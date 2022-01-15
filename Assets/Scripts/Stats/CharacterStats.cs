// Written by Joy de Ruijter
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    #region Variables

    [SerializeField] public int currentHealth;
    public int maxHealth = 100;

    public Stat health;
    public Stat armor;

    #endregion

    private void Awake()
    {
        currentHealth = maxHealth;
        health.SetStatValue(currentHealth);
    }

    // Optional to implement later
    public void TakeDamage(int damage)
    { 
        damage -= armor.GetStatValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        
        health.SubtractValue(damage);
        Debug.Log(transform.name + "takes " + damage + " damage.");

        if(health.GetStatValue() <= 0)
        {
            Die();
        }
    }

    // Optional to implement later
    public virtual void Die()
    {
        Debug.Log(transform.name + " has died.");
    }
}
