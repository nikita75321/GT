using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CellUpgrade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text textDescription, textPrice;
    [SerializeField] private GameObject description;
    private GameObject cloneUpgrade;
    private UpgradeTower Upgrade;

    public void InitializeUpgrade(UpgradeTower newUpgrade, GameObject cloneUpgrade)
    {
        Upgrade = newUpgrade;
        image.sprite = newUpgrade.UpgradeAttribute.icon;
        textDescription.text = newUpgrade.Description;
        textPrice.text = newUpgrade.Price.ToString();
        this.cloneUpgrade = cloneUpgrade;

        description.SetActive(false);
    }

    private void RemoveUpgrade(UpgradeTower upgrade)
    {
        Destroy(cloneUpgrade);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Upgrade.CanBuy())
        {
            Upgrade.AddUpgrade();
            RemoveUpgrade(Upgrade);
            Tower.instance.Balance -= Upgrade.Price;
            EventManager.onUIChanged?.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        description.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        description.SetActive(false);
    }
}
