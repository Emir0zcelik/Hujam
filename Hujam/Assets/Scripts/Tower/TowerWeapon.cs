using System;
using UnityEngine;

public class TowerWeapon : MonoBehaviour
{
        public LayerMask layerMask;
        private Transform _transform;
        public float radius;
        public float damage;

        private void Awake()
        {
                _transform = transform;
        }

        private void Update()
        {
                Collider[] colliders = Physics.OverlapSphere(_transform.position, radius, layerMask);

                if (colliders.Length > 0)
                {
                        IDamagable damagable = colliders[0].GetComponent<IDamagable>(); 
                        Attack(damagable);
                }
                
        }

        private void Attack(IDamagable damagable)
        {
                damagable.TakeDamage(damage);
        }
}