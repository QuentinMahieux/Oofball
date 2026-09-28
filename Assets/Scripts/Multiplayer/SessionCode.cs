using TMPro;
using Unity.Services.Multiplayer;
using UnityEngine;

public class SessionCode : MonoBehaviour
{
    public TMP_Text sessionCode;

    void Start()
    {
        foreach (var session in MultiplayerService.Instance.Sessions.Values)
        {
            sessionCode.text  = session.Code;
            break;
        }
    }
}
