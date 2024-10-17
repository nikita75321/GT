using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeToNewUpgrade : MonoBehaviour
{
    public static Action resetUpgrade;
    [SerializeField] private Slider slider;
    private float cooldown = 6;

    private void Start()
    {
        slider.maxValue = cooldown;
        slider.value = 0;
    }

    private void Update()
    {
        if (Tower.instance.STATE == Tower.State.Live)
        {
            slider.value += Time.deltaTime;

            if (slider.value == cooldown)
            {
                slider.value = 0;
                resetUpgrade?.Invoke();
            }
        }
    }
}
