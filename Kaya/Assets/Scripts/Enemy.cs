using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    private NavMeshAgent _Agent;
    [HideInInspector]
    public Player player;

    public bool playerCloseToMe = false;

    public float DistanceToPlayer = 10;

    public GameObject ammoPrefab;
    public Transform Shoot_Point;

    public float _TimerShoot ;

    public float _TimerBetShoot = 3f;

    void Start()
    {
        _TimerShoot = _TimerBetShoot;

        _Agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (player != null )
        {
            var d = Vector3.Distance(this.transform.position, player.transform.position);

            if (d < DistanceToPlayer)
                playerCloseToMe = true;
            else
                playerCloseToMe = false;

            if (playerCloseToMe && player.gameObject.activeSelf == true)
            {
                MoveTo();
                _TimerShoot -= Time.deltaTime;

                if (_TimerShoot <= 0)
                {
                    Shoot();
                    _TimerShoot = _TimerBetShoot;
                }
            }
        }
    }

    void  MoveTo() => _Agent.SetDestination(player.transform.position);

    void Shoot() => Instantiate(ammoPrefab, Shoot_Point.position, transform.rotation );

}
