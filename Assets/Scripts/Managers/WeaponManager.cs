using System;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Net;
using EnemyHelper;

public class WeaponManager : MonoBehaviour
{
    public string urlToRefresh;
    WebSocket ws;

    public EnemyType currentEnemyType;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnableEnemyTypeUpdate()
    {

        ws = new WebSocket (urlToRefresh);
        ws.OnOpen += (sender, e) => Debug.Log("Listening to WebSocket " + urlToRefresh);
        ws.OnMessage += (sender, e) => Debug.Log("Received " + e.Data + " " + e.Data.GetType());
        ws.OnError += (sender, e) => Debug.Log("WebSocket Error: " + e.Message);
        ws.OnClose += (sender, e) => Debug.Log("WebSocket Close " + e.Code);
        ws.OnMessage += (sender, e) => 
        {
            try
            {
                currentEnemyType = (EnemyType) Enum.Parse(typeof(EnemyType), e.Data);
            }
            catch (Exception exc)
            {
                Debug.Log(exc);
            }
        };

        ws.Connect();
        Debug.Log(ws.ReadyState);
    }

    void DisableEnemyTypeUpdate()
    {
        if (ws != null && ws.ReadyState == WebSocketState.Open)
        {
            ws.Close();
        }
    }

    void OnEnable()
    {
        EnableEnemyTypeUpdate();
    }

    void OnDisable()
    {
        DisableEnemyTypeUpdate();
    }

}
