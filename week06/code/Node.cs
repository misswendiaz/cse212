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

        int height = 1;

        if (Left is null && Right is null)
        {
            return height;
        }

        else
        {
            // Get the height of the left subtree
            int leftHeight = 1;
            if (Left is not null)
            {
                leftHeight = leftHeight + Left.GetHeight();
            }

            // Get the height of the right subtree
            int rightHeight = 1;
            if (Right is not null)
            {
                rightHeight = height + Right.GetHeight();
            }

            // Compare the height of the left and the right subtrees
            // The bigger height is the height of the tree
            if (leftHeight > rightHeight)
            {
                height = leftHeight;
                return height;
            }
            else if (leftHeight == rightHeight)
            {
                height = leftHeight;
                return height;
            }
            else
            {
                height = rightHeight;
                return height;
            }
        }
    }
}