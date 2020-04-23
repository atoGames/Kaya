using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class Son : MonoBehaviour
{
    private NavMeshAgent _Agent;
    private Player player;

    public GameObject myDad;

    public int Helath;
    public int maxHelath = 100;

    public Image HealthBar;

    public float timerDown = 10;
    void CalHelath()
    {
        timerDown -= Time.deltaTime;

        if (timerDown <= 0)
        {
            Helath -= 2;
            timerDown = 10;
        }
       
    }
    void Start()
    {
        Helath = maxHelath;
        _Agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (player.followMe)
            MoveTo();

        CalHelath();

        HealthBar.fillAmount = (float)Helath / 100;

        if (Input.GetKeyDown(KeyCode.F) && myDad != null)
        {
            player.followMe = true;
            SpawnManager.Instance._FollowMe.Play();
        }
        if (Input.GetKeyDown(KeyCode.G))
            player.followMe = false;

        if (!player.followMe)
        {
            if (Helath <= 0)
                FindObjectOfType<SpawnManager>().diePanel.SetActive(true);
        }
    }

    void MoveTo() => _Agent.destination = player.transform.position;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player!");
            myDad = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player!");
            myDad = null;

        }
    }

}
