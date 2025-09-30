using UnityEngine;

public class Items : MonoBehaviour
{
    public ItemTemplate itemData;

    private void Start()
    {
        GetComponent<MeshRenderer>().material.color = itemData.itemColor;
    }
}
