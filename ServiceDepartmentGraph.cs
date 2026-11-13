
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MunicipalServicesApp
{
    // Represents a connection between two municipal departments.
    public class GraphEdge
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public int Weight { get; set; }

        public GraphEdge(string source, string destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }

        public override string ToString()
        {
            return Source + " <-> " + Destination +
                   " (Weight: " + Weight + ")";
        }
    }

    public class ServiceDepartmentGraph
    {
        private readonly Dictionary<string, List<GraphEdge>>
            adjacencyList;

        public ServiceDepartmentGraph()
        {
            adjacencyList =
                new Dictionary<string, List<GraphEdge>>(
                    StringComparer.OrdinalIgnoreCase);
        }

        public void AddDepartment(string department)
        {
            if (string.IsNullOrWhiteSpace(department))
                throw new ArgumentException(
                    "Department name is required.");

            if (!adjacencyList.ContainsKey(department))
            {
                adjacencyList.Add(
                    department,
                    new List<GraphEdge>());
            }
        }

        public void AddConnection(
            string source,
            string destination,
            int weight)
        {
            if (string.IsNullOrWhiteSpace(source) ||
                string.IsNullOrWhiteSpace(destination))
            {
                throw new ArgumentException(
                    "Both departments are required.");
            }

            if (weight < 0)
                throw new ArgumentException(
                    "Weight cannot be negative.");

            if (source.Equals(
                destination,
                StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "A department cannot connect to itself.");
            }

            AddDepartment(source);
            AddDepartment(destination);

            bool exists = adjacencyList[source].Any(
                e => e.Destination.Equals(
                    destination,
                    StringComparison.OrdinalIgnoreCase));

            if (exists)
                throw new InvalidOperationException(
                    "This connection already exists.");

            adjacencyList[source].Add(
                new GraphEdge(source, destination, weight));

            adjacencyList[destination].Add(
                new GraphEdge(destination, source, weight));
        }

        public List<string> GetDepartments()
        {
            return adjacencyList.Keys.ToList();
        }

        public List<GraphEdge> GetConnections()
        {
            List<GraphEdge> edges =
                new List<GraphEdge>();

            foreach (var department in adjacencyList)
            {
                foreach (var edge in department.Value)
                {
                    if (string.Compare(
                        edge.Source,
                        edge.Destination,
                        StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        edges.Add(edge);
                    }
                }
            }

            return edges;
        }

        public List<string> BFS(string startDepartment)
        {
            if (string.IsNullOrWhiteSpace(startDepartment) ||
                !adjacencyList.ContainsKey(startDepartment))
            {
                throw new ArgumentException(
                    "Starting department was not found.");
            }

            List<string> result = new List<string>();

            HashSet<string> visited =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            Queue<string> queue = new Queue<string>();

            visited.Add(startDepartment);
            queue.Enqueue(startDepartment);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                result.Add(current);

                foreach (GraphEdge edge in adjacencyList[current])
                {
                    if (visited.Add(edge.Destination))
                        queue.Enqueue(edge.Destination);
                }
            }

            return result;
        }

        public List<string> DFS(string startDepartment)
        {
            if (string.IsNullOrWhiteSpace(startDepartment) ||
                !adjacencyList.ContainsKey(startDepartment))
            {
                throw new ArgumentException(
                    "Starting department was not found.");
            }

            List<string> result = new List<string>();

            HashSet<string> visited =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            DFSRecursive(startDepartment, visited, result);

            return result;
        }

        private void DFSRecursive(
            string department,
            HashSet<string> visited,
            List<string> result)
        {
            visited.Add(department);
            result.Add(department);

            foreach (GraphEdge edge in adjacencyList[department])
            {
                if (!visited.Contains(edge.Destination))
                {
                    DFSRecursive(
                        edge.Destination,
                        visited,
                        result);
                }
            }
        }

        public List<GraphEdge> MinimumSpanningTree()
        {
            List<GraphEdge> mst = new List<GraphEdge>();

            List<GraphEdge> sortedEdges =
                GetConnections()
                    .OrderBy(edge => edge.Weight)
                    .ToList();

            Dictionary<string, string> parent =
                new Dictionary<string, string>(
                    StringComparer.OrdinalIgnoreCase);

            Dictionary<string, int> rank =
                new Dictionary<string, int>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (string department in adjacencyList.Keys)
            {
                parent[department] = department;
                rank[department] = 0;
            }

            foreach (GraphEdge edge in sortedEdges)
            {
                string root1 = Find(parent, edge.Source);
                string root2 = Find(parent, edge.Destination);

                if (!root1.Equals(
                    root2,
                    StringComparison.OrdinalIgnoreCase))
                {
                    mst.Add(edge);
                    Union(parent, rank, root1, root2);
                }

                if (mst.Count == adjacencyList.Count - 1)
                    break;
            }

            return mst;
        }

        private string Find(
            Dictionary<string, string> parent,
            string department)
        {
            if (!parent[department].Equals(
                department,
                StringComparison.OrdinalIgnoreCase))
            {
                parent[department] =
                    Find(parent, parent[department]);
            }

            return parent[department];
        }

        private void Union(
            Dictionary<string, string> parent,
            Dictionary<string, int> rank,
            string root1,
            string root2)
        {
            if (rank[root1] < rank[root2])
                parent[root1] = root2;
            else if (rank[root1] > rank[root2])
                parent[root2] = root1;
            else
            {
                parent[root2] = root1;
                rank[root1]++;
            }
        }

        public int GetMSTTotalWeight()
        {
            return MinimumSpanningTree()
                .Sum(edge => edge.Weight);
        }

        public string DisplayGraph()
        {
            StringBuilder output = new StringBuilder();

            foreach (var department in adjacencyList)
            {
                output.AppendLine(department.Key + ":");

                foreach (GraphEdge edge in department.Value)
                {
                    output.AppendLine(
                        "  -> " + edge.Destination +
                        " (Weight: " + edge.Weight + ")");
                }
            }

            return output.ToString();
        }
    }
}
