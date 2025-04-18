using TMPro;
using UnityEngine;

public class StatsUi : MonoBehaviour
{
    public GameObject[] statsSlots;
    public CanvasGroup statsCanvas;
    private bool statsOpen = false;

    private void Start()
    {
        UpdateAllStats();
    }

    private void Update()
    {
        if(Input.GetButtonDown("ToggleStats"))
        {
            if(statsOpen)
            {
                Time.timeScale = 1;
                statsCanvas.alpha = 0;
                UpdateAllStats();
                statsCanvas.blocksRaycasts = false;
                statsOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                statsOpen = true;
                UpdateAllStats();
                statsCanvas.blocksRaycasts = true;
                statsCanvas.alpha = 1;
            }
        }
    }
    public void UpdateDamage()
    {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + StatsManager.Instance.damage;

    }

    public void UpdateSpeed()
    {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatsManager.Instance.speed;

    }
    public void UpdateAttack()
    {
        statsSlots[2].GetComponentInChildren<TMP_Text>().text = "Attack: " + "3";

    }

    public void UpdateRes()
    {
        statsSlots[3].GetComponentInChildren<TMP_Text>().text = "Resistance: " + "2";

    }

    public void UpdateMagic()
    {
        statsSlots[4].GetComponentInChildren<TMP_Text>().text = "Magic: " + "4";

    }

    public void UpdateIntel()
    {
        statsSlots[5].GetComponentInChildren<TMP_Text>().text = "Intelligence: " + "1";

    }

    public void UpdateStealth()
    {
        statsSlots[6].GetComponentInChildren<TMP_Text>().text = "Stealth: " + "3";

    }

    public void UpdateAwesome()
    {
        statsSlots[7].GetComponentInChildren<TMP_Text>().text = "Coolness: " + "10";

    }

    public void UpdateCharisma()
    {
        statsSlots[8].GetComponentInChildren<TMP_Text>().text = "Charisma: " + "4";

    }

    public void UpdateSword()
    {
        statsSlots[9].GetComponentInChildren<TMP_Text>().text = "Sword: " + "5";

    }


    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
        UpdateAttack();
        UpdateRes();
        UpdateMagic();
        UpdateIntel();
        UpdateStealth();
        UpdateAwesome();
        UpdateCharisma();
        UpdateSword();
    }
}
