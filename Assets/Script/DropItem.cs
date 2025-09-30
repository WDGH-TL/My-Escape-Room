using UnityEngine;

public class DropItem : MonoBehaviour
{
    public AudioSource itemIsDropped;
    void Start()
    {
        itemIsDropped = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision) // Prueba para sonido
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            itemIsDropped.Play();
        }
    }
}
