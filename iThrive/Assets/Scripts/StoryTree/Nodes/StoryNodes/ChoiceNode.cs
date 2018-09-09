using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is a composite node that checks CHOICE ID when ticked, return FAILURE if no match
//FAILURE returned by a node means the node does not proceed to next PHASE
//SUCCESS returned by a node means a change in PHASE
//DO NOT return a FAILING RESPONSE node that also changes the STATE, it will lead to an abusive option

namespace IThriveBehaviorTree
{
    [CreateAssetMenu(fileName = "ChoiceNode", menuName = "Assets/IThriveBehaviorTree/Nodes/ChoiceNode")]
    public class ChoiceNode : CompositeNode
    {

        public ChoiceNode()
        {
            ChildNodes = new List<TreeNode>();
        }

        public override NodeStatus Tick(BehaviorAgent agent)
        {
            /*if (thisDecorator != null)
                if (TickDecorator(agent) == NodeStatus.SUCCESS) return thisNodeStatus = CheckChildNodeStatus(agent);
                else return thisNodeStatus = NodeStatus.FAILURE;
            else return thisNodeStatus = CheckChildNodeStatus(agent);*/
            thisNodeStatus = CheckChildNodeStatus(agent);
            if (thisNodeStatus == NodeStatus.SUCCESS) agent.PHASE++;//StoryTreePhases[thisBehaviorTree]++;
            return thisNodeStatus;
            //return NodeStatus.FAILURE;
        }

        NodeStatus CheckChildNodeStatus(BehaviorAgent agent)
        {
            if (ChildNodes.Count > 0)
            {
                for(int i = 0; i < ChildNodes.Count; i++)
                {
                    if(agent.CurrentChoiceID == i)
                    {
                        NodeStatus childNodeStatus = ChildNodes[i].Tick(agent);

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
