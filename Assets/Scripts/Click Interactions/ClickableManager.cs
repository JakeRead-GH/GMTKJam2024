using UnityEngine;

public class ClickableManager : MonoBehaviour
{
    public void MouseClickOnClickable(GameObject obj)
    {
        Debug.Log("The " + obj.name + " has been clicked on! Time to show the slider");
    }
}
