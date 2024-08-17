using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent<GameObject> MouseClick;

    private void Awake()
    {
        MouseClick ??= new();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (!enabled) { return; }
        MouseClick?.Invoke(gameObject);
    }
}
