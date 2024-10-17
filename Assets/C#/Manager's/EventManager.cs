using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action onUIChanged;
    public static Action<Vector3, float> onEnemyDead;
}