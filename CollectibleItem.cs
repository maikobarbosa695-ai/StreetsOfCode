using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public enum TipoItem { ChipDados, VidaExtra, PowerUp }
    public TipoItem tipo;
    public int valorPontos = 10;
    public GameObject efeitoParticula;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        switch (tipo)
        {
            case TipoItem.ChipDados:
                GameManager.Instance?.AdicionarPontos(valorPontos);
                AudioManager.Instance?.PlaySFX("coleta");
                break;

            case TipoItem.VidaExtra:
                GameManager.Instance?.AtualizarVidas(GameManager.Instance.vidas + 1);
                AudioManager.Instance?.PlaySFX("vidaExtra");
                break;

            case TipoItem.PowerUp:
                other.GetComponent<PlayerController>().temDoubleJump = true;
                AudioManager.Instance?.PlaySFX("powerUp");
                break;
        }

        if (efeitoParticula)
            Instantiate(efeitoParticula, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
