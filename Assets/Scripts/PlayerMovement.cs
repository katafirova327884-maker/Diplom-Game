using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    [SerializeField] private float gravity = -9.81f;
    public bool canMove = true; 

    public float interactDistance = 3f;
    public LayerMask interactLayer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
            //UIManager.Instance.HideTask();
        //}
        
        if (!canMove) return;

        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;
        controller.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        bool isLookingAtObject = Physics.Raycast(ray, out hit, interactDistance,interactLayer);
        if (isLookingAtObject) 
        { 
            Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.green); 
        }
        else 
        { 
            Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red); 
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Кнопка E нажата");
            if (isLookingAtObject)
            {
                Debug.Log("Попал и нажал E");
                Interactable normal = hit.collider.GetComponentInParent<Interactable>();
                if (normal != null)
                { Debug.Log("Обычный терминал"); normal.Interact(); return; }

                Level3Terminal lvl3 = hit.collider.GetComponentInParent<Level3Terminal>();
                if (lvl3 != null) { Debug.Log("Терминал Level3"); lvl3.Interact(); return; }
                Debug.Log("Скрипт взаимодействия не найден");
            }
        }
    }
}
