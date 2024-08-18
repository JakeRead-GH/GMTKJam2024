using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clickable : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent<GameObject> MouseClick;

    public Slider slider;

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
