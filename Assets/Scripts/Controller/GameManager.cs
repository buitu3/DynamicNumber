using System;
using System.Collections;
using System.Collections.Generic;
using Ftech.Utilities;
using TMPro;
using UnityEngine;

namespace DynamicNumber.GamePlay
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        private CardBoard Board;
        [SerializeField]
        private CardQueue Queue;

        [SerializeField] private TextMeshProUGUI PlayerBetText;

        public int PlayerCurrentValue;
        public int PlayerFirstBet { get; private set; }

        private void Start()
        {
            PlayerFirstBet = 100000;
            PlayerCurrentValue = PlayerFirstBet;
            PlayerBetText.text = PlayerCurrentValue.ToString();
            
            EventDispatcher.RegisterListener(EventID.ON_PLAYER_POINT_CHANGE, OnPlayerPointChangeHandler);
        }

        private void OnPlayerPointChangeHandler(Dictionary<string, object> param)
        {
            var data = param[EventID.EVENT_DATA_KEY];
            var point = (int) data;
            PlayerCurrentValue = point;
            PlayerBetText.text = PlayerCurrentValue.ToString();
        }
    }
}

