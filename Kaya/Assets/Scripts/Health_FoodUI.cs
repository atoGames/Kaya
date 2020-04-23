using UnityEngine;
using UnityEngine.UI;

public class Health_FoodUI : MonoBehaviour
{
    public Image HealthBar ,  WaterBar , FoodBar;

    Player player;

    void Start()
    {
        if (player == null) player = FindObjectOfType<Player>();
    }

    void Update()
    {

       HealthBar.fillAmount = (float )player.Helath / 100 ;
       WaterBar.fillAmount = (float)player.Water / 100;
       FoodBar.fillAmount = (float)player.Food / 100;


    }


}
