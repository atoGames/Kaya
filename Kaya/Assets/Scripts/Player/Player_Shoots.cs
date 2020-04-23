using UnityEngine;

public class Player_Shoots : MonoBehaviour
{
    public GameObject goBulit;
    public Transform Shoot_Point;
    [SerializeField]
    private float Shatgin = 5;
    private float _circleAngle = 0;

    public int Ammo = 5;
    public int AmmoShatgin = 5;

    private Player player;

    void Start() => player = GetComponent<Player>();

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Inventory.Instance.EquipTransform.childCount >= 1)
        {
            if (Ammo <= 0)
                SpawnManager.Instance._NoAmmo.Play();
            else
            {
                SpawnManager.Instance._Shoot.Play();

                Shoot(goBulit);
                Ammo--;
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && Inventory.Instance.EquipTransform.childCount >= 1 )
        {
            if (AmmoShatgin <= 0)
                SpawnManager.Instance._NoAmmo.Play();
            else
            {
                SpawnManager.Instance._Shoot2.Play();

                BunchShoot(goBulit);
                AmmoShatgin--;
            }
         
        }
    }

   
    void Shoot(GameObject go ) => Instantiate(go ,Shoot_Point.position , transform.rotation);

      void BunchShoot(GameObject go )
    {
        for (int i = 0; i <= Shatgin; i++)
        {
        var dir = transform.position ; // 
            dir.x = Mathf.Sin (Mathf.Deg2Rad * -_circleAngle + i);
            dir.y =0;
            dir.z = Mathf.Cos (Mathf.Deg2Rad * -_circleAngle + i );
            
         Instantiate(go , transform.position + dir ,  Quaternion.FromToRotation(transform.rotation * transform.position , dir));
            
        }
    }
}
