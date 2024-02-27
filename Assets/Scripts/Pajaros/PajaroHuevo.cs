using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroHuevo : MonoBehaviour
{
    public Transform pivote;
    public float springRange;
    public float maxVel;
    public GameObject huevoPrefab;
    public KeyCode jumpKey;
    public string sueloTag = "suelo";
    public float tiempoAntesDestruccion = 5f;
    public float gravedadInicial = 0f;
    public float gravedadLanzado = 1f;
    public AudioClip bgMusic;

    Rigidbody2D rb;
    Vector3 distancia;

    bool canDrag = true;
    bool lanzado = false;

    public Vector3 offset = new Vector3(0f, -0.5f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

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
        lanzado = true;
        AudioManager.instance.PlayAudio(bgMusic);
    }


    void Update()
    {

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN

        // PC
        if (Input.GetKeyDown(jumpKey))
        {
            LanzarHuevo();
        }

#elif UNITY_ANDROID
        // Móvil
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                  LanzarHuevo();
            }
        }
#endif
    }


    void LanzarHuevo()
    {
        if (lanzado)
        {
            if (huevoPrefab != null)
            {
                Vector3 huevoPosition = transform.position + offset;
                Instantiate(huevoPrefab, huevoPosition, Quaternion.identity);
            }
            lanzado = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(sueloTag) || collision.gameObject.layer == LayerMask.NameToLayer("Destructible"))
        {
            Destroy(gameObject, tiempoAntesDestruccion);
        }
    }
}
