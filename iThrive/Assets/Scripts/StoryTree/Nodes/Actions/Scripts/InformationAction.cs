using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IThriveBehaviorTree
{
    [CreateAssetMenu(fileName = "InformationAction", menuName = "Assets/IThriveBehaviorTree/Actions/Information")]
    public class InformationAction : Action
    {
        public override NodeStatus PerformAction(BehaviorAgent agent)
        {
            //passes dialogue object to dialogue component of agent
            Debug.Log("Info Passed");
            return NodeStatus.FAILURE;
        }

        public override void InitializeAction()
        {
            EditableActionProperties = new List<UnityEditor.SerializedProperty>();

            

        }

    }
}

