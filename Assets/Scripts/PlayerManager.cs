using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerManager : MonoBehaviour
    {
        public event Action TargetCatched;
        public Circle Player => _player;
        public static PlayerManager instance;

        [SerializeField] private Circle _player;

        public void CatchTarget()
        {
            if (TargetCatched != null) TargetCatched();
        }
        
        void Awake()
        {
            instance = this;
        }
    }
}