using UnityEngine;

public class Player : MonoBehaviour
{

    private Inventory playerInventory;
    [SerializeField]
    private ItemWorld itemWorld;
    [HideInInspector]
    public Player_Shoots player_Shoot;
    // public Animator _cgAlpha;

    public bool followMe= false;

    public int Helath; // { get; set; }
    public int Water;
    public int Food;
    public int maxAllConsum = 100;


    public void TakeHealth(int health) => Helath += health;
    public void EateFood(int food) => Food += food;
    public void DrinkWater(int water) => Water += water;

    public void Damge(int damge) => Helath -= damge;

    public void RestAllData() => Helath = Water = Food = maxAllConsum;

    public float timerDown = 3f;

    void CalEnergy()
    {
        timerDown -= Time.deltaTime;

        if (timerDown <= 0)
        {
            Water -= 1;
            Food -= 1;
            timerDown = 3;

            if (Water <= 0 || Food <= 0)
                Helath -= 2;
        }
    }

    void Start()
    {
        RestAllData();
        playerInventory = GetComponent<Inventory>();
        player_Shoot = GetComponent<Player_Shoots>();
      //  _cgAlpha.SetBool("cgAlpja", true);
    }

    void Update()
    {
        // Take Somthing 
        if (Input.GetKeyDown(KeyCode.T) && itemWorld != null && playerInventory.inventory_UI.childCount < playerInventory.numItemSlots)
        {
            // Debug.Log("Take Item" + itemCollection.gameObject.name );
            SpawnManager.Instance._Taking.Play();

            playerInventory.AddItem(itemWorld.ID, itemWorld.Quantity);
            Destroy(itemWorld.gameObject);
        }
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    playerInventory.isDropAllItems = true;
        //}
        //if (playerInventory.isDropAllItems)
        //    playerInventory.DropAllItems();

        CalEnergy();
        if(Helath <= 0 || transform.position.y < -20 )
            Die();

    }

    void Die()
    {
            FindObjectOfType<SpawnManager>().diePanel.SetActive(true);
            gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (other.GetComponent<ItemWorld>() != null)
                itemWorld = other.GetComponent<ItemWorld>();
        }
        if (other.CompareTag("Die"))
        {
            gameObject.SetActive(false);
           FindObjectOfType<SpawnManager>().diePanel.SetActive(true);
            Debug.Log("Die");
        }
        if (other.CompareTag("Box"))
        {
            if(followMe)
            SpawnManager.Instance.winPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (itemWorld != null)
                itemWorld = null;
        }
    }
}
