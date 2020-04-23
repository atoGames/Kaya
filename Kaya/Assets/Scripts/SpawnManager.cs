using UnityEngine.SceneManagement;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    public Transform Rspawn;
    public GameObject playerPrefab;
    public GameObject diePanel;
    public GameObject winPanel;
    public GameObject dieTut;

    private Player player;


    public AudioSource _DieEnemy;
    public AudioSource _NoAmmo;
    public AudioSource _Shoot;
    public AudioSource _Shoot2;
    public AudioSource _Taking;
    public AudioSource _FollowMe;
    public AudioSource _Drink;

    public _Point[] enemyPointSpawn;
    public int numEnemy = 15;
    public GameObject EnemyPrefab;


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        player = FindObjectOfType<Player>();
        enemyPointSpawn = FindObjectsOfType<_Point>();
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    if (dieTut.activeSelf == true)
        //        dieTut.SetActive(false);
        //    else
        //        dieTut.SetActive(true);
        //}

        if (this.transform.childCount >=  numEnemy )
             return;
             SpawnEnemy();
    }

   
    private void SpawnEnemy()
    {
        var p_Point = Random.Range(0, enemyPointSpawn.Length);

        if (enemyPointSpawn[p_Point].gameObject.activeSelf == false)
            return;

           GameObject go = Instantiate(EnemyPrefab, enemyPointSpawn[p_Point].transform.position, Quaternion.identity);
           go.transform.parent = this.transform;
    }

    public void btnPlayAgain()
    {
        player.transform.position = Rspawn.position;
        player.gameObject.SetActive(true);
        player.RestAllData();
        diePanel.SetActive(false);

        FindObjectOfType<Son>().Helath = 100;
    }
    public void btnShowTut(bool show) => dieTut.SetActive(show);
    public void btnGoBack()
    {
        SceneManager.LoadScene(0);
    }
    public void btnQuit() => Application.Quit();

}
