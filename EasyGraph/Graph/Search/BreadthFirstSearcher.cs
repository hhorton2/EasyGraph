using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyGraph.Graph.Search
{
    public class BreadthFirstSearcher<T> : IVertexSearcher<T>
    {
        public IVertex<T> Search(IGraph<T> graph, IVertex<T> startingVertex, Func<T, bool> searchCriteria)
        {
            var vertices = graph.GetVertices().ToList();
            if (!vertices.Contains(startingVertex))
            {
                return null;
            }
            var visited = new Dictionary<IVertex<T>, bool>();
            vertices.ForEach(v => visited.Add(v, false));
            // Create a queue for BFS 
            var queue = new List<IVertex<T>>();

            // Mark the current vertex as visited and enqueue it 
            visited[startingVertex] = true;
            queue.Add(startingVertex);

            while (queue.Count != 0)
            {
                // Dequeue a vertex from queue and print it 
                var currentVertex = queue.First();
                queue.RemoveAt(0);
                Console.WriteLine($"{currentVertex.Value} | ");
                
                //Check if currentVertex meets search criteria
                if (searchCriteria(currentVertex.Value))
                {
                    return currentVertex;
                }

                //enqueue all non visited vertices
                var i = currentVertex.GetAdjacencyList();
                foreach (var vertexToQueue in i)
                {
                    if (visited.ContainsKey(vertexToQueue) && !visited[vertexToQueue])
                    {
                        visited[vertexToQueue] = true;
                        queue.Add(vertexToQueue);
                    }
                }
            }

            return null;
        }
    }
}