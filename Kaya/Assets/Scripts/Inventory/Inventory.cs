using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour {

    [HideInInspector]
    public Player player;

    public static Inventory Instance;
    public Transform EquipTransform;

    [Header (" This Interface For UI & Player ")]
    public Transform inventory_UI;
    public ItemUI _itemPrefab;
    List<ItemUI> _itemUI = new List<ItemUI>();

    public AllData myData;

    public List<Inventory_ID> _InventoryID;

    // Inventory Slot
    public int numItemSlots = 5;
    public bool isDropAllItems = false;

    private void Awake () {
        player = GetComponent<Player>();
        UpdateInventory ();
        Instance = this;
    }
    // Add Item
    public void AddItem (int _id, int _Quantity) {
        for (int i = 0; i < _InventoryID.Count; i++) {
            if (_InventoryID[i].id == _id) {
                _InventoryID[i] = new Inventory_ID (_InventoryID[i].id, _InventoryID[i].quantity + _Quantity);

                UpdateInventory ();
                return;
            }
        }
        _InventoryID.Add (new Inventory_ID (_id, _Quantity));
        UpdateInventory ();
    }

    // Remove Item
    public void RemoveItem (int _id, int _Quantity) {
        for (int i = 0; i < _InventoryID.Count; i++) {
            if (_InventoryID[i].id == _id) {
                _InventoryID[i] = new Inventory_ID (_InventoryID[i].id, _InventoryID[i].quantity - _Quantity);
                if (_InventoryID[i].quantity <= 0) {
                    _InventoryID.Remove (_InventoryID[i]);
                    Destroy (_itemUI[i].gameObject);
                    _itemUI.Remove (_itemUI[i]);
                }
                UpdateInventory ();
                return;
            }
        }
    }
  
    public void UpdateInventory () {
        // we have this Item 
         for (int i = 0; i < _itemUI.Count; i++) {
            if (i < _InventoryID.Count) {
                Inventory_ID InvID = _InventoryID[i];
                _itemUI[i].m_Sprite.sprite = myData.Data[InvID.id].Sprite;
                _itemUI[i].m_Quantity.text = InvID.quantity.ToString ();
                _itemUI[i].m_ID = InvID.id;
            }
        } 
        // we don't have this Item then Addit to List
        if (_InventoryID.Count > _itemUI.Count) {
            for (int i = _itemUI.Count; i < _InventoryID.Count; i++) {
                ItemUI itemUI = Instantiate(_itemPrefab.GetComponent<ItemUI>(), inventory_UI);
                _itemUI.Add (itemUI);

                Inventory_ID InvID = _InventoryID[i];
                _itemUI[i].m_Sprite.sprite = myData.Data[InvID.id].Sprite;
                _itemUI[i].m_Quantity.text = InvID.quantity.ToString ();
                _itemUI[i].m_ID = InvID.id;

                print(" Create New ItemUI! ");
            }
        }
    }

    public void Equip(Transform go1 )
    {
        if (go1 != null && EquipTransform.childCount == 0)
            go1.SetParent(EquipTransform);
        else if (go1 != null && inventory_UI.childCount < numItemSlots)
        {
            EquipTransform.GetChild(0).SetParent(inventory_UI);
            go1.SetParent(EquipTransform);
        }
        else
            Debug.LogError(" Non Item! ");

        UpdateInventory();
    }
    public void DropItem(int id)
    {
        ItemWorld oi = Instantiate(myData.Data[id].PrefabObj.GetComponent<ItemWorld>(), RandomItemPosition() ,  Quaternion.identity);
        oi.ID = id;
        RemoveItem(id, 1);
    }
    //public void DropAllItems()
    //{
    //    if (_InventoryID.Count > 0)
    //    {
    //        Debug.Log(_InventoryID.Count);
    //        for (int i = 0; i <= _InventoryID.Count ; i++)
    //        {
    //            Debug.Log(" He " + i);
    //            DropItem(_InventoryID[i].id);
    //        }
    //    }
    //    if (_InventoryID.Count <= 0)
    //        isDropAllItems = false;
    //}
    private Vector3 RandomItemPosition()
    {
        var r = Random.Range(-1, 1);
        var dir = transform.position; // 

        for (int i = 0; i <= _InventoryID.Count; i++)
        {
            dir.x = Mathf.Sin(Mathf.Deg2Rad * -r + i);
            dir.y = .1f;
            dir.z = Mathf.Cos(Mathf.Deg2Rad * -r + i);
        }
        return  transform.position + dir;
    }


    [System.Serializable]
    public struct Inventory_ID
    {
        public int id;
        public int quantity;

        public Inventory_ID(int id, int Quan)
        {
            this.id = id;
            this.quantity = Quan;
        }
    }
}
