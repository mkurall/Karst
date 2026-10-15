using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb; //Fizik kurallarını uygulamak için
    Animator anim;//Animasyonu değiştirmek için
    GameManager manager;

    bool isGrounded = false;//Global
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        manager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        var boslukBasildi = Input.GetKeyDown(KeyCode.Space);

        Debug.Log($"Boşluk Tuşu: {boslukBasildi}");

        if(boslukBasildi && isGrounded/*Eğer Yerde ise*/)
        {
            rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
        }

        if (isGrounded)
            anim.Play("Run");
        else
            anim.Play("Jump");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;//Şuan yerdesin
        else if(collision.gameObject.CompareTag("Box"))
        {
            Debug.Log("Kutuya çarptın");
            GameManager manager = FindAnyObjectByType<GameManager>();
            manager.GameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;//Şuan havadasın
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Puan"))
        {
            manager.AddSkor(1);
            //rb.AddForce(Vector2.up * 7f, ForceMode2D.Impulse);

        }
    }
}
