using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

<<<<<<< HEAD
// ������ Ŭ������ ������ ��ũ��Ʈ.

[System.Serializable]
public class Item
{
=======
[System.Serializable]
public class Item
{
    // ������ Ŭ����

>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
    public int itemID; // ������ ���� ID ��
    public string itemName; // ������ �̸�
    public string itemDescription; // ������ ����
    public int itemCount; // ���� ����
<<<<<<< HEAD
    public int itemEffectValue;
    public Sprite itemIcon;
    public ItemType itemType;
    public ItemEffect itemEffect;
=======
    public Sprite itemIcon;
    public ItemType itemType;
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51

    public enum ItemType
    {
        �Ҹ�ǰ,
        ����,
        ���,
        ��ǰ,
        ����
    }

<<<<<<< HEAD
    public enum ItemEffect
    {
        ȸ��,
        ����,
        ��Ÿ
    }

    public Item(int _itemID, string _itemName, string _itemDes, ItemType _itemType, ItemEffect _itemEffect, int _itemEffectValue, int _itemCount = 1)   // ������
=======
    public Item(int _itemID, string _itemName, string _itemDes, ItemType _itemType, int _itemCount = 1)   // ������
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
    {
        // itemID�� ������ ������ �̸��� ���� ��
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        itemCount = _itemCount;
<<<<<<< HEAD
        itemEffect = _itemEffect;
        itemEffectValue = _itemEffectValue;
        itemIcon = Resources.Load("ItemIcon/" + _itemID.ToString(), typeof(Sprite)) as Sprite;
    }

    public Item CloneItem(Item _item)
    {
        Item cloneItem = new Item(_item.itemID, _item.itemName, _item.itemDescription, _item.itemType, _item.itemEffect, _item.itemEffectValue, 1);

        return cloneItem;
=======
        itemIcon = Resources.Load("ItemIcon/" + _itemID.ToString(), typeof(Sprite)) as Sprite;
    }

    public void CloneItem(Item _item)
    {
        
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
    }
}
