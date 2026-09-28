using Unity.Netcode;
using UnityEngine;

public class OwnerBehaviour : NetworkBehaviour
{
    public OwnerType ownerType;
    
    //Verifit si c'est bien le bon joueur
    public bool IsTheOwner(ulong currentOwnerId)
    {
        Debug.Log(ownerType + " + " + currentOwnerId);
        if(currentOwnerId == 0 && ownerType == OwnerType.Player1) return true;
        if(currentOwnerId == 1 && ownerType == OwnerType.Player2) return true;
        return false;
    }
}

public enum OwnerType
{
    Player1,
    Player2
}