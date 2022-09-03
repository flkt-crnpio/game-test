using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float tiempoVida = 1.5f;
    public float velocidad = 2f;
    public Vector2 direccion;
    public Color colorInicial = Color.white;
    public Color colorFinal;

    private float _nacimiento;
    private SpriteRenderer _renderer;


    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // guardar en variable cuando comienza a vivir mi balita
        _nacimiento = Time.time;

        // destruir un objeto en un tiempo determinado
        Destroy(this.gameObject, tiempoVida);
    }

    void Update()
    {
        // moviendo mi balita a una velocidad en el tiempo de ejecución
        Vector2 _movimiento = direccion.normalized * velocidad * Time.deltaTime;
        transform.Translate(_movimiento);

        // cambiando el color de mi balita en el tiempo de vida
        float _edad = Time.time - _nacimiento;
        float _porcentajeDeVida = _edad / tiempoVida;
        _renderer.color = Color.Lerp(colorInicial, colorFinal, _porcentajeDeVida);
    }
}
