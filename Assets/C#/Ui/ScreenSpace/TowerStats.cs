using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerStats : MonoBehaviour
{
    [SerializeField] private TMP_Text healthBar;
    [SerializeField] private TMP_Text towerStats;
    [SerializeField] private Slider fill;
    [SerializeField] private GameObject panel;
    private string timeInGame;
    private int timeInGameSec = 0;
    private int timeInGameMin = 0;

    private void OnEnable()
    {
        EventManager.onUIChanged += UpdateUI;
        TimeManager.onSecoundPassed += TimeChange;
    }

    private void OnDisable()
    {
        EventManager.onUIChanged -= UpdateUI;
        TimeManager.onSecoundPassed -= TimeChange;
    }

    private void Start()
    {
        fill.maxValue = Tower.instance.MaxHealth;
        fill.value = fill.maxValue;

        timeInGame = $"{timeInGameMin:d2}:{timeInGameSec:d2}";

        UpdateUI();
    }

    private void UpdateUI()
    {
        towerStats.text = $"<sprite name=Shield>{Tower.instance.Defense}   " +
                        $"<sprite name=Money>{Tower.instance.Balance}   " +
                        timeInGame;

        healthBar.text = $"{Tower.instance.CurrentHealth}/{Tower.instance.MaxHealth}";

        fill.maxValue = Tower.instance.MaxHealth;
        fill.value = Tower.instance.CurrentHealth;

        if (Tower.instance.STATE == Tower.State.Death)
        {
            panel.SetActive(true);
        }
    }

    public void TimeChange()
    {
        timeInGameSec++;

        if (timeInGameSec >= 60)
        {
            timeInGameMin++;
            timeInGameSec = 0;
        }
        timeInGame = $"{timeInGameMin:d2}:{timeInGameSec:d2}";

        UpdateUI();

        EventManager.onUIChanged?.Invoke();
    }
}