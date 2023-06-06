using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

<<<<<<< HEAD
// ũ������ ��� ���� �ڵ�.

public class Crafting : MonoBehaviour
{
    public static Crafting instance;

=======
public class Crafting : MonoBehaviour
{
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
    private List<InventorySlot> craftingSlots;
    public Transform tf_craftingSlots;

    public List<Item> craftingItemList;

    public CraftingCombination craftingCombination; // ũ������ ���� ��ü

<<<<<<< HEAD
    public GameObject go_Guide;
    public GameObject go_Inventory;
    public GameObject go_Page1;
    public GameObject go_TapPanel;

    public GameObject go_ExitButton;
    public GameObject go_BackButton;

    public bool isGuideActivated;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        isGuideActivated = false;
        go_BackButton.SetActive(false);
=======
    private void Start()
    {
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
        craftingSlots = new List<InventorySlot>(tf_craftingSlots.GetComponentsInChildren<InventorySlot>());
        craftingItemList = new List<Item>();
    }

<<<<<<< HEAD
    private void Update()
    {
       if (isGuideActivated)
        {
            go_Guide.SetActive(isGuideActivated);
            go_BackButton.SetActive(isGuideActivated);
            go_Inventory.SetActive(!isGuideActivated);
            go_ExitButton.SetActive(!isGuideActivated);
        }
       else
        {
            go_Guide.SetActive(isGuideActivated);
            go_BackButton.SetActive(isGuideActivated);
            go_ExitButton.SetActive(!isGuideActivated);
        }

       if (!go_Page1.activeSelf || !go_TapPanel.activeSelf || go_Inventory.activeSelf)
        {
            isGuideActivated = false;
        }
    }

=======
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
    public void onCiickSelectButton()
    {
        if (craftingItemList.Count > 0)
        {
            for (int i = 0; i < craftingItemList.Count; i++) // ũ������ ������ ����Ʈ�� ������ �������� �ִ��� �˻�
            {
<<<<<<< HEAD
                if (craftingItemList[i].itemCount == Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].itemCount) // i��°
                {
                    Debug.Log("���� ���� �̻��� ���� �� �����ϴ�.");
                    return;
                }

                if (craftingItemList[i].itemID == Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].itemID)
                {
                    craftingItemList[i].CloneItem(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot]);
                    craftingSlots[i].IncreaseCount(craftingItemList[i]);
=======
                CheckItemAmount(i);

                if (craftingItemList[i].itemID == Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].itemID)
                {
                    craftingItemList[i].itemCount += 1;
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
                    return;
                }
            }
        if (craftingItemList.Count == 3)                     // ������ ���� �� �� ���
            {
                Debug.Log("�� ������ �����ϴ�.");
                return;
            }
        }

<<<<<<< HEAD
        craftingItemList.Add(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].CloneItem(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot]));
=======
        craftingItemList.Add(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot]);
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51

        InsertSlot();

        return;
    }

    public void onClickCraftingButton()
    {
<<<<<<< HEAD
        int output;

=======
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
        if (craftingItemList.Count < 1)
        {
            Debug.Log("�������� �ϳ� �̻� ��������.");
            return;
        }
        else
        {
<<<<<<< HEAD
            output = CheckCombination();

            if (output != 0)
            {
            Inventory.instance.GetAnItem(output); // ���� ����� �κ��丮�� ����
            
            for (int i = 0; i < craftingItemList.Count; i++) // ũ������ ���� �ʱ�ȭ
            {
                 craftingSlots[i].RemoveItem();
                 for (int j = 0; j < Inventory.instance.inventoryItemList.Count; j++)
                 {
                     if (craftingItemList[i].itemID == Inventory.instance.inventoryItemList[j].itemID)
                     {
                            Inventory.instance.DeleteItem(Inventory.instance.inventoryItemList[j]); // ��� ������ �κ��丮���� ����
                     }
                 }
            }
            craftingItemList.Clear(); // ũ������ ������ ����Ʈ �ʱ�ȭ
            }
            else
            {
                Debug.Log("�������� �ʴ� �����Դϴ�.");
            }
        }
    }

    public void onClickGuideButton()
    {
        isGuideActivated = true;

        Inventory.instance.activated = false;
    }

    public void onClickBackButton()
    {
        isGuideActivated = false;

        Inventory.instance.activated = true;
    }

    public void InsertSlot() // ũ������ ���Կ� ������ �߰�
    {
        if (craftingItemList.Count > 0)
        {
            craftingSlots[craftingItemList.Count - 1].Additem(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot].CloneItem(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot]));
=======
 //           CheckCombination();
        }
    }

    public void InsertSlot()
    {
        if (craftingItemList.Count > 0)
        {
            craftingSlots[craftingItemList.Count - 1].Additem(Inventory.instance.inventoryItemList[Inventory.instance.selectedSlot]);
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
        }
        return;
    }

<<<<<<< HEAD
    public void CheckItemAmount(int i) // ���� ���� �̻� �߰� ����
=======
    public void CheckItemAmount(int i)
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
    {
        if (craftingItemList[i].itemCount == Inventory.instance.inventoryItemList[i].itemCount)
        {
            Debug.Log("���� ���� �̻��� ���� �� �����ϴ�.");
        }
    }

    public void SlotItem()
    {
<<<<<<< HEAD
        if (craftingItemList.Count == 2) // 2���� ���������� ������ �õ��ϴ� ���
=======
        if (craftingItemList.Count == 2)        // 2���� ���������� ������ �õ��ϴ� ���
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
        {
//            craftingItemList[0].itemCount == 
        }
    }

<<<<<<< HEAD
 
    public int CheckCombination()
    {
        int output = 0;

=======
 /*
    public int CheckCombination()
    {
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
        if (craftingItemList.Count == 1)
        {
            for (int i = 0; i < craftingCombination.combinations.Count; i++)
            {
<<<<<<< HEAD
                if (craftingItemList[0].itemID == craftingCombination.combinations[i].firstID &&
                    craftingItemList[0].itemCount == craftingCombination.combinations[i].firstCount)
                {
                    Debug.Log(craftingCombination.combinations[i].outputID);
                    output = craftingCombination.combinations[i].outputID;
                }
                else
                {
=======
                if (craftingItemList[0].itemID == craftingCombination.combinations[i].firstID)
                {
                    Debug.Log(craftingCombination.combinations[i].outputID);
                    return craftingCombination.combinations[i].outputID;
                }
                else
                {
                    Debug.Log("�������� �ʴ� �����Դϴ�.");
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
                    return 0;
                }
            }
        }
<<<<<<< HEAD
        else if (craftingItemList.Count == 2) // ���⼭���� ���� �ʿ�
        {
            for (int i = 0; i < craftingCombination.combinations.Count; i++)
            {
                if (((craftingItemList[0].itemID == craftingCombination.combinations[i].firstID) &&
                    (craftingItemList[0].itemCount == craftingCombination.combinations[i].firstCount)) ||
                   ((craftingItemList[0].itemID == craftingCombination.combinations[i].secondID) &&
                    (craftingItemList[0].itemCount == craftingCombination.combinations[i].secondCount)) ||
                        ((craftingItemList[1].itemID == craftingCombination.combinations[i].firstID) &&
                        (craftingItemList[1].itemCount == craftingCombination.combinations[i].firstCount)) ||
                        ((craftingItemList[1].itemID == craftingCombination.combinations[i].secondID) &&
                    (craftingItemList[1].itemCount == craftingCombination.combinations[i].secondCount)))
                {
                    Debug.Log(craftingCombination.combinations[i].outputID);
                    output = craftingCombination.combinations[i].outputID;
                }
                else 
                { 
                    return 0;
=======
        else if (craftingItemList.Count == 2)
        {
            for (int i = 0; i < craftingCombination.combinations.Count; i++)
            {
                if ((craftingItemList[0].itemID == craftingCombination.combinations[i].firstID ||
                    craftingItemList[0].itemID == craftingCombination.combinations[i].secondID) &&
                        (craftingItemList[1].itemID == craftingCombination.combinations[i].firstID ||
                        craftingItemList[1].itemID == craftingCombination.combinations[i].secondID)) {
                    Debug.Log(craftingCombination.combinations[i].outputID);
                    return craftingCombination.combinations[i].outputID;
                }
                else
                {
                    Debug.Log("�������� �ʴ� �����Դϴ�.");
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
                }
            }
        }
        else if (craftingItemList.Count == 3)
        {
            for (int i = 0; i < craftingCombination.combinations.Count; i++)
            {
<<<<<<< HEAD
                if ((
                    ((craftingItemList[0].itemID == craftingCombination.combinations[i].firstID) &&
                    (craftingItemList[0].itemCount == craftingCombination.combinations[i].firstCount)) ||
                     (craftingItemList[0].itemID == craftingCombination.combinations[i].secondID) ||
                     (craftingItemList[0].itemID == craftingCombination.combinations[i].thirdID)) &&
                          (
                          (craftingItemList[1].itemID == craftingCombination.combinations[i].firstID) ||
                           (craftingItemList[1].itemID == craftingCombination.combinations[i].secondID) ||
                           (craftingItemList[1].itemID == craftingCombination.combinations[i].thirdID)) &&
                           (
                           (craftingItemList[2].itemID == craftingCombination.combinations[i].firstID) ||
                            (craftingItemList[2].itemID == craftingCombination.combinations[i].secondID) ||
                            (craftingItemList[2].itemID == craftingCombination.combinations[i].thirdID)))
                {
                    Debug.Log(craftingCombination.combinations[i].outputID);
                    output = craftingCombination.combinations[i].outputID;
                }
                else
                { 
                    return 0;
                }
            }
        }
        else
        {
            return 0;
        }

        return output;
    }

    public void CraftItem()
    {
        
=======
 //             if ((����1||����2||����3)&&(����4||����5||����6)&&(����7||����8||����9))
            }
        }
    }
 */

    public void CraftItem()
    {

>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
    }
}
