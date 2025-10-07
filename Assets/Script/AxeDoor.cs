using UnityEngine;

public class AxeDoor : MonoBehaviour
{
    public GameObject hint;
    public PlayerInventory inventar;

    public void OnCollisionEnter(Collision collision)
    {
        Transform handsTransform = collision.transform.Find("Hands");
        if (inventar != null)
        {
            
            if (inventar.findItemInInventory("Hacha"))
            {
                Destroy(this.gameObject);
            }
            else
            {

                if (hint != null)
                {
                    hint.SetActive(true);
                    Invoke("HideHint", 2f);
                }
            }
        }
    }

    void HideHint()
    {
        if (hint != null)
        {
            hint.SetActive(false);
        }
    }
}
