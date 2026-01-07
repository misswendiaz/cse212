using System.Net.Http.Headers;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        var list = new List<int>();

        int l1Index = 0;
        int l2Index = 0;

        for (int i = 0; i < select.Length; i++)
        {
            int element = select[i];
            if (element == 1)
            {
                int l1item = list1[l1Index];
                list.Add(l1item);
                l1Index++;
            }
            else if (element == 2)
            {
                int l2item = list2[l2Index];
                list.Add(l2item);
                l2Index++;
            }
        }
        return list.ToArray();
    }
}