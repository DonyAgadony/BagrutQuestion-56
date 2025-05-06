class BinNode<T>
{
    T value;
    BinNode<T>? Left;

    BinNode<T>? Right;

    public BinNode(T value)
    {
        this.value = value;
    }

    public BinNode(T value, BinNode<T> Left, BinNode<T> Right)
    {
        this.value = value;
        this.Left = Left;
        this.Right = Right;
    }
    public void SetValue(T info)
    {
        this.value = info;
    }

    public T GetValue()
    {
        return value;
    }
    public void SetRight(T info)
    {
        Right.SetValue(info);
    }
    public void SetLeft(T info)
    {
        Left.SetValue(info);
    }
    public BinNode<T> GetRight()
    {
        return Right;
    }

    public BinNode<T> GetLeft()
    {
        return Left;
    }
    public void SetRight(BinNode<T> info)
    {
        Right = info;
    }
    public void SetLeft(BinNode<T> info)
    {
        Left = info;
    }
}
class Program
{
    public static bool IsUpPath(BinNode<int> root)
    {
        BinNode<int> temp = root;
        bool flag = true;
        while (root.GetLeft() != null)
        {
            if (root.GetLeft().GetValue() > root.GetValue()) { flag = true; }
            if (root.GetRight().GetValue() < root.GetValue()) { flag = flag || false; }

            root = root.GetLeft();

        }
        while (root.GetRight() != null)
        {
            if (root.GetLeft().GetValue() < root.GetValue()) { flag = flag || false; }
            if (root.GetRight().GetValue() < root.GetValue()) { flag = flag || false; }
            root = root.GetRight();
        }
        return flag;
    }
    public static void Main()
    {
        BinNode<int> bin = new(5);
        BinNode<int> bin1 = new(3);
        BinNode<int> bin2 = new(7);
        BinNode<int> bin3 = new(10);
        bin.SetLeft(bin1);
        bin.SetRight(bin2);
        bin2.SetRight(bin3);
        Console.WriteLine("Root value: " + bin.GetValue());
        Console.WriteLine("Left value: " + bin.GetLeft().GetValue());
        Console.WriteLine("Right value: " + bin.GetRight().GetValue());
        Console.WriteLine("Right->Right value: " + bin.GetRight().GetRight().GetValue());
        Console.WriteLine(IsUpPath(bin));
    }
}