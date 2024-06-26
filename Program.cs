using System;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            BinaryNode<int> binaryNode = new BinaryNode<int>(1);
            BinaryNode<int> binaryNode2 = new BinaryNode<int>(2);
            BinaryNode<int> binaryNode3 = new BinaryNode<int>(3);
            BinaryNode<int> binaryNode4 = new BinaryNode<int>(5);
            BinaryNode<int> binaryNode5 = new BinaryNode<int>(6);
            
            binaryNode.SetLeft(binaryNode2);
            binaryNode.SetRight(binaryNode3);
            binaryNode2.SetLeft(binaryNode4);
            binaryNode2.SetRight(binaryNode5);

            Console.Write("Pre order: ");
            PreOrder(binaryNode);
            Console.Write("\nIn order: ");
            InOrder(binaryNode);
            Console.Write("\nPost order: ");
            PostOrder(binaryNode);
            Console.Write("\nPrint even: ");
            PrintEven(binaryNode);
            Console.WriteLine("\nCounter: " + NumOfNodes(binaryNode));
            Console.WriteLine($"Is exist: {IsExists(binaryNode, 7)}");
            Console.WriteLine($"Does each father has 2 children: {IsEachFatherHas2Child(binaryNode)}");
            Console.WriteLine($"Height: {Height(binaryNode)}");
        }
        static void PreOrder<T>(BinaryNode<T> t)
        {
            if (t == null) return;
            Console.Write($"{t.GetValue()} ➡  ");
            PreOrder(t.GetLeft());
            PreOrder(t.GetRight());
        }
        static void InOrder<T>(BinaryNode<T> t)
        {
            if (t == null) return;
            InOrder(t.GetLeft());
            Console.Write($"{t.GetValue()} ➡  ");
            InOrder(t.GetRight());
        }
        static void PostOrder<T>(BinaryNode<T> t)
        {
            if (t == null) return;
            PostOrder(t.GetLeft());
            PostOrder(t.GetRight());
            Console.Write($"{t.GetValue()} ➡  ");
        }
        static void PrintEven(BinaryNode<int> t)
        {
            if (t == null) return;
            if (t.GetValue() % 2 == 0)
                Console.Write($"{t.GetValue()} ➡  ");
            PrintEven(t.GetLeft());
            PrintEven(t.GetRight());
        }
        static int NumOfNodes<T>(BinaryNode<T> t)
        {
            if (t == null) return 0;
            return 1 + NumOfNodes(t.GetLeft()) + NumOfNodes(t.GetRight());
        }
        static bool IsExists<T>(BinaryNode<T> t, T value)
        {
            if (t == null) return false;
            if (value.Equals(t.GetValue())) return true;
            return IsExists(t.GetLeft(), value) || IsExists(t.GetRight(), value);
        }
        static bool IsEachFatherHas2Child<T>(BinaryNode<T> t)
        {
            if (t == null)
                return true;
            if (t.HasLeft() && !t.HasRight())
                return false;
            if (!t.HasLeft() && t.HasRight())
                return false;
            if(!t.HasLeft() && t.HasRight())
                return true;
            return IsEachFatherHas2Child(t.GetLeft()) && IsEachFatherHas2Child(t.GetRight());
        }
        static int Height<T>(BinaryNode<T> t)
        {
            if (t == null) return 0;
            return 1 + Math.Max(Height(t.GetLeft()), Height(t.GetRight()));
        }
    }
}
