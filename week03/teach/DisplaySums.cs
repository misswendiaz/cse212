public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------"); 
        DisplaySumPairs([1, 1, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers) {
        // TODO Problem 2 - This should print pairs of numbers in the given array


        // Creates the list containing the values in the numbers array
        var list = new List<int>(numbers);

        // Creates an empty set
        var bondsOf10 = new HashSet<int>();

        // Iterates on the list but the index does not change since the first value always changes since it is removed in each iteration
        for (int i = 0; i < list.Count; i += 0)
        {
            // Gets the value of the first item in the list
            int number = list[i];

            // Determines the pair of the number to make a 10
            int pair = 10 - number;

            // Removes the first item on the list to avoid duplication (i.e. If the number is 5, its pair is 5. If it is not removed from the list, then the check done whether its pair is on the list will return true, but there is only one 5, not two.)
            list.Remove(number);


            // Checks if the pair is in the list
            // If it is in the list...
            if (list.Contains(pair))
            {
                // Makes sure that there is no duplicate even if there are duplicates in the list/array (i.e. no 5 5)
                if (pair != number)
                {
                    // Checks if the number is in the set
                    // If the number is not yet in the set, it is added to the set as well as its pair
                    if (!bondsOf10.Contains(number))
                    {
                        bondsOf10.Add(number);
                        bondsOf10.Add(pair);
                        Console.WriteLine($"{number} {pair}");
                    }
                }
            }
        }
    }
}