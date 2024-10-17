using UnityEngine;

public class PassiveSkills : MonoBehaviour
{
    private void OnEnable()
    {
        TimeManager.onSecoundPassed += PassiveAction;
    }

    private void OnDisable()
    {
        TimeManager.onSecoundPassed -= PassiveAction;
    }
    
    private void PassiveAction()
    {
        if (Tower.instance.STATE == Tower.State.Live)
        {
            Regeneration();
            IncreaseMaxHp();
            Tower.instance.Balance += Tower.instance.MoneySec;

            EventManager.onUIChanged?.Invoke();
        }
    }

    private void IncreaseMaxHp()
    {
        Tower.instance.MaxHealth += Tower.instance.HpSec;
    }

    private void Regeneration()
    {
        Tower.instance.CurrentHealth += Tower.instance.HealthRegeneration;

        if(Tower.instance.CurrentHealth >= Tower.instance.MaxHealth)
        {
            Tower.instance.CurrentHealth = Tower.instance.MaxHealth;
        }
        else if (Tower.instance.CurrentHealth <= 0)
        {
            Tower.instance.CurrentHealth = 0;
        }
    }
}
