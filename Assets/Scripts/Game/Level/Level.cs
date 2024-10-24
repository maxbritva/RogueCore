using System;
using System.Collections.Generic;
using Game.Enemy;
using Interfaces;
using UnityEngine;

namespace Game.Level
{
    [Serializable]
    public class Level: IActivatable
    {
            [SerializeField] private List<EnemySpawner> _enemySpawners = new List<EnemySpawner>();
            
            public void Activate()
            {
                for (int i = 0; i < _enemySpawners.Count; i++) 
                    _enemySpawners[i].Activate();
            }

            public void Deactivate()
            {
                for (int i = 0; i < _enemySpawners.Count; i++) 
                    _enemySpawners[i].Deactivate();
            }
    }
}