using System;
using Unity.Netcode;
using UnityEngine;

public class Card : NetworkBehaviour
{
    private bool hovered = false;
    private bool selected = false;
    public bool spawnebale = false;
    private Vector2 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
    }

    private void OnMouseEnter()
    {
        hovered = true;
    }

    private void OnMouseExit()
    {
        if(selected) return;
        hovered = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        UnitySpawnZone spawnZone = other.gameObject.GetComponent<UnitySpawnZone>();
        if (spawnZone == null) return;
        if(spawnZone.IsTheOwner(NetworkManager.Singleton.LocalClientId))
        
        spawnebale =  true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        UnitySpawnZone spawnZone = other.gameObject.GetComponent<UnitySpawnZone>();
        if (spawnZone == null) return;
        if(spawnZone.IsTheOwner(NetworkManager.Singleton.LocalClientId))
        
        spawnebale = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) &&  hovered)
        {
            selected = true;
            
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousepos;
        }

        if (Input.GetMouseButtonUp(0) && selected)
        {
            selected = false;
            transform.position = originalPosition;
            
            //Si l'entité est spawnable
            if (spawnebale)
            {
                Destroy(gameObject);
            }
        }
    }
}
