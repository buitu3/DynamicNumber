using System;
using System.Collections;
using System.Collections.Generic;
using DynamicNumber.GamePlay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DynamicNumber
{
    [CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CreateCardData", order = 1)]
    public class CardDataSO : ScriptableObject
    {
        [Title("Value Card")]
        public float ValueCardRate;
        public List<ValueCardData> ValueCardLst;
        public GameObject ValueCardPrefab;
        
        [Title("Special Card")]
        public List<SpecialCardData> SpecialCardLst;
    }

    [System.Serializable]
    public class CardData
    {
    }
    
    [System.Serializable]
    public class ValueCardData : CardData
    {
        public ValueCardType Type;
        public int ValueAmount;
        public Color TextColor;
    }

    [System.Serializable]
    public class SpecialCardData : CardData
    {
        public string CardName;
        public string CardDescription;
        public GameObject CardPrefab;
    }
}

