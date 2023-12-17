using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kwalee.SimpleShootyTest
{
    /// <summary>
    /// Interface for enemy Takedamage
    /// </summary>
    public interface IDamagable
    {
        public void TakeDamage(int damage);
    }
}