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
        [Header("�÷��̾� ����")]
        public float baseHp;
        public float baseSpeed;

        [Header("���ǵ� ������")]
        public float boostSpeed;
        public float boostCoolTime;

        [Header("Ű Ŀ����")]
        public KeyCode jumpKey, SlideKey;
    }
    public Info info;
    
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
}
