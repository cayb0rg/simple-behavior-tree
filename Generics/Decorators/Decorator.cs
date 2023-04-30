using System.Collections.Generic;
using System.Collections;

namespace BehaviorTree
{
    // Decorator nodes are nodes that can only have a single child (such as an inverter)
    // Like the sequencer and selector nodes
    public class Decorator : Node
    {
        protected Node child;
        // Calls the base constructor
        public Decorator() : base() {}       
        public Decorator(Node child)
        {
            _Attach(child);
        }

        // Creates an edge between the child node and the parent node
        private void _Attach(Node node)
        {
            node.parent = this;
            child = node;
        }
    }
}
