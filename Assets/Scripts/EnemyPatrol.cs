using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float velocidad = .7f;
    public float tiempoEspera = 1f;
    public float minX = -2.4f;
    public float maxX = 2.4f;

    private GameObject _objetivo;


    // Start is called before the first frame update
    void Start()
    {
        ActualizarObjetivo();
        StartCoroutine("LoopCaminoEnemigo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActualizarObjetivo()
    {
        // si no existe el objeto al cual me tengo que dirigir
        if (_objetivo == null) {
            Debug.Log("crear objetivo");
            _objetivo = new GameObject();
            _objetivo.transform.position = new Vector2(minX, this.transform.position.y);
            this.transform.localScale = new Vector3(-1, 1, 1);
            return;
        }

        // si llegamos a la izquierda, poner el objetivo a la derecha y volvearme
        if (_objetivo && this.transform.position.x == minX) {
            Debug.Log("mover objetivo a maxX");
            _objetivo.transform.position = new Vector2(maxX, this.transform.position.y);
            this.transform.localScale = new Vector3(1, 1, 1);
        }

        // si llegamos a la derecha, poner el objetivo a la izquierda y volver a voltearme
        if (_objetivo && this.transform.position.x == maxX) {
            Debug.Log("mover objetivo a minX");
            _objetivo.transform.position = new Vector2(minX, this.transform.position.y);
            this.transform.localScale = new Vector3(-1, 1, 1);
        }

        else {
            Debug.Log("ERR no hizo naa");
        }
    }

    private IEnumerator LoopCaminoEnemigo()
    {
        // mover el monito mientras que la posicion del malo y el objetivo sean mayores que 0.05 ... sea lo que sea eso haha
        Debug.Log("iniciar patrulla");
        while(Vector2.Distance(this.transform.position, _objetivo.transform.position) > 0.05f) {
            Vector2 direction = _objetivo.transform.position - this.transform.position;

            this.transform.Translate(direction.normalized * velocidad *  Time.deltaTime);

            yield return null;
        }
        // transform.localScale = new Vector3(1, 1, 1);

        Debug.Log("llegamos al objetivo");
        this.transform.position = new Vector2(_objetivo.transform.position.x, _objetivo.transform.position.y);

        // aca se espera un ratito en la posicion final
        yield return new WaitForSeconds(tiempoEspera);

        // luego actualizamos el objetivo
        ActualizarObjetivo();
        // y volvemos a repetir el camino pero pal otro lado
        StartCoroutine("LoopCaminoEnemigo");
    }
}
