using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pajaro : MonoBehaviour
{
    public Transform pivote;
    public float springRange;
    public float maxVel;
    public string sueloTag = "suelo";
    public float tiempoAntesDestruccion = 5f;
    public AudioClip bgMusic;

    Rigidbody2D rb;
    Vector3 distancia;
    public float gravedadInicial = 0f;
    public float gravedadLanzado = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    bool canDrag = true;

    void OnMouseDrag()
    {
        if (!canDrag)
        {
            return;
        }

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN

        // PC
        var posicion = Camera.main.ScreenToWorldPoint(Input.mousePosition);

#elif UNITY_ANDROID
        // Móvil
        var posicion = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
     
#endif

        distancia = posicion - pivote.position;
        distancia.z = 0;

        if (distancia.magnitude > springRange)
        {
            distancia = distancia.normalized * springRange;
        }

        transform.position = distancia + pivote.position;
    }

    void OnMouseUp()
    {
        if (!canDrag)
        {
            return;
        }

        canDrag = false;

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = -distancia.normalized * maxVel * distancia.magnitude / springRange;

        rb.gravityScale = gravedadLanzado;
        AudioManager.instance.PlayAudio(bgMusic);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(sueloTag) || collision.gameObject.layer == LayerMask.NameToLayer("Destructible"))
        {
            Destroy(gameObject, tiempoAntesDestruccion);
        }
    }
}

