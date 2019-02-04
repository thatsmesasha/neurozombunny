//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using WebSocketSharp;
//using WebSocketSharp.Net;

//public class PlayerAttack : MonoBehaviour
//{
//    public Spell[] spells;
//    public GameObject defaultWeapon;
    
//    string _newSpellName = null;
//    string _currentSpellName = null;
//    public string currentSpellName
//    {
//        get
//        {
//            return _currentSpellName;
//        }
//        set
//        {
//            Debug.Log("Setting " + value + " instead of " + _currentSpellName);
//            if (_currentSpellName != value)
//            {
//                bool anyWeaponBecameActive = false;
//                foreach (Spell spell in spells)
//                {
//                    Debug.Log("Going through " + spell.name);
//                    if (spell.name == value)
//                    {
//                        spell.gameObject.SetActive(true);
//                        anyWeaponBecameActive = true;
//                        Debug.Log("became aactive");
//                    }
//                    else if (spell.name == _currentSpellName || spell.gameObject.activeSelf)
//                    {
//                        spell.gameObject.SetActive(false);
//                    }
//                }
//                _currentSpellName = value;

//                Debug.Log(anyWeaponBecameActive);
//                Debug.Log(anyWeaponActive);

//                if (anyWeaponBecameActive && !anyWeaponActive)
//                {
//                    Debug.Log("set active");
//                    defaultWeapon.SetActive(false);
//                }
//                else if (anyWeaponActive && !anyWeaponBecameActive)
//                {
//                    defaultWeapon.SetActive(true);
//                }
//                anyWeaponActive = anyWeaponBecameActive;
//            }
//        }
//    }

//    bool anyWeaponActive;


//    WebSocket ws;
//    public float timeBetweenRefresh;
//    public string urlToRefresh;

//    // Start is called before the first frame update
//    void Start()
//    {
//        // currentSpellName = "Antoher";
//        // updateWeapon = true;
//    }

//    void Update ()
//    {
//        if (_newSpellName != _currentSpellName)
//        {
//            currentSpellName = _newSpellName;
//        }
//    }

//    void EnableWeaponUpdate()
//    {

//        ws = new WebSocket (urlToRefresh);
//        ws.OnOpen += (sender, e) => Debug.Log("Listening to WebSocket " + urlToRefresh);
//        ws.OnMessage += (sender, e) => Debug.Log("Received " + e.Data + " " + e.Data.GetType());
//        ws.OnError += (sender, e) => Debug.Log("WebSocket Error: " + e.Message);
//        ws.OnClose += (sender, e) => Debug.Log("WebSocket Close " + e.Code);
//        ws.OnMessage += (sender, e) => 
//        {
//            try
//            {
//                _newSpellName = e.Data;
//            }
//            catch (Exception exc)
//            {
//                Debug.Log(exc);
//            }
//        };

//        ws.Connect();
//        Debug.Log(ws.ReadyState);
//    }

//    void DisableWeaponUpdate()
//    {
//        if (ws != null && ws.ReadyState == WebSocketState.Open)
//        {
//            ws.Close();
//        }
//    }

//    void OnEnable()
//    {
//        EnableWeaponUpdate();
//    }

//    void OnDisable()
//    {
//        DisableWeaponUpdate();
//    }

//}
