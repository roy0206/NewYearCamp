using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Serializable]
    
    public class Info
    {
        [Header("플레이어 정보")]
        public float baseHp;
        public float baseSpeed;

        [Header("스피드 아이템")]
        public float boostSpeed;
        public float boostCoolTime;

        [Header("키 커스텀")]
        public KeyCode jumpKey, SlideKey;
    }
    public Info info;
    
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
}
