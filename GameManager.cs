using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int pontuacao = 0;
    public int vidas = 3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void AdicionarPontos(int valor)
    {
        pontuacao += valor;
        UIManager.Instance?.AtualizarPontuacao(pontuacao);
    }

    public void AtualizarVidas(int novasVidas)
    {
        vidas = novasVidas;
        UIManager.Instance?.AtualizarVidas(vidas);
    }

    public void ReiniciarFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ProximaFase()
    {
        int proxima = SceneManager.GetActiveScene().buildIndex + 1;
        if (proxima < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(proxima);
        else
            SceneManager.LoadScene("MenuFinal");
    }
}
