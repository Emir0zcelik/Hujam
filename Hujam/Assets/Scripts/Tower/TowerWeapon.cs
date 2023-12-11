using System;
using UnityEngine;

public class TowerWeapon : MonoBehaviour
{
        public LayerMask layerMask;
        private Transform _transform;
        public float radius;
        public float damage;
        public ParticleSystem ParticleSystem;

        private Vector3 lastPosition;

        private void Awake()
        {
                _transform = transform;
        }

        private void FixedUpdate()
        {
                Collider[] colliders = Physics.OverlapSphere(_transform.position, radius, layerMask);

                if (colliders.Length > 0)
                { 
                        IDamagable damagable = colliders[0].GetComponent<IDamagable>(); 
                        Attack(damagable);
                        ParticleSystem.Play();
                        ParticleSystem.transform.forward = (colliders[0].transform.position - ParticleSystem.transform.position).normalized;

                        lastPosition = colliders[0].transform.position;
                }
                else
                {
                        ParticleSystem.Stop();
                }
                
        }

        private void OnDrawGizmos()
        {
                Gizmos.DrawSphere(lastPosition,1);
        }

        private void Attack(IDamagable damagable)
        {
                damagable.TakeDamage(damage);
        }
}