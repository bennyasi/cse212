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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: create a new list named result.
        // Step 2: create a multiplier and set the value to 1.
        // Step 3: Make a for loop, setting i to 0, while i is less than the int length argument, and adding one to i after each loop.
        // Step 4: Inside the loop, multiply the double number argument by the multiplier you created at the start of the function and add this number to the results list.
        // Step 5: Still inside the loop, add 1 to the multiplier, so that each time the loop runs, the number argument is being multiplied by a bigger multiplier.
        // Step 6: Outside of the loop, return the results list, but append .ToArray() to make it the proper format before returning

        List<double> results = new();
        int multiplier = 1;
        for (var i = 0; i < length; i++)
        {
            double multipliedNum = number * multiplier;
            results.Add(multipliedNum);
            multiplier++;
        }
        ;

        return results.ToArray(); // replace this return statement with your own
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Step 1: Create an int List variable called rotateRange. 
        // Step 2: Set the value of rotateRange to be data.GetRange(data.Count - amount, amount. That should hopefully the values at the end of the list rather than the start)
        // Step 3: Remove the range that you added to rotateRange doing data.RemoveRange(data.Count - amount, amount)
        // Step 4: Insert rotateRange into data using data.InsertRange(0, rotateRange)
    
        List<int> rotateRange = new();
        rotateRange = data.GetRange(data.Count - amount, amount);
        data.RemoveRange(data.Count - amount, amount);
        data.InsertRange(0, rotateRange);
    }   
}
