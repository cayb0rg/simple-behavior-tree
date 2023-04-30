using System.Collections.Generic;
using System.Collections;

namespace BehaviorTree
{
    // This node will succeed if at least one of its children succeeds
    public class Selector : Composite
    {
        // Calls the base constructors
        public Selector() : base() {}

        public Selector(List<Node> children) : base(children) {}

        // Returns NodeState.SUCCESS if at least one child is successful
        // Returns NodeState.RUNNING if at least one child is running
        // Returns NodeState.FAILURE if at least one child failed
        public override NodeState Evaluate()
        {

            foreach(Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        state = NodeState.FAILURE;
                        return state;
                }
            }
            
            // None of the children were successful or running
            state = NodeState.FAILURE;

            return state;
        }
    }
}
