using System.Collections.Generic;
using UnityEngine;

namespace IThriveBehaviorTree
{
    [CreateAssetMenu(fileName = "BehaviorTree", menuName = "Assets/IThriveBehaviorTree/BehaviorTree")]
    public class BehaviorTree : ScriptableObject
    {

        public List<TreeNode> TreeNodeList;

        public void Initialize()
        {
            TreeNodeList = new List<TreeNode>();
        }

        public bool AddChildNode(int parentID, int childID)
        {
            TreeNodeList[childID].thisBehaviorTree = this;
            return TreeNodeList[parentID].AddChildNode(TreeNodeList[childID]);
        }

        public NodeStatus TickBehaviorTree(BehaviorAgent agent)
        {
            return TreeNodeList[0].Tick(agent);
        }
    }
}

