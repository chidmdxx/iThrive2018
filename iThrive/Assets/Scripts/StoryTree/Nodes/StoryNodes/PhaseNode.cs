using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a special selector node that iterates through each child 
//and ticks the child equal to agent's current PHASE ID
//On SUCCESS, the agent's PHASE ID will be incremented by 1
//On FAILURE or RUNNING, nothing happens

namespace IThriveBehaviorTree
{
    [CreateAssetMenu(fileName = "PhaseNode", menuName = "Assets/IThriveBehaviorTree/Nodes/PhaseNode")]
    public class PhaseNode : CompositeNode
    {

        public PhaseNode()
        {
            ChildNodes = new List<TreeNode>();
        }

        public override NodeStatus Tick(BehaviorAgent agent)
        {
            /*if (thisDecorator != null)
                if (TickDecorator(agent) == NodeStatus.SUCCESS) return thisNodeStatus = CheckChildNodeStatus(agent);
                else return thisNodeStatus = NodeStatus.FAILURE;
            else return thisNodeStatus = CheckChildNodeStatus(agent);*/
            return thisNodeStatus = CheckChildNodeStatus(agent);
        }

        NodeStatus CheckChildNodeStatus(BehaviorAgent agent)
        {
            if (ChildNodes.Count > 0)
            {
                for(int n = 0; n < ChildNodes.Count; n++)
                {
                    if (n == agent.PHASE)//.StoryTreePhases[thisBehaviorTree])
                    {
                        NodeStatus childNodeStatus = ChildNodes[n].Tick(agent);

                        if (childNodeStatus == NodeStatus.SUCCESS)
                        {
                            return NodeStatus.SUCCESS;
                        }
                        else return childNodeStatus;
                    }
                }
            }
            return NodeStatus.FAILURE;
        }
    }
}
