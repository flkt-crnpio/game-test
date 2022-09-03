using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bala;
    public GameObject disparador;

    private Transform _fuego;


    void Awake()
    {
        // encuentra un elemento hijo del objeto que contenga este escript y que se llame Fuego
        _fuego = transform.Find("Fuego");
    }

    void Start()
    {
        // se instancia la bala en la posicion en donde sale el _fuego con una rotacion de nosequeQuaternion
        // Instantiate(bala, _fuego.transform.position, Quaternion.identity);

        // mandamos llamar la funcion pa dispara
        // Dispara();

        // lo hacemos automático con una invocación
        Invoke("Dispara", 1f);
        Invoke("Dispara", 2f);
        Invoke("Dispara", 3f);
    }

    void Update()
    {

    }

    void Dispara()
    {
        if (bala != null && _fuego != null && disparador != null) {
            GameObject balaViva = Instantiate(bala, _fuego.transform.position, Quaternion.identity) as GameObject;

            Bullet bulletComponent = balaViva.GetComponent<Bullet>();

            if (disparador.transform.localScale.x < 0f) {
                bulletComponent.direccion = Vector2.left;
            } else {
                bulletComponent.direccion = Vector2.right;
            }
        }
    }
}
