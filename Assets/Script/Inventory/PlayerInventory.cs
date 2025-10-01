using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;
    public AudioSource itemIsDropped;
    public ItemTemplate[] itemInventory;
    public InventoryUI[] slots;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        itemIsDropped = GetComponent<AudioSource>();
        itemInventory = new ItemTemplate[2];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Items>())
        {
            AddItemToInventory(other.GetComponent<Items>());
        }
    }

    void AddItemToInventory(Items itemToAdd)
    {
        for (int i = 0; i < itemInventory.Length; i++)
        {
            if (itemInventory[i] == null)
            {
                itemInventory[i] = itemToAdd.itemData;
                slots[i].SetInfo(itemToAdd.itemData);
                Destroy(itemToAdd.gameObject);
                break;
            }
        }
    }
}
