using System;
using UnityEngine;

public class TowerWeapon : MonoBehaviour
{
        private Transform _transform;
        public float radius;
        public float damage;
        public ParticleSystem ParticleSystem;
        public ParticleSystem hitEffectParticle;
        public LayerMask layerMask;

        private void Awake()
        {
                _transform = transform;
        }

        private void FixedUpdate()
        {
                Collider[] colliders = Physics.OverlapSphere(_transform.position, radius, layerMask);
                
                if(colliders.Length > 0)
                {
                        IDamagable damagable = colliders[0].GetComponent<IDamagable>();
                        Attack(damagable);
                        ParticleSystem.Play();
                        ParticleSystem.transform.forward = (colliders[0].transform.position - ParticleSystem.transform.position).normalized;
                        hitEffectParticle.Play();
                        hitEffectParticle.transform.position = colliders[0].transform.position;
                }
                else
                {
                        hitEffectParticle.Stop();
                        ParticleSystem.Stop();
                }

        }


        private void Attack(IDamagable damagable)
        {
                damagable.TakeDamage(damage);
        }
}