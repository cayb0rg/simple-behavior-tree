using System.Collections.Generic;
using System.Collections;

namespace BehaviorTree
{
    // Reevaluates its child node until it returns FAILURE
    public class RepeatUntilFail : Decorator
    {
        // Calls the base constructor
        public RepeatUntilFail() : base() {}

        public override NodeState Evaluate()
        {
            while (child.Evaluate() != NodeState.FAILURE)
            {
                state = NodeState.RUNNING;
                return state;
            }
            // Returns success once the child has failed
            state = NodeState.SUCCESS;
            return state;
        }
    }
}
