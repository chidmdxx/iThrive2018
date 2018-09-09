using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IThriveBehaviorTree
{
    [CreateAssetMenu(fileName = "Catalog", menuName = "Assets/IThriveBehaviorTree/Catalog")]
    public class Catalog : ScriptableObject
    {
        public string[] catalog;
    }
}

