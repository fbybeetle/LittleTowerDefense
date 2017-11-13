﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Code
{
    public class Spawning : MonoBehaviour
    {
        private const float WaveCd = 20f;
        private const float SpawnTime = 0.8f;
        private const int MaxMonsterCount = 10;
        private static Object _EnemyPrefab;
        private float _lastspawn;
        private Transform _holder;
        private float spawn_time;
        public static int wave;
        public static int monsternumber;
        internal void Start()
        {
            this.transform.position = new Vector3(0f, 1f, 4f);
            _EnemyPrefab = Resources.Load("Enemy");
            _holder = this.transform;
            _lastspawn = 0f;
            spawn_time = 0f;
            wave = 1;
            monsternumber = 0;
            //Asteroid.Manager = this;
        }
        internal void FixedUpdate()
        {
            if (wave == 1 && monsternumber <= MaxMonsterCount)
            {
                if ((Time.time - _lastspawn) < SpawnTime) return;
                _lastspawn = Time.time;
                Spawn();
                GameImfomation.Updateinfo();
                monsternumber++;
                if (monsternumber == 10)
                {
                    nextwave();
                }
            }

            else if (wave>1 &&(Time.time - spawn_time) >= WaveCd && monsternumber <= MaxMonsterCount)
            {
                if ((Time.time - _lastspawn) < SpawnTime) return;
                _lastspawn = Time.time;
                Spawn();
                GameImfomation.Updateinfo();
                monsternumber++;
                if (monsternumber == 10)
                {
                    nextwave();

                 }
            }
            GameImfomation.Updateinfo();
        }
        void nextwave()
        {
            wave++;
            spawn_time = Time.time;
            monsternumber = 0;
        }
        private void Spawn()
        {   
            //if (_holder.childCount >= MaxAsteroidCount) { return; }
            float time = Time.time;
            var tra = this.transform;
            var pos = tra.position;
            //if (time < _lastspawn + SpawnTime) { return; }

            ForceSpawn(pos);
        }

        public void ForceSpawn(Vector2 pos)
        {
            Quaternion rotation = Quaternion.Euler(0,0,0);
            var ast = (GameObject)Object.Instantiate(_EnemyPrefab, pos, rotation, _holder);
            var s = ast.GetComponentInChildren<Enemy>();
            s.Initialize();
        }
        // Use this for initialization

        // Update is called once per frame
    }
}