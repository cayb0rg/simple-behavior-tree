using System.Collections.Generic;
using System.Collections;

// Declaring BehaviorTree as its own namespace will make this reusable by any entity
namespace BehaviorTree
{
    public abstract class Tree : MonoBehaviour
    {
        private Node _root = null;

        protected void Start()
        {
            if (_root == null)
                _root = SetupTree();
        }
        protected virtual void OnEnable()
        {
            if (_root == null)
                _root = SetupTree();
        }
        protected virtual void OnDisable()
        {
            _root = TakedownTree();
        }

        // Evaluate the tree continuously
        protected virtual void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        // To be implemented by each tree instance
        protected abstract Node SetupTree();
        protected virtual Node TakedownTree()
        {
            _root = null;
            return _root;
        }
        public virtual Tree RunTreeMachine()
        {
            return this;
        }
    }
}
