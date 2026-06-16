using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI textoPontuacao;
    public TextMeshProUGUI textoVidas;
    public Image painelFade;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AtualizarPontuacao(int valor)
    {
        if (textoPontuacao) textoPontuacao.text = "Pontos: " + valor;
    }

    public void AtualizarVidas(int valor)
    {
        if (textoVidas) textoVidas.text = "Vidas: " + valor;
        if (valor <= 1 && textoVidas) textoVidas.color = Color.red;
        else if (textoVidas) textoVidas.color = Color.white;
    }

    public IEnumerator FadeIn()
    {
        painelFade.gameObject.SetActive(true);
        float t = 0;
        while (t < 1) { t += Time.deltaTime; painelFade.color = new Color(0,0,0,t); yield return null; }
    }

    public IEnumerator FadeOut()
    {
        float t = 1;
        while (t > 0) { t -= Time.deltaTime; painelFade.color = new Color(0,0,0,t); yield return null; }
        painelFade.gameObject.SetActive(false);
    }
}

// ----- LevelLoader (arquivo separado, incluso aqui por praticidade) -----
// Crie um GameObject vazio na cena com este script e configure o trigger de saida da fase

public class LevelLoader : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(CarregarProximaFase());
    }

    IEnumerator CarregarProximaFase()
    {
        if (UIManager.Instance != null)
            yield return StartCoroutine(UIManager.Instance.FadeIn());
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance?.ProximaFase();
    }
}
