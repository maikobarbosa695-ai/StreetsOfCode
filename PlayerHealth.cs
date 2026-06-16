using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int vidas = 3;
    public float tempoInvencivel = 1.5f;
    private bool invencivel = false;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void TomarDano()
    {
        if (invencivel) return;

        vidas--;
        AudioManager.Instance?.PlaySFX("dano");
        GameManager.Instance?.AtualizarVidas(vidas);

        if (vidas <= 0)
        {
            Morrer();
        }
        else
        {
            StartCoroutine(PeriodoInvencivel());
        }
    }

    IEnumerator PeriodoInvencivel()
    {
        invencivel = true;
        for (int i = 0; i < 6; i++)
        {
            sr.color = new Color(1, 0.3f, 0.3f, 0.5f);
            yield return new WaitForSeconds(0.12f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.12f);
        }
        invencivel = false;
    }

    void Morrer()
    {
        AudioManager.Instance?.PlaySFX("morte");
        GetComponent<PlayerController>().enabled = false;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        StartCoroutine(ReiniciarFase());
    }

    IEnumerator ReiniciarFase()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance?.ReiniciarFase();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo") || other.CompareTag("Perigo"))
        {
            TomarDano();
        }
    }
}
