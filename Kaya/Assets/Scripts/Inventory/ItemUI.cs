using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemUI : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public TextMeshProUGUI m_Quantity;
    [HideInInspector]
    public Image m_Sprite;

    Inventory myInventory;

    public int m_ID;

    void Awake()
    {
        m_Quantity = GetComponentInChildren<TextMeshProUGUI>();
        m_Sprite = GetComponent<Image>();
        myInventory = FindObjectOfType<Inventory>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //  Debug.Log("Left click");
            if (myInventory.myData.Data[m_ID].UseType == USE_TYPE.Consume)
            {
                if (myInventory.myData.Data[m_ID].Name == "Food")
                {
                    myInventory.RemoveItem(m_ID, 1);
                    myInventory.player.EateFood(1);
                    myInventory.player.DrinkWater(1);
                }
                else if ((myInventory.myData.Data[m_ID].Name == "Water"))
                {
                    myInventory.RemoveItem(m_ID, 1);
                    myInventory.player.DrinkWater(1);
                }

            }
            else if (myInventory.myData.Data[m_ID].UseType == USE_TYPE.Equip)
                myInventory.Equip(eventData.pointerPress.transform);

            else if (myInventory.myData.Data[m_ID].UseType == USE_TYPE.Ammo)
            {
                if (myInventory.myData.Data[m_ID].Name == "Ammo")
                {
                    myInventory.RemoveItem(m_ID, 1);
                    myInventory.player.player_Shoot.Ammo += 1;
                }
                else if ((myInventory.myData.Data[m_ID].Name == "AmmoShatgin"))
                {
                    myInventory.RemoveItem(m_ID, 5);
                    myInventory.player.player_Shoot.AmmoShatgin += 5;
                }
              
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
            //  Debug.Log("Right click");
            myInventory.DropItem(m_ID);
    }

 
}
