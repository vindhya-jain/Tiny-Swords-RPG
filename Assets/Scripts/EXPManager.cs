using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EXPManager : MonoBehaviour
{
    public int level;
    public int currentExp;
    public int expToLevel = 10;
    public float expGrowthMultiplier = 1.2f;
    public Slider expSlider;
    public TMP_Text currentLevelText;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            GainExperience(2);
        }
    }
    public void GainExperience(int amount){
        currentExp += amount;
        if(currentExp >= expToLevel){
            LevelUp();
        }

        UpdateUI();
    }
    private void OnEnable()
    {
        Enemy_Health.OnMonsterDefeated += GainExperience;
    }

    private void OnDisable()
    {
        Enemy_Health.OnMonsterDefeated -= GainExperience;
    }


    private void LevelUp(){
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expGrowthMultiplier);
    }

    public void UpdateUI(){
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level: " + level;
    }
}
