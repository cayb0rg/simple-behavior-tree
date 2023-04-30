using System.Collections.Generic;
using System.Collections;

namespace BehaviorTree
{
    // Composite nodes are just nodes that can have more than one child
    // Like the sequencer and selector nodes
    public class Composite : Node
    {
        protected List<Node> children = new List<Node>();
        // Calls the base constructor
        public Composite() : base() {}       
        public Composite(List<Node> children)
        {
            foreach(Node child in children)
            {
                _Attach(child);
            }
        }

        // Creates an edge between each child node and the parent node
        private void _Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }
    }
}
