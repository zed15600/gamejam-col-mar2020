using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragDropItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField]
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Player player;
    public NoiseBar noiseBar;

    private void Awake() 
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true; 

        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }



    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(eventData.position);
        if(eventData.position.y < 150){
            Debug.Log(eventData.pointerDrag);
            foreach (Item obj in ItemDatabase.Instance.itemDatabase)
            {
                if(obj.Sprite == gameObject.transform.GetChild(1).GetComponentInChildren<Image>().sprite)
                {
                    player.inventory.RemoveItem(obj);
                    player.inventory.AddItems(obj);
                    break;
                }
            } 
        }
        else
        {
            foreach (Item obj in ItemDatabase.Instance.itemDatabase)
            {
                if(obj.Sprite == gameObject.transform.GetChild(1).GetComponentInChildren<Image>().sprite)
                {
                    Vector3 p = Input.mousePosition;
                    p.z = 10;
                    Vector3 pos = Camera.main.ScreenToWorldPoint(p);
                    player.inventory.RemoveItem(obj);
                    if(pos.y < 0){
                        pos.y = 0;
                    }
                    ItemWorld.DropItem(pos, obj, noiseBar);
                    break;
                }
            } 
        }  
    }
}
