using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform; // To move the piece
    private CanvasGroup canvasGroup; // For managing dragging visibility
    private Vector2 initialPosition; // Store initial position to reset on wrong placement
    private bool isLocked = false; // To lock the piece once it's placed correctly

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initialPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // If the piece is locked, do nothing
        if (isLocked) return;

        // Make the piece semi-transparent while dragging
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false; // Disable raycasts to detect other objects
    }

    public void OnDrag(PointerEventData eventData)
    {
        // If the piece is locked, do nothing
        if (isLocked) return;

        // Move the piece with the drag input
        rectTransform.anchoredPosition += eventData.delta / GetCanvasScaleFactor();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // If the piece is locked, do nothing
        if (isLocked) return;

        // Restore full opacity
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true; // Re-enable raycasts

        // Find the closest slot
        GameObject closestSlot = GetClosestSlot();

        if (closestSlot != null)
        {
            // Get the IDs of the piece and the closest slot
            int slotID = closestSlot.GetComponent<SlotIdentifier>().slotID;
            int pieceID = GetComponent<PieceIdentifier>().pieceID;

            if (slotID == pieceID) // If the piece matches the slot
            {
                // Snap the piece into the slot's position
                rectTransform.anchoredPosition = closestSlot.GetComponent<RectTransform>().anchoredPosition;
                Debug.Log("Correct placement!");

                // Lock the piece
                isLocked = true;

                // Change piece appearance to indicate it's locked (e.g., set opacity or color)
                GetComponent<UnityEngine.UI.Image>().color = new Color(1f, 1f, 1f, 0.4f); // White with 40% opacity

                // Notify the GameCompletion script
                FindObjectOfType<GameCompletion>().CheckCompletion();
            }
            else
            {
                // Reset to initial position if the slot is incorrect
                rectTransform.anchoredPosition = initialPosition;
                Debug.Log("Wrong slot!");
            }
        }
        else
        {
            // Reset to initial position if no valid slot is nearby
            rectTransform.anchoredPosition = initialPosition;
        }
    }

    private GameObject GetClosestSlot()
    {
        float minDistance = Mathf.Infinity;
        GameObject closestSlot = null;

        // Loop through all slots to find the closest one
        foreach (GameObject slot in GameObject.FindGameObjectsWithTag("Slot"))
        {
            float distance = Vector2.Distance(rectTransform.anchoredPosition, slot.GetComponent<RectTransform>().anchoredPosition);
            if (distance < 50f && distance < minDistance) // Adjust snapping distance if needed
            {
                minDistance = distance;
                closestSlot = slot;
            }
        }

        return closestSlot;
    }

    private float GetCanvasScaleFactor()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        return canvas.scaleFactor;
    }

    public bool IsCorrectAndLocked()
    {
        return isLocked; // Returns true if the piece is locked
    }
}