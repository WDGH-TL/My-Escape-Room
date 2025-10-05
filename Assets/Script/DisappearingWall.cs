using UnityEngine;

public class DisappearingWall : MonoBehaviour
{
    public GameObject hint;

    public void OnCollisionEnter(Collision collision)
    {
        if (hint != null)
        {
            hint.SetActive(true);
            Invoke("HideHint", 2f);
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
