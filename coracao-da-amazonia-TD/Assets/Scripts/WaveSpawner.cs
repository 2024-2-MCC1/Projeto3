using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    //ponto onde os inimigos vao aparecer
    public Transform spawnPoint;

    //tempo entre o final de uma onda e o inicio da proxima
    public float timeBetweenWaves = 3f;
    //contador inicial da primeira onda
    private float countdown = 5f;

    //texto da contagem regressiva entre as ondas
    public TextMeshProUGUI waveCountdownText;

    //indice que representa o numero da onda atual
    private int waveIndex = 0;

    void Update ()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }
        //quando o contador atinge zero ou menos, o metodo SpawnWave é chamado como uma corrotina para inciciar uma nova onda de inimigos
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            //apos iniciar a onda o countdown é reiniciado
            countdown = timeBetweenWaves;
            return;
        }
        
        //decrementa o contador em tempo real
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    //Corrotina responsavel por criar uma nova onda
    IEnumerator SpawnWave ()
    {
        Wave wave = waves[waveIndex];

        //gera um numero de inimigos equivalente ao valor atual da waveIndex (a cada onda, aparecem mais inimigos)
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            //espera 0,5 segundos entre cada inimigo
            yield return new WaitForSeconds(1f / wave.rate);
        }
        //incrementa o numero da onda
        waveIndex++;
        if (waveIndex == 6)
        {
            SceneManager.LoadScene("Win");
        }
    }

    void SpawnEnemy (GameObject enemy)
    {
        //instancia um novo inimigo na posiçao e rotaçao do spawnPoint
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
