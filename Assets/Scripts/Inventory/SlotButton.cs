using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
// ���� Ŭ���� ������ ��ũ��Ʈ.

=======
>>>>>>> 1f78285fb3a123f08c9a267a909af1f923f16e51
public class SlotButton : MonoBehaviour
{
    public int slotIndex;

    public void OnButtonClick()
    {
        Inventory.instance.selectedSlot = slotIndex;
    }
}
