using System;
using UnityEngine;

public class InHomeArea : MonoBehaviour
{
    public event Action Entered;
    public event Action Abonded;
    
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.TryGetComponent<Player>(out _))
        {
            Entered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            Abonded?.Invoke();
        }
    }
}
