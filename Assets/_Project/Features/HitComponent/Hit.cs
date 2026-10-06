using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Entities;
using Assets.Scripts.Marble;
using UnityEngine;

namespace Assets._Project.Features.GenericColide
{
    [RequireComponent(typeof(Marble))]
    /*
     Define o comportamento de Hit para causar dano em todo componente que implementa IHitable
     */
    internal class Hit : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<IHitable>(out var hitable))
            {
                Debug.Log($"Colision happends {collision.rigidbody.name}");
                hitable.Damage(1);
            }
        }
    }
}
