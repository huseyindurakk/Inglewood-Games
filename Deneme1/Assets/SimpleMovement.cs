using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float speed = 6.0f;           // Karakterin y�r�me h�z�
    public float gravity = -9.81f;       // Yer �ekimi
    public float jumpHeight = 1.0f;      // Z�plama y�ksekli�i

    private Vector3 velocity;            // Hareket y�n�
    private CharacterController controller;  // Karakter kontrolc�s�

    void Start()
    {
        // CharacterController bile�enini al
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Yatay (x) ve dikey (z) eksenlerindeki giri�leri al
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Hareket y�n�n� belirle
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Karakteri hareket ettir
        controller.Move(move * speed * Time.deltaTime);

        // Z�plama kontrol�
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Yer �ekimi uygulamas�
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
