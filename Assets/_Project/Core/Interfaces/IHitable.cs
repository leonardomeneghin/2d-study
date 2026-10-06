using UnityEngine;

public interface IHitable //Define se a classe é atingível pelo sistema de mineração por colisão
{
    public void Damage(int amount);
    public int GetCurrentHealt();
}
