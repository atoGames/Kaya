using UnityEngine;

[CreateAssetMenu(fileName = "Create new Data", menuName = "Inventory/New Data", order = 1)]
public class AllData : ScriptableObject
{
	 [System.Serializable]
    public struct GameData
    {
        public string Name;
        public int Quantity;
        public Sprite Sprite;
        public GameObject PrefabObj;
        public USE_TYPE UseType;

    }
    public GameData[] Data;
   
}