using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InteractivrController : MonoBehaviour
{
    [SerializeField] private InputActionReference interactAction;
    [SerializeField] private GameObject interactText;
    [SerializeField] private TextMeshProUGUI dialogue;

    private bool isPlayerInRange = false;

    private void OnEnable()
    {
        if (interactAction != null) 
        {
            interactAction.action.Enable();
            interactAction.action.performed += PerformInteraction;
        }
    }

    private void OnDisable()
    {
        if (interactAction != null) 
        {
            interactAction.action.performed -= PerformInteraction;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            isPlayerInRange = true;
            interactText.SetActive(true);
            Debug.Log("presiona E para Interactuar");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactText.SetActive(false);
            Debug.Log("Ya no estas en Rango");
        }
    }

    private void PerformInteraction(InputAction.CallbackContext  context) 
    {
        if (isPlayerInRange) 
        {
            Debug.Log("Interaccion con Objeto");
            interactText.SetActive(false);
            gameObject.SetActive(false);

            if (gameObject.tag == "Pista 1")
                dialogue.text = "Parece que esto realmente no existe";
            if (gameObject.tag == "Pista 2")
                dialogue.text = "Parece que otra vez esto no existe";
            if (gameObject.tag == "Pista 3")
                dialogue.text = "Enserio?, Otra vez???";
            if (gameObject.tag == "Respuesta")
                dialogue.text = "Creo que esto es una broma...";
        }
    }
}
