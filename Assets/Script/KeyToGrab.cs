using UnityEngine;

public class KeyToGrab : MonoBehaviour
{
    public bool keyCollected = false;

    public void KeyFound()
    {
        keyCollected = true;
    }

    public bool HasKey()
    {
        return keyCollected;
    }
}
