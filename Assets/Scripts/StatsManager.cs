using TMPro;
// using UnityEditor;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    public StatsUi statsUi;


    public TMP_Text healthText;

    [Header("Combat Stats")]
    public float weaponRange;
    public int damage;
    public float knockbackForce;
    public float knockbackTime;
    public float stunTime;

    [Header("Movement Stats")]
    public int speed;

    [Header("Health Stats")]
    public int currentHealth;
    public int maxHealth;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateMaxHealth(int amount)
    {
        maxHealth += amount;
        healthText.text = "HP: " + currentHealth + " / " + maxHealth;
    }

    public void UpdateHealth(int amount)
    {
        currentHealth += amount;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = "HP: " + currentHealth + " / " + maxHealth;
    }

    public void UpdateSpeed(int amount)
    {
        speed += amount;
        statsUi.UpdateAllStats();
    }
}
