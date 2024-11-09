using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    //ponto onde os inimigos vao aparecer
    public Transform spawnPoint;

    //tempo entre o final de uma onda e o inicio da proxima
    public float timeBetweenWaves = 5f;
    //contador inicial da primeira onda
    private float countdown = 5f;

    //texto da contagem regressiva entre as ondas
    public TextMeshProUGUI waveCountdownText;

    //indice que representa o numero da onda atual
    private int waveIndex = 0;

    void Update ()
    {
        //quando o contador atinge zero ou menos, o metodo SpawnWave é chamado como uma corrotina para inciciar uma nova onda de inimigos
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            //apos iniciar a onda o countdown é reiniciado
            countdown = timeBetweenWaves;
        }
        //atualiza o texto da contagem arredondando o valor pra cima
        waveCountdownText.text = Mathf.Ceil(countdown).ToString();
        //decrementa o contador em tempo real
        countdown -= Time.deltaTime;
    }
    //Corrotina responsavel por criar uma nova onda
    IEnumerator SpawnWave ()
    {
        //incrementa o numero da onda
        waveIndex++;
        //gera um numero de inimigos equivalente ao valor atual da waveIndex (a cada onda, aparecem mais inimigos)
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            //espera 0,5 segundos entre cada inimigo
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void SpawnEnemy ()
    {
        //instancia um novo inimigo na posiçao e rotaçao do spawnPoint
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
