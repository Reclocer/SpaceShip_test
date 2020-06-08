using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.Spaceships;

namespace Gameplay.Bonuses
{
    [RequireComponent(typeof(Spaceship))]
    public class BonusSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _objectForSpawn;

        private EnemySpaceShip _spaceship;

        private void Start()
        {
            _spaceship = GetComponent<EnemySpaceShip>();
            _spaceship.ShipDestroyed += SpawnBonus;
        }

        private void SpawnBonus()
        {
            Instantiate(_objectForSpawn, transform.position, transform.rotation);
        }
    }
}
