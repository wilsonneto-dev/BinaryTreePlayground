var tree = Algorithms.CreateExampleTree();

Console.WriteLine("Tree: " + string.Join(", ", tree) + "\n\n");

Console.WriteLine("BFS: " + string.Join(", ", Algorithms.Bfs(tree)) + " -- Expected: 1, 2, 3, 4, 5, 6, 7");

Console.WriteLine("DFS In Order: " + string.Join(", ", Algorithms.DfsInOrder(tree)) + " -- Expected: 4, 2, 5, 1, 6, 3, 7");

Console.WriteLine("DFS Post Order: " + string.Join(", ", Algorithms.DfsPostOrder(tree)) + " -- Expected: 4, 5, 2, 6, 7, 3, 1");

Console.WriteLine("DFS Pre Order: " + string.Join(", ", Algorithms.DfsPreOrder(tree)) + " -- Expected: 1, 2, 4, 5, 3, 6, 7");

Algorithms.BfsPrintNodesAndLevels(tree);
Algorithms.BfsPrintNodesAndLevels(Algorithms.CreateExampleTreeV2());

// ---------------

record Node(int Value, Node? Left = null, Node? Right = null);

static class Algorithms
{
    internal static List<int> Bfs(Node root) {
        if(root is null) return new();

        var queue = new Queue<Node>();
        queue.Enqueue(root);
        var list = new List<int>();

        while(queue.Count > 0)
        {
            var node = queue.Dequeue();
            list.Add(node.Value);
            
            if(node.Left is not null) queue.Enqueue(node.Left);
            if(node.Right is not null) queue.Enqueue(node.Right);
        }

        return list;
    }

    internal static List<int> DfsInOrder(Node node, List<int>? list = null) {
        if(node is null) return new List<int>();
        list ??= new List<int>();

        if(node.Left is not null) DfsInOrder(node.Left, list);
        list.Add(node.Value);
        if(node.Right is not null) DfsInOrder(node.Right, list);

        return list;
    }

    internal static List<int> DfsPreOrder(Node node, List<int>? list = null) {
        if(node is null) return new List<int>();
        list ??= new List<int>();

        list.Add(node.Value);
        if(node.Left is not null) DfsPreOrder(node.Left, list);
        if(node.Right is not null) DfsPreOrder(node.Right, list);

        return list;
    }

    internal static List<int> DfsPostOrder(Node node, List<int>? list = null) {
        if(node is null) return new List<int>();
        list ??= new List<int>();

        if(node.Left is not null) DfsPostOrder(node.Left, list);
        if(node.Right is not null) DfsPostOrder(node.Right, list);
        list.Add(node.Value);

        return list;
    }

    
    internal static void BfsPrintNodesAndLevels(Node node) {
        if(node is null) 
        {
            Console.WriteLine("null...");
            return;
        }
        
        var queue = new Queue<Node>();
        queue.Enqueue(node);
        var level = 0;

        while(queue.Count > 0)
        {
            var size = queue.Count;
            level++;
            for(int i = 0; i < size; i++)
            {
                var current = queue.Dequeue();
                Console.Write($"(value: {current.Value}, level: {level}, q.size: {size}) ");

                if(current.Left is not null) queue.Enqueue(current.Left);
                if(current.Right is not null) queue.Enqueue(current.Right);
            }
        }

        Console.WriteLine("\n");
    }

    internal static Node CreateExampleTree() => 
        new Node(1, 
            new Node(2, 
                new Node(4), 
                new Node(5)), 
            new Node(3, 
                new Node(6), 
                new Node(7)));

    internal static Node CreateExampleTreeV2() => 
        new Node(1, 
            new Node(2, 
                new Node(4), 
                new Node(5,
                    null,
                    new Node(8))),
            new Node(3, 
                new Node(6), 
                new Node(7,
                    null,
                    new Node(9))));
}
