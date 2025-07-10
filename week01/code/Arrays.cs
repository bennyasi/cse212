using System;
using System.Collections.Generic;

public class Arrays
{
    /*
     * Plan for MultiplesOf:
     * 1. Create a new array of doubles with length equal to 'count'.
     * 2. Use a for-loop from 0 up to count - 1.
     * 3. At each iteration, calculate the multiple by multiplying 'start' by (i + 1).
     * 4. Store the calculated multiple in the array at index i.
     * 5. After the loop completes, return the populated array.
     */
    public static double[] MultiplesOf(double start, int count)
    {
        // Step 1: Initialize the array to hold the multiples
        double[] multiplesOf = new double[count];

        // Step 2 and 3: Calculate each multiple and store it
        for (int i = 0; i < count; i++)
        {
            multiplesOf[i] = start * (i + 1);
        }

        // Step 5: Return the completed array of multiples
        return multiplesOf;
    }

    /*
     * Plan for RotateListRight:
     * 1. Understand that rotating right by 'amount' means moving the last 'amount' 
     *    of elements to the front of the list.
     * 2. Use List.GetRange to slice the list into two parts:
     *    a) The last 'amount' elements (to move to front).
     *    b) The remaining elements at the start of the list.
     * 3. Clear the original list to prepare for reassembly.
     * 4. Add the sliced last part first to the list.
     * 5. Add the sliced first part after the last part.
     * 6. Return the rotated list.
     */
    public static List<int> RotateListRight(List<int> data, int amount)
    {
        // Edge case: if amount equals list size, no rotation needed
        if (amount == data.Count)
        {
            return data;
        }

        // Step 2a: Extract last 'amount' elements
        List<int> lastPart = data.GetRange(data.Count - amount, amount);

        // Step 2b: Extract the rest of the list (from start up to count - amount)
        List<int> firstPart = data.GetRange(0, data.Count - amount);

        // Step 3: Clear original list to reconstruct rotated list
        data.Clear();

        // Step 4: Add last part first
        data.AddRange(lastPart);

        // Step 5: Add first part after last part
        data.AddRange(firstPart);

        // Step 6: Return rotated list
        return data;
    }
}
