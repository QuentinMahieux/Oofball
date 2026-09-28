using Unity.Netcode;
using UnityEngine;

public class RotateTerrain : NetworkBehaviour
{
    public Camera camera;
    public override void OnNetworkSpawn()
    {
        ulong ownerid = OwnerClientId;

        if (NetworkManager.Singleton.LocalClientId == 0)
        {
            //Le terrain reste normal
        }
        else
        {
            camera.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

    
}
