using UnityEngine;

public class Bullet : MonoBehaviour {
    private Rigidbody _Rigidbody;
    public float _Speed = 30f;
    public float _Timer = 5f;

    void Start () => _Rigidbody = GetComponent<Rigidbody> ();

    // Update is called once per frame
    void Update () {
        _Rigidbody.velocity = transform.rotation * Vector3.forward * _Speed;

        _Timer -= Time.deltaTime;

        if (_Timer <= 0) {
            Destroy (gameObject);
            _Timer = 5;
        }
    }
    void OnCollisionEnter (Collision other) {
        if (other.collider.CompareTag ("Homes"))
            Destroy (gameObject);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SpawnManager.Instance._DieEnemy.Play();
            Destroy(other.gameObject);
        }
       
        Destroy(this.gameObject);


    }

}