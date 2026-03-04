using UnityEngine;

public class Base : MonoBehaviour
{
    public static Base instance { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
    }
}
