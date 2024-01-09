using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Serializable]
    
    public class Info
    {
        [Header("플레이어 정보")]
        public int baseHp;
        public float baseSpeed;

        [Header("스피드 아이템")]
        public float boostSpeed;
        public float boostCoolTime;

        [Header("키 커스텀")]
        public KeyCode jumpKey, SlideKey;
    }
    public Info info;
    
    public static GameManager instance;
    public GameObject finishPoint;
    public Text text;
    float distance;
    Vector2 startPoint;
    Player player;

    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        distance = (finishPoint.transform.position.x - player.transform.position.x);
        startPoint = player.transform.position;
    }

    private void Update()
    {
        float percent = (player.transform.position.x - startPoint.x) / distance * 100;
        if(percent >= 100) {
            text.gameObject.SetActive(false);
            player.GetComponent<Controller>().EndGame(true);
        }
        
        text.text = percent.ToString("F0") + "%";
    }
}
