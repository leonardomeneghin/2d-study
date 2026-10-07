using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets._Project.Features.GenericColide
{
    /*
     Define o comportamento de Hit para causar dano em todo componente que implementa IHitable
     */
    internal class CauseHit : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Debug.Log("on collision entered");

            var pos = collision.otherCollider.gameObject.transform.position;
            //Debug.Log($"pos is {pos}");
            if (collision.gameObject.TryGetComponent<IHitable>(out var hitable)
                && collision.gameObject.TryGetComponent<Tilemap>(out var tm))
            {
                foreach (var contact in collision.contacts)
                {
                    var cellPos = tm.WorldToCell(contact.point - contact.normal * 0.01f); //Usar a normal para empurrar o ponto do contato um pouco para dentro do tile

                    Debug.Log($"cellPos: {cellPos}");
                    tm.SetTile(cellPos, null);
                }
                
            }
        }
    }
}
