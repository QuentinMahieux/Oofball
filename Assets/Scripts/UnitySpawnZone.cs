using Unity.Netcode;
using UnityEngine;

public class UnitySpawnZone : OwnerBehaviour
{
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        if (!IsTheOwner(NetworkManager.Singleton.LocalClientId)) spriteRenderer.enabled = false;
    }

    
}
