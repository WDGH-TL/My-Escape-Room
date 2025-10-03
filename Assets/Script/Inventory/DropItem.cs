using UnityEngine;

public class DropItem : MonoBehaviour
{
    public AudioClip hitsound;
    private AudioSource itemIsDropped;
    public float minImpactForce = 0.5f;

    void Start()
    {
        itemIsDropped = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) // Prueba para sonido
    {
        float impactForce = collision.relativeVelocity.magnitude;

        if (impactForce < minImpactForce && hitsound != null)
        {
            float volume = Mathf.Clamp01(impactForce / 5f);
        }
    }
}
