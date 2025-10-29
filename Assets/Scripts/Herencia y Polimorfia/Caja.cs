using UnityEngine;

public class Caja : MonoBehaviour, IDamageable, IInteratable
{
    void IDamageable.TakeDamage()
    {
        Debug.Log("Enemigo Recibiendo Daño");
    }

    void IInteratable.Interact()
    {
        Debug.Log("Interactuando Con Caja");
    }
}
