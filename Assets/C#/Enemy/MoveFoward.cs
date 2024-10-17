using UnityEngine.UI;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void FixedUpdate()
    {
        transform.position = target.position;
    }
}
