using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Features.HealthComponent
{
    /// <summary>
    /// Responsável por dar a feature de dano a um componente
    /// Componente Puro
    /// </summary>
    
    internal class Health : IHitable
    {
        [SerializeField] public int CurrentHealth = 3;

        public void Damage(int amount)
        {
            CurrentHealth--;
        }
        public int GetCurrentHealt()
        {
            return CurrentHealth < 0 ? 0 : CurrentHealth;
        }
    }
}
