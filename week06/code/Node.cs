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
        // Already contains value
        if (value != Data)
        {
            if (value < Data)
            {
                // Insert to the left
                if (Left is null)
                    Left = new Node(value);
                else
                    Left.Insert(value);
            }
            else
            {
                // Insert to the right
                if (Right is null)
                    Right = new Node(value);
                else
                    Right.Insert(value);
            }
        }
    }

    public bool Contains(int value)
    {
        // Value being searched for matches current Node 
        if (value == Data)
            return true;
        
        // Value being searched for is less than current Node
        else if (value < Data)
        {
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        // Value being searched for is more than current Node
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
        // Set default values
        int left = 1;
        int right = 1;

        // Get height of left subtree
        if (Left is not null)
        {
            left += Left.GetHeight();
        }

        // Get height of right subtree
        if (Right is not null)
        {
            right += Right.GetHeight();
        }

        // Return the height of the taller subtree
        if (left >= right)
            return left;
        else
            return right;
    }
}