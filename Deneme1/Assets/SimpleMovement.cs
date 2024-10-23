using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 6.0f;           // Karakterin yürüme hýzý
    public float gravity = -9.81f;       // Yer çekimi
    public float jumpHeight = 1.0f;      // Zýplama yüksekliði

    private Vector3 velocity;            // Hareket yönü
    private CharacterController controller;  // Karakter kontrolcüsü

    void Start()
    {
        // CharacterController bileþenini al
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Yatay (x) ve dikey (z) eksenlerindeki giriþleri al
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Hareket yönünü belirle
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Karakteri hareket ettir
        controller.Move(move * speed * Time.deltaTime);

        // Zýplama kontrolü
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Yer çekimi uygulamasý
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
