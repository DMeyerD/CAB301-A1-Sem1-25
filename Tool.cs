﻿
namespace Assignment1
{
    public partial class Tool : ITool
    {
        /// <summary>
        /// Represents the name of the tool. This string must non-empty.
        /// </summary>
        private string mName;

        /// <summary>
        /// Array containing the current borrowers for the tool.
        /// There is no specific requirement for the ordering of borrower names, but there should
        /// never be any duplicate names in the array.
        /// </summary>
        private string[] mBorrowers;

        /// <summary>
        /// Private field containing the maximum number of borrowers.
        /// </summary>
        private int mQuantity;

        /// <summary>
        /// Represents the name of the tool. This string must non-empty.
        /// </summary>
        public string Name { get { return mName; } }

        /// <summary>
        /// Represents the quantity of tools that are tracked by this object.
        /// If there were 10 hammers available, then Quantity would return 10 regardless of
        /// how many were currently being borrowed.
        /// </summary>
        public int Quantity { get { return mQuantity; } }

        /// <summary>
        /// Array containing the current borrowers for the tool.
        /// There is no specific requirement for the ordering of borrower names, but there should
        /// never be any duplicate names in the array.
        /// </summary>
        public string[] Borrowers { get { return mBorrowers; } }

        /// <summary>
        /// Property containing the current number of borrowers of the tool.
        /// </summary>
        public int AvailableQuantity { get { return mQuantity - mBorrowers.Length; } }

        /// <summary>
        /// Creates a new tool that tracks borrowers, and can be added to a collection.
        /// </summary>
        /// <param name="name">Name of this tool, must be non-empty otherwise ArgumentException is thrown</param>
        /// <param name="quantity">Quantity to make available to borrowers, must be greater than or equal
        /// to 1, otherwise ArgumentOutOfRangeException should be thrown.</param>
        public Tool(string name, int quantity)
        {
            if (name == null || name.Length == 0)
                throw new System.ArgumentException("name must not be a null or empty string");

            if (quantity < 1)
                throw new System.ArgumentOutOfRangeException("Quantity must be at least 1");

            mName = name;
            mBorrowers = new string[0];
            mQuantity = quantity;
        }

        public bool IncreaseQuantity(int num)
        {
                // Check if the input number is valid (greater than 0)
            if (num > 0)
            {
                // Update the quantity and available quantity
                mQuantity += num;
                return true;
            }
            else
            {
                // If the input is invalid, return false without changing the state
                return false;
            }
            throw new System.NotImplementedException("Tool.IncreaseQuantity() not implemented");
        }

        public bool DecreaseQuantity(int num)
        {
            // add a BORROWER to the borrower list
            if (num > 0 && num <= AvailableQuantity && (mQuantity - num) >= 1)
            {
                mQuantity -= num;
                return true;
            }
            else
            {
                return false;
            }
            throw new System.NotImplementedException("Tool.DecreaseQuantity() not implemented");
        }

        public bool AddBorrower(string aBorrower)
        {    
            // Check pre-conditions: AvailableQuantity > 0, aBorrower is not null or empty
            if (AvailableQuantity > 0 && !string.IsNullOrEmpty(aBorrower))
            {
                // Check if the borrower is already in the list
                for (int i = 0; i < mBorrowers.Length; i++)
                {
                    if (mBorrowers[i] == aBorrower)
                    {
                        // Borrower already exists, return false
                        return false;
                    }
                }

                // Add the borrower to the list
                string[] newBorrowers = new string[mBorrowers.Length + 1];
                for (int i = 0; i < mBorrowers.Length; i++)
                {
                    newBorrowers[i] = mBorrowers[i];
                }
                newBorrowers[mBorrowers.Length] = aBorrower;

                // Update the borrowers array
                mBorrowers = newBorrowers;

                // added successfully
                return true;
            }
            else
            {
                // Pre-conditions not met, return false
                return false;
            } 
            throw new System.NotImplementedException("Tool.AddBorrower() not implemented");
        }

        public bool DeleteBorrower(string aBorrower)
        {
            if (!string.IsNullOrEmpty(aBorrower))
            {
                for (int i = 0; i < mBorrowers.Length; i++)
                {
                    if (mBorrowers[i] == aBorrower)
                    {
                        string [] newBorrowers = new string[mBorrowers.Length - 1];
                        int k = 0;
                        for (int j = 0; j < mBorrowers.Length; j++)
                        {
                            if (j != i)
                            {
                                newBorrowers[k++] = mBorrowers[j];
                            }
                        }
                        mBorrowers = newBorrowers;


                        return true;
                    }
                }
                return false;
            }
            return false;        
        }

        public bool SearchBorrower(string aBorrower)
        {
            // Check if the borrower is in the list
            for (int i = 0; i < mBorrowers.Length; i++)
            {
                if (mBorrowers[i] == aBorrower)
                {
                    // Borrower found, return true
                    return true;
                }
            }
            // Borrower not found, return false
            return false;

            throw new System.NotImplementedException("Tool.SearchBorrower() not implemented");
        }
    }
}