using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modifies state then returns success

namespace IThriveBehaviorTree
{
    [CreateAssetMenu(fileName = "ResponseAction", menuName = "Assets/IThriveBehaviorTree/Actions/Response")]
    public class ResponseAction : Action
    {
        public override NodeStatus PerformAction(BehaviorAgent agent)
        {
            //passes dialogue object to dialogue component of agent
            Debug.Log("Response Processed. State Changed.");
            return NodeStatus.SUCCESS;
        }

        public override void InitializeAction()
        {
            EditableActionProperties = new List<UnityEditor.SerializedProperty>();
        }

    }
}
