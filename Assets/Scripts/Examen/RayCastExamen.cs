using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastExamen : MonoBehaviour
{

    //Raycast y Character Controller
    //Raycast: cuando hagamos click en unos objetos, y sigun que objeto sea haga una cosa u otra
    //Position[Mouse] Vector 2 y LeftButton[Mouse]

    InputAction _clickAction;

    InputAction _positionAction;
    Vector2 _mousePosition;

    void Awake()
    {
        //El nombre del conjunto del Action
        _clickAction = InputSystem.actions["Attack"];
        _positionAction = InputSystem.actions["RayCast"]; 
    }

    void Update()
    {
        _mousePosition = _positionAction.ReadValue<Vector2>(); //El Vector 2 tiene que cuadrar con el InputSystem


        if(_clickAction.WasPerformedThisFrame())
        {
            ShootRaycast();
        }
    }

    void ShootRaycast()
    {
        //Pilla la camara principal y mira donde esta el raton en perspectiva de la camara, lanzando un rayo hacia delante
        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);
        //Esta variable almacena la informacion de que se ha chocado el rayo
        RaycastHit hit;
        //Te pide el rayo exacto (ray), opcionalmente donde guardamos la informacion (Hit), y la distancia, en este caso Infinito (Mathf.Infinity)
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            //Con que ha impactado el rayo
            if(hit.transform.gameObject.layer == 3)
            {

            }

            if(hit.transform.tag == "Ejemplo2")
            {

            }

            if(hit.transform.name == "Ejemplo3")
            {

            }
        }
    }
}
