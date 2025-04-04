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
            // Check if the tool is null
            if (aTool != null)
            {
                if (Number < Capacity)
                {
                    // Check if the tool is already in the collection
                    if (!Search(aTool))
                    {
                        // Create a new array with one more element
                        ITool[] newTools = new ITool[Number + 1];
                        int i = 0;

                        // Copy existing tools to the new array
                        while (i < Number && mTools[i].Name.CompareTo(aTool.Name) < 0)
                        {
                            newTools[i] = mTools[i];
                            i++;
                        }

                        // Add the new tool
                        newTools[i] = aTool;

                        // Copy remaining tools
                        for (int j = i; j < Number; j++)
                        {
                            newTools[j + 1] = mTools[j];
                        }

                        mTools = newTools;
                        return true;
                    }
                    else
                    {
                        // Tool already exists in the collection
                        return false;
                    }
                }
                return false; // Collection is full
            }
            // Tool is null
            return false;
        }

        public void Clear()
        {
            // Check if the collection is empty
            if (IsEmpty())
            {
                // Collection is already empty
                return;
            }
            // Create a new empty array
            ITool[] newTools = new ITool[0];
            mTools = newTools;
        }

        public bool Delete(ITool aTool)
        {
            // Check if the tool is null    
            if (aTool != null)
            {
                // Check if the tool is in the collection
                if (Search(aTool))
                {
                    // Create a new array with one less element
                    ITool[] newTools = new ITool[Number - 1];
                    int i = 0;

                    // Copy existing tools to the new array, skipping the tool to be deleted
                    for (int j = 0; j < Number; j++)
                    {
                        if (mTools[j].Name != aTool.Name)
                        {
                            newTools[i] = mTools[j];
                            i++;
                        }
                    }

                    mTools = newTools;
                    return true;
                }
                return false; // Tool not found in the collection
            }
            // Tool is null
            return false;
        }

        public bool IsEmpty()
        {
            // Check if the collection is empty
            if (Number == 0)
            {
                return true;
            }
            return false;      
        }

        public bool IsFull()
        {
            // Check if the collection is full
            if (Number == Capacity)
            {
                return true;
            }
            return false;
        }

        public bool Search(ITool aTool)
        {
            // Check if the tool is null

            if (aTool != null)
            {
                // Perform a binary search for the tool in the collection
                int left = 0;
                int right = Number - 1;

                while (left <= right)
                {
                    int mid = (left + right) / 2;

                    // Compare the tool names
                    int comparison = mTools[mid].Name.CompareTo(aTool.Name);

                    if (comparison == 0)
                    {
                        return true; // Tool found
                    }
                    else if (comparison < 0)
                    {
                        left = mid + 1; // Search in the right half
                    }
                    else
                    {
                        right = mid - 1; // Search in the left half
                    }
                }
                return false; // Tool not found
            }
            // Tool is null
            return false;
        }
    }
}
