using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Features.MovementComponent
{
    internal interface IMovementable
    {
        public void StartMovement(Vector2 dir);
        public void StopMovement(Vector2 dir);
        
    }
}
