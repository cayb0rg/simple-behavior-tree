using System.Collections.Generic;
using System.Collections;

namespace BehaviorTree
{
    // This node inverts the value of its child
    // If the child is successful, this node fails, and vice versa
    public class Inverter : Decorator
    {
        // Calls the base constructors
        public Inverter() : base() {}
        public Inverter(Node child) : base(child) {}

        // Returns NodeState.SUCCESS if child failed
        // Returns NodeState.RUNNING if child is running
        // Returns NodeState.FAILURE if child is successful
        public override NodeState Evaluate()
        {
            switch (child.Evaluate())
            {
                case NodeState.SUCCESS:
                    return NodeState.FAILURE;
                case NodeState.FAILURE:
                    return NodeState.SUCCESS;
                case NodeState.RUNNING:
                    return NodeState.RUNNING;
                default:
                    return NodeState.SUCCESS;
            }
        }
    }
}
