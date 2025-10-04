using UnityEngine;

public class DropItem : MonoBehaviour
{
    public AudioSource itemIsDropped;

    void Start()
    {
        itemIsDropped = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            Debug.Log("Ayuda");
            if (itemIsDropped != null && itemIsDropped.clip != null)
            {
                itemIsDropped.Play();
            }
        }
    }
}
