using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragAction : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{

    bool started, moved;
    Vector3 startPosition;

    public UnityEvent OnDragUp, OnDragDown, OnDragLeft, OnDragRight;

    public void OnPointerDown(PointerEventData eventData)
    {
        started = true;
        moved = false;
        startPosition = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!moved) return;

        eventData.pointerPress = null;
        moved = started = false;
        startPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!started) return;
        eventData.eligibleForClick = false;
        Vector3 difference = Input.mousePosition - startPosition;

        if (Mathf.Abs(difference.x) <= 0 && Mathf.Abs(difference.y) <= 0) return;

        moved = true;
        DirectionAction(difference);
    }

    void DirectionAction(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0 && OnDragRight.GetPersistentEventCount() > 0)
                {
                    started = false;
                    OnDragRight?.Invoke();
                }
                else if (OnDragLeft.GetPersistentEventCount() > 0)
                {
                    started = false;
                    OnDragLeft?.Invoke();
                }
            }
            else
            {
                if (direction.y > 0 && OnDragUp.GetPersistentEventCount() > 0)
                {
                    started = false;
                    OnDragUp?.Invoke();
                }
                else if (OnDragDown.GetPersistentEventCount() > 0)
                {
                    started = false;
                    OnDragDown?.Invoke();
                }
            }
        }
    }
}
