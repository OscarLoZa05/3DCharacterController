using UnityEngine;

public class Caja : MonoBehaviour, IDamageable, IInteratable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void IDamageable.TakeDamage()
    {
        Debug.Log("Enemigo Recibiendo Daño");
    }

    void IInteratable.Interact()
    {
        Debug.Log("Interactuando Con Caja");
    }
}
