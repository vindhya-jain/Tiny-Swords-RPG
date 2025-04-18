using UnityEngine;
using UnityEngine.XR;

public class Enemy_Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int expReward = 3;
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount){
        currentHealth += amount;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }

        else if(currentHealth <= 0){
            OnMonsterDefeated(expReward);
            Destroy(gameObject);
        }
    }
}
