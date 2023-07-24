using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragHandler DragableItem = dropped.GetComponent<DragHandler>();
        DragableItem.parentAfterDrag = transform;
        AudioManager.instance.Play("POP");
    }
}
