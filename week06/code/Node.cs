using System.Net;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // If the value is less than the parent node, insert it to the left
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }

        // If the value is greater than the parent node, insert it to the right
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }

        // If the value is equaal to the parent node, do not do anything, just go back
        else
        {
            return;
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        // If the value is equal to the data, return true (the data is found)
        if (value == Data)
        {
            return true;
        }

        // If the value is not equal to the data, look somewhere else
        else if (value < Data)
        {
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else
        {
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // return 0; // Replace this line with the correct return statement(s)

        // Initialize heights of left and right subtrees
        int leftHeight = 0;
        int rightHeight = 0;

        // Get the heights of the immediate left and right subtrees
        if (Left is not null)
            leftHeight = Left.GetHeight();

        if (Right is not null)
            rightHeight = Right.GetHeight();

        // Return the bigger height plus the height of the root
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}