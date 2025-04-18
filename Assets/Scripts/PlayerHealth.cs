// using TMPro;
// using UnityEngine;
// using TMPro;

// public class PlayerHealth : MonoBehaviour
// {
//    public TMP_Text healthText;
//    public Animator healthTextAnim;

//     private void Start()
//     {
//         healthText.text = "HP: " + StatsManager.Instance.currentHealth+" / "+StatsManager.Instance.maxHealth;
//     }

//     public void ChangeHealth(int amount)
//    {
//     StatsManager.Instance.currentHealth+=amount;
//     healthTextAnim.Play("TextUpdate");
//     healthText.text = "HP: " + StatsManager.Instance.currentHealth+" / "+StatsManager.Instance.maxHealth;

//     if(StatsManager.Instance.currentHealth<=0)
//     {
//         gameObject.SetActive(false);
//     }
//    }
// }

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public TMP_Text healthText;
    public Animator healthTextAnim;
    public GameObject exitPanel; // ← drag your ExitPanel UI here in Inspector

    private void Start()
    {
        healthText.text = "HP: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;
        exitPanel.SetActive(false); // ensure it's hidden initially
    }

    public void ChangeHealth(int amount)
    {
        StatsManager.Instance.currentHealth += amount;
        healthTextAnim.Play("TextUpdate");
        healthText.text = "HP: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;

        if (StatsManager.Instance.currentHealth <= 0)
        {
            // Show Exit UI
            exitPanel.SetActive(true);
            Time.timeScale = 0f; // pause the game
        }
    }

    // These functions will be connected to the buttons
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("RPG");
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
