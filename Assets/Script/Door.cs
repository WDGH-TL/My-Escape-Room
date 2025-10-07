using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    public GameObject hint;
    public PlayerInventory inventar;


    public void OnCollisionEnter(Collision collision)
    {
        if (inventar != null)
        {
            if (inventar.findItemInInventory("Llave"))
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene("YouWin");
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
