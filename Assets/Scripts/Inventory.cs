using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private ItemDatabase theDatabase;       // ������ �����ͺ��̽� ��ü

    private List<InventorySlot> slots;      // �κ��丮 ���Ե�
    public Transform tf;                    // ���Ե��� �θ� ��ü (GridSlot)

    private ItemDescription itemDes;
    public Transform tf_itemDes;

    private List<Item> inventoryItemList;   // �÷��̾ ������ ������ ����Ʈ

    public GameObject slotPrefab;           // ���� ���� ������ ���� ���� ������ �ҷ�����
    public GameObject go_Inventory;         // �κ��丮 Ȱ��ȭ/��Ȱ��ȭ�� ���� GameObject �ҷ�����
    public GameObject go_SelectedImage;     // ���õ� �����̶�� ���� ��Ÿ���� �̹��� �ҷ�����

    public Button button;                   // Ŭ�����ε� ������ ������ �� �ֵ��� �ϴ� ��ư

    public int selectedSlot;                // ���õ� ���� -> �⺻�� 0

    private bool activated;                 // �κ��丮 Ȱ��ȭ �� true
    private bool stopKeyInput;              // Ű �Է� ���� (�Һ��� ��, ������ �� �˾� �޽��� �߸� Ű �Է� ����)
    private bool preventMove;
    private bool preventExec;

    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    private void Awake()
    {
        // �̱���
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);  // �� ��ȯ �ÿ��� ����
    }

    void Start()
    {
        theDatabase = FindObjectOfType<ItemDatabase>();                 // ������ �����ͺ��̽� ������Ʈ
        inventoryItemList = new List<Item>();                           // �κ��丮 ������ ����Ʈ
        slots = new List<InventorySlot>(tf.GetComponentsInChildren<InventorySlot>());
        itemDes = tf_itemDes.GetComponentInChildren<ItemDescription>();
        selectedSlot = 0;
    }

    void Update()
    {
        if (!stopKeyInput)
        {
            if (Input.GetKeyDown(KeyCode.I)) // �κ��丮 Ȱ��ȭ
            {
                activated = !activated;
                if (activated)
                {
                    go_Inventory.SetActive(true);
                    preventExec = true;
                    GameObject.FindObjectOfType<Player>().speed = 0; // �κ��丮 Ȱ��ȭ �� �÷��̾� �ӵ� 0
                }
                else
                {
                    go_Inventory.SetActive(false);
                    GameObject.FindObjectOfType<Player>().speed = 3; // �κ��丮 ��Ȱ��ȭ �� �÷��̾� �ӵ� ���� ���� (�ӵ� ���� �ʿ�)
                    preventExec = false;
                }
            }
            if (activated)
            {
                if (inventoryItemList.Count > 0) // �κ��丮 ������ ����Ʈ�� ����� ��Ұ� ���� ��쿡�� ����
                {
                    go_SelectedImage.SetActive(true);
                    TryInputArrowKey();
                    SelectedItemDes(inventoryItemList[selectedSlot].itemID);
                }
            }
        }
    }
    public void GetAnItem(int _itemID, int _count = 1)              // �κ��丮 ����Ʈ�� ������ �߰�
    {
        for (int i = 0; i < theDatabase.itemList.Count; i++)        // �����ͺ��̽� ������ �˻�
        {
            if (_itemID == theDatabase.itemList[i].itemID)          // �����ͺ��̽� ������ �߰�
            {
                for (int j = 0; j < inventoryItemList.Count; j++)   // ����ǰ �� ���� �������� �ִ��� �˻�
                {
                    if (inventoryItemList[j].itemID == _itemID)     // ���� �������� �ִٸ� ������ ����
                    {
                        // inventoryItemList[j].itemCount += _count;
                        slots[j].setItemCount(inventoryItemList[j]);
                        return;
                    }

                }
                inventoryItemList.Add(theDatabase.itemList[i]);     // ���ٸ� ����ǰ�� �ش� ������ �߰�
                CreateSlot();
                slots[slots.Count - 1].Additem(theDatabase.itemList[i]);
                return;
            }
        }
        Debug.LogError("�����ͺ��̽��� �ش� ID ���� ���� �������� �������� �ʽ��ϴ�.");
    }
    public void CreateSlot()        // ���ο� �������� ��� ���ο� ���� ����
    {
        InventorySlot slot = Instantiate(slotPrefab, tf).GetComponent<InventorySlot>();
        slots.Add(slot);
    }
    private void SelectedSlot()     // ������ ���õǾ����� ��Ÿ���� �̹���(�׵θ�) ��ġ �̵�
    {
        go_SelectedImage.transform.position = slots[selectedSlot].transform.position;
    }
    private void TryInputArrowKey() // Ű����� ���õ� ���� ����
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeSlotLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeSlotRight();
        }
        SelectedSlot();
    }
    private void ChangeSlotLeft()   // ���� �������� �̵� (�κ��丮 ������ ����Ʈ�� ���� �������� �۵�)
    {
            if (selectedSlot == 0)
                selectedSlot = inventoryItemList.Count - 1;
            else
                selectedSlot--;
    }
    private void ChangeSlotRight()  // ������ �������� �̵� (�κ��丮 ������ ����Ʈ�� ���� �������� �۵�)
    {
            if (selectedSlot == inventoryItemList.Count - 1)
                selectedSlot = 0;
            else
                selectedSlot++;
    }
    private void SelectedItemDes(int _itemID)                   // ���õ� �������� ������ ���� ��
    {
        for (int i = 0; i < inventoryItemList.Count; i++)
        {
            if (inventoryItemList[i].itemID == _itemID)
                itemDes.DisplayDes(inventoryItemList[i]);
            break;
        }

    }
    private void PreventMove()
    {
        if (preventMove == true)
            GameObject.FindObjectOfType<Player>().speed = 0;
        else
            GameObject.FindObjectOfType<Player>().speed = 3;
    }
}
