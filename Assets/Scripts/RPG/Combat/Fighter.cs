using JetBrains.Annotations;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter
    {
        public void Attack([CanBeNull] CombatTarget target)
        {
            if (target)
            {
                Debug.Log($"{nameof(Fighter)} attacked {target.name}!");
            }
        }
    }
}