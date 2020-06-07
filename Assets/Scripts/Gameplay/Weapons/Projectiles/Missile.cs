using System;
using Gameplay.Helpers;
using UnityEngine;

namespace Gameplay.Weapons.Projectiles
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Missile : Projectile
    {
        private SpriteRenderer _spriteRenderer = new SpriteRenderer();

        public void SetML(MissileSO missile)
        {
            _speed = missile.Speed;
            _damage = missile.Damage;
            //_spriteRenderer.sprite = missile.Icon;
        }

        protected override void Move(float speed)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.up);
        }
    }
}
