namespace Assignment1
{
    partial class ToolCollection : IToolCollection
    {
        /// <summary>
        /// Storage for the referenced tools in the collection.
        /// </summary>
        private ITool[] mTools = null;

        /// <summary>
        /// Maximum number of tools that can be stored in the collection.
        /// </summary>
        private int mCapacity = 0;

        /// <summary>
        /// Public property that returns the total capacity of the collection.
        /// </summary>
        public int Capacity { get { return mCapacity; } }

        /// <summary>
        /// Property containing the current number of Tools in the collection.
        /// </summary>
        public int Number { get { return mTools.Length; } }

        /// <summary>
        /// Property for read-only access to the tools in the collection.
        /// </summary>
        public ITool[] Tools { get { return mTools; } }

        /// <summary>
        /// Creates a new tool collection with the specified capacity.
        /// The capacity is an upper bound for the number of tools that can be stored
        /// in the collection.
        /// </summary>
        /// <param name="capacity">Maximum number of tools in the collection</param>
        public ToolCollection(int capacity)
        {
            if (capacity < 1)
                throw new System.ArgumentOutOfRangeException("Capacity should be at least 1.");

            // Start with an empty array of no tools.
            mTools = new ITool[0];
            mCapacity = capacity;
        }

        public bool Add(ITool aTool)
        {
            throw new System.NotImplementedException("ToolCollection.Add() not implemented");
        }

        public void Clear()
        {
            throw new System.NotImplementedException("ToolCollection.Clear() not implemented");
        }

        public bool Delete(ITool aTool)
        {
            throw new System.NotImplementedException("ToolCollection.Delete() not implemented");
        }

        public bool IsEmpty()
        {
            throw new System.NotImplementedException("ToolCollection.IsEmpty() not implemented");
        }

        public bool IsFull()
        {
            throw new System.NotImplementedException("ToolCollection.IsFull() not implemented");
        }

        public bool Search(ITool aTool)
        {
            throw new System.NotImplementedException("ToolCollection.Search() not implemented");
        }
    }
}
