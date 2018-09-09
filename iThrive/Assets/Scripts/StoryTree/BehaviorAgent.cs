using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IThriveBehaviorTree
{
    public class BehaviorAgent : MonoBehaviour
    {

        public BehaviorTree BehaviorTreeRef;
        public Dictionary<BehaviorTree, int> StoryTreePhases;
        public int PHASE;
        public int CurrentChoiceID;

        public void TickBehaviorTree()
        {
            BehaviorTreeRef.TickBehaviorTree(this);
        }

    }
}

