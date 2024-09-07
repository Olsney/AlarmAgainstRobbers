using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Player : MonoBehaviour
{
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }
}