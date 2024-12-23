using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb; // Komponen Rigidbody2D
    Animator anim;  // Komponen Animator
    float dirX, moveSpeed = 5f; // Arah gerakan dan kecepatan
    bool facingRight = true; // Menentukan arah hadap
    Vector3 localScale; // Skala lokal karakter untuk flipping sprite

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Inisialisasi Rigidbody2D
        anim = GetComponent<Animator>(); // Inisialisasi Animator
        localScale = transform.localScale; // Mendapatkan skala awal
    }

    void Update()
    {
        if (DialogueManager.isActive == true)
        return;
        
        // Ambil input horizontal (-1 untuk kiri, 1 untuk kanan)
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        // Set animasi idle atau walk berdasarkan input horizontal
        if (dirX == 0)
        {
            anim.SetBool("isWalking", false); // Jika tidak ada input, idle
        }
        else
        {
            anim.SetBool("isWalking", true); // Jika ada input, walk
        }
    }

    void FixedUpdate()
    {
        // Gerakan karakter secara fisik
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void LateUpdate()
    {
        // Periksa arah hadap
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        // Menentukan arah hadap berdasarkan gerakan horizontal
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        // Membalik sprite jika perlu
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale; // Terapkan perubahan skala
    }
}
