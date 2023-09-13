﻿using SplatTheRat.Model.Data;
using SplatTheRat.ScriptableObjects.Utils;
using UnityEngine;

namespace SplatTheRat.ScriptableObjects.Definitions
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "SO/Definitions/Enemy")]
    public class EnemyDefinition : ScriptableObject
    {
        [SerializeField] private GameObject _model;
        [SerializeField] private FloatReference _lifeTime;
        [SerializeField] private IntReference _maxHealth;
        [SerializeField] private MultiplicityInt _health;

        public FloatReference LifeTime => _lifeTime;
        public GameObject Model => _model;
        
        
        public void InitHealth(int id) => _health.RegisterEntity(id, _maxHealth.Value);

        public bool TryGetHealth(int id, out IntProperty value) => _health.TryGetEntity(id, out value);

        public void DeinitHealth(int id) => _health.UnregisterEntity(id);
    }
}