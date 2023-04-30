using System.Collections.Generic;
using System.Collections;

namespace BehaviorTree
{
    // Each node can only have one of three states: running, success, or failure
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }

    public class Node
    {
        protected NodeState state;
        // Holding references to the parent enables backtracking
        public Node parent;
        // _dataContext stores the shared data between nodes
        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

        public Node()
        {
            parent = null;
        }

        // Evaluate is virtual so it can be overridden by derived classes
        public virtual NodeState Evaluate() => NodeState.FAILURE;

        // Just a setter method for the _dataContext dictionary
        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        // Getter method for _dataContext dictionary
        public object GetData(string key)
        {
            object value = null;
            // Look for the key within this node's context
            if (_dataContext.TryGetValue(key, out value))
                return value;

            // If not here, check each parent's context until we find the key or we reach the root of the tree
            Node node = parent;
            while (node != null)
            {
                value = node.GetData(key);
                if (value != null)
                {
                    return value;
                }

                node = node.parent;
            }

            return null;
        }

        // Delete method for _dataContext dictionary
        // Returns true if the data was found and removed, false otherwise
        public bool RemoveData(string key)
        {
            object value = null;
            // Look for the key within this node's context
            if (_dataContext.TryGetValue(key, out value))
            {
                _dataContext.Remove(key);
                return true;
            }

            // If not here, check each parent's context until we find the key or we reach the root of the tree
            Node node = parent;
            while (node != null)
            {
                bool removed = node.RemoveData(key);
                if (removed)
                {
                    return true;
                }

                node = node.parent;
            }

            return false;
        }
    }
}