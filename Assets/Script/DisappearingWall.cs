using UnityEngine;



public class DisappearingWall : MonoBehaviour
{

    public GameObject hint;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (hint != null)
            {
                hint.SetActive(true);
                Invoke("HideHint", 2f);
            }
        }
        Debug.Log(collision.gameObject.name);
    }

    void HideHint()
    {
        if (hint != null)
        {
            hint.SetActive(false);
        }
    }

}