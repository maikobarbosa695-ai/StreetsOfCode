using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float velocidade = 2f;
    public Transform pontoA;
    public Transform pontoB;
    private Transform alvo;
    private SpriteRenderer sr;

    void Start()
    {
        alvo = pontoB;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, alvo.position, velocidade * Time.deltaTime);

        if (Vector2.Distance(transform.position, alvo.position) < 0.1f)
        {
            alvo = (alvo == pontoA) ? pontoB : pontoA;
            sr.flipX = !sr.flipX;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerHealth>()?.TomarDano();
    }
}
