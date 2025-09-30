using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ItemData", order = 0)]

public class ItemTemplate : ScriptableObject
{
    public string itemName;
    public Color itemColor;
}
