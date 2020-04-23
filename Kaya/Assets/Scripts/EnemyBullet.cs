using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody _Rigidbody;
    public float _Speed = 30f;
    public float _Timer = 5f;

    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _Rigidbody.velocity = transform.rotation * Vector3.forward * _Speed;

        _Timer -= Time.deltaTime;

        if (_Timer <= 0)
        {
            Destroy(gameObject);
            _Timer = 5;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Homes"))
            Destroy(gameObject);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player>() != null)
                other.GetComponent<Player>().Damge(5);

        }
        Destroy(gameObject);

    }

}
