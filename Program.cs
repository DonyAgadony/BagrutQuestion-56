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

    public void SetValue(T info) => this.value = info;
    public T GetValue() => value;
    public void SetRight(T info) => Right?.SetValue(info);
    public void SetLeft(T info) => Left?.SetValue(info);
    public BinNode<T> GetRight() => Right;
    public BinNode<T> GetLeft() => Left;
    public void SetRight(BinNode<T> info) => Right = info;
    public void SetLeft(BinNode<T> info) => Left = info;
}

class Program
{
    public static bool IsUpPath(BinNode<int> node)
    {
        return IsUpPath(node, int.MinValue);
    }

    private static bool IsUpPath(BinNode<int>? node, int prev)
    {
        if (node == null) return false;

        int curr = node.GetValue();

        if (curr <= prev)
            return false;

        // אם זה עלה – הצלחנו
        if (node.GetLeft() == null && node.GetRight() == null)
            return true;

        // בדיקה האם יש מסלול עולה מאחת מההתפצלויות
        return IsUpPath(node.GetLeft(), curr) || IsUpPath(node.GetRight(), curr);
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

        Console.WriteLine("Is there an increasing path? " + IsUpPath(bin));
    }
}
