using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicNumber.GamePlay
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField]
        private CardBoard Board;
        [SerializeField]
        private CardQueue Queue;
    }
}

