using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject hint;

    public void OnCollisionEnter(Collision collision)
    {
        Transform handsTransform = collision.transform.Find("Hands");
        if (handsTransform != null )
        {
            Transform keyTransform = handsTransform.Find("Key");
            if (keyTransform != null)
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
