using UnityEngine;
using System.Collections;
using EnemyHelper;

interface IWeapon
{
    bool IsAvailable();
    EnemyType GetShootableEnemyType();
}
