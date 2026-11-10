using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ItemPopup : MonoBehaviour
{
    InputAction click;

    private void Start()
    {
        click = InputSystem.actions.FindAction("LeftClick");
    }

    private void Update()
    {
        if (!gameObject.activeSelf)
            return;

        bool clicked = click.ReadValue<float>()>0;

        if (clicked)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Mouse.current.position.ReadValue();

            var results = new System.Collections.Generic.List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            bool clickedPopup = false;

            foreach (var result in results)
            {
                if (result.gameObject.transform.IsChildOf(gameObject.transform))
                {
                    clickedPopup = true;
                    break;
                }
            }

            if (!clickedPopup)
                gameObject.SetActive(false);
        }
    }

}
