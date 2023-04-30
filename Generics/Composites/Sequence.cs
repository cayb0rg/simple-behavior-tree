using System.Collections.Generic;
using System.Collections;

namespace BehaviorTree
{
    // This node will succeed only if all of its child nodes succeed
    public class Sequence : Composite
    {
        // Calls the base constructors
        public Sequence() : base() {}

        public Sequence(List<Node> children) : base(children) {}

        // Returns NodeState.SUCCESS if all children are successful
        // Returns NodeState.RUNNING if at least one child is running
        // Returns NodeState.FAILURE if at least one child failed
        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach(Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }

            state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;

            return state;
        }
    }
}
