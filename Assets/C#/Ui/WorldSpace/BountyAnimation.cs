using System.Collections;
using UnityEngine;

public class BountyAnimation : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SpawnPanel());
    }

    private IEnumerator SpawnPanel()
    {
        yield return new WaitForSeconds(2);
        
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 5);
    }
}
