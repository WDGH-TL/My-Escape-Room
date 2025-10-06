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
            if (itemIsDropped != null && itemIsDropped.clip != null)
            {
                itemIsDropped.Play();
            }
        }
    }
}
