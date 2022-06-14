using System;

namespace pdi
{
    internal class Program
    {
        static void Main()
        {
            Node[] hash = new Node[25];

            InsertNode(hash, "Alexandre");    
            InsertNode(hash, "Glaucia");
            InsertNode(hash, "Anderson");
            InsertNode(hash, "Alex");

            Search(hash, "Al");
            Search(hash, "B");
        }

        private static void Search(Node[] hash, string key)
        {
            int index = HashCode(key);
            Node node = hash[index];

            if (node != null)
            {
                while (node != null)
                {
                    var busca = node.Value[..key.Length];
                    if (busca == key)
                    {
                        Console.WriteLine(node.Value);
                    }
                    node = node.Next;
                }
            }
            else
            {
                Console.WriteLine($"Não foi encontrado nenhum nome que começe com '{key}'.");
            }

        }

        private static void InsertNode(Node[] hash, string value)
        {
            int index = HashCode(value);
            Node node = hash[index];
            
            if(node == null)
            {
                hash[index] = CreateNode(value);
            }
            else
            {
                while (node != null)
                {
                    if(node.Next == null)
                    {
                        node.Next = CreateNode(value);
                        break;
                    }
                    node = node.Next;
                }
            }
        }

        private static int HashCode(string value)
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            char key = Convert.ToChar(value[..1].ToUpper());

            for (int i = 0; i < alpha.Length; i++)
            {
              if(alpha[i] == key) return i;
            }

            return -1;
        }

        private static Node CreateNode(string value)
        {
            Node node = new(value, null);
            return node;
        }
    }
    
}


public class Node{ 

    public string Value { get; set; }
    public Node Next { get; set; }

    public Node(string value, Node next)
    {
        Value = value;
        Next = next;
    }

}