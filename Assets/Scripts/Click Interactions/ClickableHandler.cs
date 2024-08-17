using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ClickableHandler : MonoBehaviour
{
    public Clickable[] Clickables;

    public UnityEvent<GameObject> MouseClick;

    private void Awake()
    {
        MouseClick ??= new();
    }
    protected virtual void OnEnable()
    {
        Clickables = FindObjectsOfType<Clickable>(includeInactive: true);

        LinkEvents();
    }

    protected virtual void LinkEvents()
    {
        foreach (Clickable component in Clickables)
        {
            if (!component)
            {
                Debug.Log($"Found an object that has been destroyed");
                continue;
            }

            component.MouseClick.AddListener(HandleMouseClick);
        }
    }

    public virtual void HandleMouseClick(GameObject obj) => MouseClick?.Invoke(obj);
}
