using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private string itemName = "New Item Name";
    [SerializeField] private string description = "New Item Description";

    public string Name => itemName;
    public string Description => description;

    public abstract void DisplayText();
}