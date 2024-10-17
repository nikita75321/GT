using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static Action onSecoundPassed;
    public static Action onMinutePassed;
    public static Action onHalfMinutePassed;
    public static Action onQuaterMinutePassed;
    public static TimeManager instance;
    private float timer = 1f;
    private int interval = 1;
    private int secound = 0;
    public float Difficult{ get{ return difficult;} set { difficult = value;}}
    private float difficult = 1f;

    private void Awake()
    {
        instance = this;
    }

    public float GetDifficult()
    {
        return difficult;
    }
    
    private void Update() 
    {
        if(Tower.instance.STATE == Tower.State.Live)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                secound++;
                timer = interval;
                onSecoundPassed?.Invoke();

                if (secound % 15 == 0)
                {
                    onQuaterMinutePassed?.Invoke();
                    difficult *= 1.3f;
                    Debug.Log("15 sek");
                }
                if (secound % 30 == 0)
                { 
                    onHalfMinutePassed?.Invoke();
                }
                if (secound % 60 == 0)
                {
                    secound = 0;
                    onMinutePassed?.Invoke();
                }
            }
        }
    } 
}