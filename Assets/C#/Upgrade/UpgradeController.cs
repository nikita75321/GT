using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    public static UpgradeController instance;
    [SerializeField] private Cell[] cellActive, cellPassive;
    [SerializeField] private GameObject cellUpgradePrefab;
    [SerializeField] private List<UpgradeTower> upgradeActive;
    [SerializeField] private List<UpgradeTower> upgradePassive;
    private int lvlUpActive = -2;
    private int lvlUpPassive = -2;
    
    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        TimeToNewUpgrade.resetUpgrade += ResetUpgrade;
    }

    private void OnDisable()
    {
        TimeToNewUpgrade.resetUpgrade -= ResetUpgrade;
    }

    private void Start()
    {
        AddUpgrade();
    }

    private void AddUpgrade()
    {
        for (int i = 0; i < cellActive.Length + lvlUpActive; i++)
        {
            AddUpgradeUI(upgradeActive[Random.Range(0, upgradeActive.Count)]);
        }

        for (int i = 0; i < cellPassive.Length + lvlUpPassive; i++)
        {
            AddUpgradeUI(upgradePassive[Random.Range(0, upgradePassive.Count)]);
        }
    }

    private async void ResetUpgrade()
    {
        foreach (var cell in cellActive)
        {
            if (cell.transform.childCount == 1)
            {
                Destroy(cell.transform.GetChild(0).gameObject);
            }
        }
        foreach (var cell in cellPassive)
        {
            if (cell.transform.childCount == 1)
            {
                Destroy(cell.transform.GetChild(0).gameObject);
            }
        }
        await Task.Delay(1);
        AddUpgrade();
    }

    private void AddUpgradeUI(UpgradeTower upgrade)
    {
        Cell[] cellInstace;
        if (upgrade.UpgradeAttribute.upgradeType == UpgradeType.Active)
        {
            cellInstace = cellActive;
        }
        else
        {
            cellInstace = cellPassive;
        }

        foreach (var cell in cellInstace)
        {
            var upgradeInSlot = cell.GetComponentInChildren<CellUpgrade>();
            
            if (upgradeInSlot == null)
            {
                SpawnNewUpgradeUI(upgrade, cell);
                return;
            }
        }
    }

    private void SpawnNewUpgradeUI(UpgradeTower upgrade, Cell cell)
    {
        var clone = Instantiate(cellUpgradePrefab, cell.transform);
        clone.GetComponent<CellUpgrade>().InitializeUpgrade(upgrade, clone);
    }

    public void IncreaseActiveSlot()
    {
        lvlUpActive++;
        if (lvlUpActive == 0)
            upgradePassive.Remove(GetComponent<IncreaseMaxSlotActive>());
    }

    public void IncreasePassiveSlot()
    {
        lvlUpPassive++;
        if (lvlUpPassive == 0)
            upgradePassive.Remove(GetComponent<IncreaseMaxSlotPasive>());
    }
}