using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemWorld : MonoBehaviour, IPointerClickHandler
{
    #region Región Static
    /// <summary>
    /// Función que permite instanciar un prefab de un item dentro del mundo.
    /// </summary>
    /// <param name="position">Posición en donde se quiere instanciar</param>
    /// <param name="item">Item que se va a instanciar</param>
    /// <returns>Retorna el item instanciado.</returns>
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        GameObject transform = Instantiate(item.Prefab, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }

    /// <summary>
    /// Función que permite dropear un item.
    /// Y llama a la función de spawneo de item en el mundo.
    /// </summary>
    /// <param name="dropPosition">Posición en donde se va a dropear el item</param>
    /// <param name="item">Item a dropear</param>
    /// <returns></returns>
    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        ItemWorld itemWorld = SpawnItemWorld(dropPosition, item);
        return itemWorld;
    }
    #endregion

    private Player player;
    private Item item;
    private SpriteRenderer spriteRenderer; //Render del item del mundo.

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    /// <summary>
    /// Función que setea un item a lo que contenga este script y le agrega al sprite renderer el sprite que le llega del item.
    /// </summary>
    /// <param name="item">Item que llega</param>
    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.Sprite;
    }

    /// <summary>
    /// Método por el cúal se obtiene el item guardado en la variable ITEM.
    /// </summary>
    /// <returns> Item almacenado en la variable</returns>
    public Item GetItem()
    {
        return item;
    }

    /// <summary>
    /// Método por el cual se destruye este objeto.
    /// </summary>
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    
    /// <summary>
    /// Función que se ejecuta al hacer click en un sprite que se encuentra en el mundo.
    /// Y llama a la función añadir items al inventario del jugador.
    /// Y luego llama a la función de destruirse a si mismo.
    /// </summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        player.inventory.AddItems(GetItem());
        DestroySelf();
    }
}
