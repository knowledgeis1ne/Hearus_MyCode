using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

<<<<<<< HEAD
// �κ��丮 ���Կ� ���� ����� ������ ��ũ��Ʈ. 

public class InventorySlot : MonoBehaviour
{
    public static InventorySlot instance;

    public Image icon;
    public TextMeshProUGUI itemCount_Text;

    private void Awake()
    {
        instance = this;
    }

=======
public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI itemCount_Text;

>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
    public void Additem(Item _item) {
        icon.sprite = _item.itemIcon;           // ���� ������ ����
        Color color = icon.color;
        color.a = 255f;
        icon.color = color;                     // ���� �̹����� ���� �� ����
<<<<<<< HEAD
        if (_item.itemCount > 0)
        {
            itemCount_Text.text = _item.itemCount.ToString();
        }
        else
            itemCount_Text.text = "";
    }

    public void IncreaseCount(Item _item)
=======
        if(Item.ItemType.�Ҹ�ǰ == _item.itemType) // �������� �Ҹ�ǰ�� ��� ���� ǥ��
        {
            if (_item.itemCount > 0)
            {
                itemCount_Text.text = _item.itemCount.ToString();
            }
            else
                itemCount_Text.text = "";
        }
    }

    public void setItemCount(Item _item)
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
    {
            if (_item.itemCount > 0)
            {
                _item.itemCount += 1;
                itemCount_Text.text = _item.itemCount.ToString();
            }
            else
                itemCount_Text.text = "";
    }

<<<<<<< HEAD
    public void DecreaseCount(Item _item)
    {
        if (_item.itemCount > 1)
        {
            _item.itemCount -= 1;
            itemCount_Text.text = _item.itemCount.ToString();
        }
        else
            Debug.Log("��ȿ���� ���� ����Դϴ�.");
    }

    public void RemoveItem()
    {
        Color color = icon.color;
        color.a = 0f;
        icon.color = color;                     // ���� ���� �� 0���� ����
        itemCount_Text.text = "";               // count�� ��Ÿ���� �ؽ�Ʈ null�� ����
        icon.sprite = null;                     // ���� �̹��� null�� ����
    }
}
=======
    public void RemoveItem()
    {
        itemCount_Text.text = "";
        icon.sprite = null;
    }
}
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
