using System.Collections.Generic;
using System.Collections;

namespace BehaviorTree
{
    // Reevaluates its child node until it returns SUCCESS
    public class RepeatUntilSuccess : Decorator
    {
        // Calls the base constructor
        public RepeatUntilSuccess() : base() {}

        public override NodeState Evaluate()
        {
            while (child.Evaluate() != NodeState.SUCCESS)
            {
                state = NodeState.RUNNING;
                return state;
            }
            // Returns success once the child has succeeded
            state = NodeState.SUCCESS;
            return state;
        }
    }
}
