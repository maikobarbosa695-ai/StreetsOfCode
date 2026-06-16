using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    public float velocidadeCorrida = 9f;
    public float forcaPulo = 12f;

    [Header("Double Jump")]
    public bool temDoubleJump = false;
    private bool podeDoubleJump = false;

    [Header("Escalada")]
    public float velocidadeEscalada = 3f;
    private bool estaNaEscada = false;

    private Rigidbody2D rb;
    private Animator anim;
    private bool estaNoChao = false;
    private float inputHorizontal;

    [Header("Deteccao de Chao")]
    public Transform pontoChao;
    public LayerMask layerChao;
    public float raioChao = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        estaNoChao = Physics2D.OverlapCircle(pontoChao.position, raioChao, layerChao);

        if (estaNoChao) podeDoubleJump = true;

        Mover();
        Pular();
        Escalar();
        AtualizarAnimacoes();
    }

    void Mover()
    {
        bool correndo = Input.GetKey(KeyCode.LeftShift);
        float vel = correndo ? velocidadeCorrida : velocidade;
        rb.linearVelocity = new Vector2(inputHorizontal * vel, rb.linearVelocity.y);

        if (inputHorizontal > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (inputHorizontal < 0) transform.localScale = new Vector3(-1, 1, 1);
    }

    void Pular()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (estaNoChao)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
                AudioManager.Instance?.PlaySFX("pulo");
            }
            else if (temDoubleJump && podeDoubleJump)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
                podeDoubleJump = false;
                AudioManager.Instance?.PlaySFX("pulo");
            }
        }
    }

    void Escalar()
    {
        if (estaNaEscada)
        {
            rb.gravityScale = 0f;
            float inputVertical = Input.GetAxisRaw("Vertical");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, inputVertical * velocidadeEscalada);
        }
        else
        {
            rb.gravityScale = 3f;
        }
    }

    void AtualizarAnimacoes()
    {
        anim.SetFloat("Speed", Mathf.Abs(inputHorizontal));
        anim.SetBool("IsGrounded", estaNoChao);
        anim.SetFloat("VelocidadeY", rb.linearVelocity.y);
        anim.SetBool("IsClimbing", estaNaEscada);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Escada")) estaNaEscada = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Escada")) estaNaEscada = false;
    }
}
