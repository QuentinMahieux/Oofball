using System;
using TMPro;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Multiplayer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{
    public TMP_InputField enterCode;

    [Header(("Editor Mode"))] 
    public bool isSecondPlayer;
    private ISession currentSession;
    
    async void Start()
    {
        DontDestroyOnLoad(gameObject);
        await UnityServices.InitializeAsync();
        
        var options = new InitializationOptions();
        
        if (isSecondPlayer)
        {
            options.SetProfile("Joueur_Test_2");
        }

        //Crée un profil de session
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
        Debug.Log("Connect: " + AuthenticationService.Instance.PlayerId);
    }

    public async void CreateSession()
    {
        var options = new SessionOptions
        {
            MaxPlayers = 2,
        }.WithRelayNetwork();
        
        currentSession = await MultiplayerService.Instance.CreateSessionAsync(options);
        
        Debug.Log("Session created: " + currentSession.Code);
        
        NetworkManager.Singleton.SceneManager.LoadScene("MainGame",LoadSceneMode.Single);
        
        
    }

    public async void JoinSession()
    {
        string code = enterCode.text.Trim().ToUpper();
        currentSession = await MultiplayerService.Instance.JoinSessionByCodeAsync(code);
        
    }

    public async void LeaveSession()
    {
        await currentSession.LeaveAsync();
    }
}
