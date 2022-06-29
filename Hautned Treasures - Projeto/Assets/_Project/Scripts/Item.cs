using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Transform _transformHand;
    [SerializeField] private TMP_Text _textInfo;
    [SerializeField] private string _text;
    
    [SerializeField] private KeyCode _takeItem = KeyCode.F;
    private PlayerInfos _playerInfos;
    private bool _isEnter;

    public void Update()
    {
        // if (_isEnter && Input.GetKeyDown(_takeItem)&& !_playerInfos._itemInHand)
        // {
        //     _textInfo.text = "";
        //     transform.position = _transformHand.position;
        //     transform.parent = _transformHand.parent;
        //     _playerInfos._itemInHand = true;
        //     gameObject.GetComponent<SphereCollider>().enabled = false;
        // }
    }

    public void SetInfos(PlayerInfos player)
    {
        _transformHand = player._transformHand;
        _textInfo =  player._textInfo;
        _playerInfos = player;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _textInfo.text = _text;
            _isEnter = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            _textInfo.text = "";
            _isEnter = false;
        }
    }
}
