using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Core.Entities
{
    /* Define dados de minerais do jogo */
    [CreateAssetMenu(menuName = "Items/MineralDTO")]
    public class MineralDTO : ScriptableObject
    {
        public string Name;
    }
}
