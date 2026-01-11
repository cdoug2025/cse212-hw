public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Create an array with capacity 'length'
        // In a for loop, iterate through the loop 'length' times, with the itertion number starting at zero and doubling as an index number
        // With 'multiple' starting at 0, in each iteration, add 'number' to 'multiple',
        // and put 'multiple' in the iteration or index number of 'result'.
        // Return result.

        double[] result = new double[length];
        double multiple = 0;
        for (int index = 0; index < length; index++)
        {
            multiple += number;
            result[index] = multiple;
        }

        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {

        // GetRange where the index is equal to 'length' - 'amount', and the count is equal to 'amount'.
        // AddRange this to a new list.
        // GetRange where the index is equal to 0, and the count is equal to 'length' - 'amount'.
        // AddRange the result to the new list.
        // Clear 'data'.
        // Add new list into 'data'.

        List<int> shiftedList = new();
        shiftedList.AddRange(data.GetRange(data.Count - amount, amount));
        shiftedList.AddRange(data.GetRange(0, data.Count - amount));
        data.Clear();
        data.AddRange(shiftedList);
    }
}
