using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets._Project.Core.Entities
{
    /* Define o objeto dentro do jogo */
    public class MineralTile: MonoBehaviour, IHitable 
    {
        [SerializeField] MineralDTO mineral;
        public MineralDTO Mineral => mineral;

        public void Damage(int amount)
        {
            Destroy(gameObject);
            if(TryGetComponent<Tilemap>(out var tile))
            {
                
            }
        }

        public int GetCurrentHealt()
        {
            throw new NotImplementedException();
        }
    }
}
