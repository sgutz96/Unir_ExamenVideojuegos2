using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interacción")]
    public float distanciaInteraccion = 2f;
    public LayerMask coleccionableLayer;

    [Header("UI")]
    public Image iconoUI;
    public TMP_Text nombreUI;
    public Sprite spriteImage;

    float score = 0;
    public Coleccionable coleccionable;

    private void Start()
    {
        iconoUI.sprite = null;
        nombreUI.text = "Puntaje: " + score;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            BuscarColeccionable();
        }
    }

    void BuscarColeccionable()
    {
        Vector3 origen = transform.position + Vector3.up * 0.5f;
        Vector3 direccion = transform.forward;

        //DIBUJA EL RAYCAST EN LA ESCENA
        Debug.DrawRay(origen, direccion * distanciaInteraccion, Color.green, 1f);

        Ray ray = new Ray(origen, direccion);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanciaInteraccion, coleccionableLayer))
        {
            coleccionable = hit.collider.GetComponent<Coleccionable>();

            if (coleccionable != null)
            {
                Debug.Log("Coleccionable detectado");

                score++;
                Destroy(coleccionable.gameObject);

                iconoUI.sprite = spriteImage;
                nombreUI.text = "Puntaje: " + score;
            }
        }
    }
}
