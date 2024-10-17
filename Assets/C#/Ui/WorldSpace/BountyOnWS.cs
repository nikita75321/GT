using TMPro;
using UnityEngine;

public class BountyOnWS : MonoBehaviour
{
    [SerializeField] private GameObject bountyPanel;
    
    private void OnEnable()
    {
        EventManager.onEnemyDead += Inizialize;
    }

    private void OnDisable()
    {
        EventManager.onEnemyDead -= Inizialize;
    }

    public void Inizialize(Vector3 position, float bounty)
    {
        var panelClone = Instantiate(bountyPanel, position, Quaternion.identity, transform);
        panelClone.GetComponentInChildren<TMP_Text>().text = $"+{bounty} <sprite name=Money>";
    }
}
