using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyGraph.Graph.Search
{
    public class DepthFirstSearcher<T> : IVertexSearcher<T>
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
            // Create a stack for DFS 
            var stack = new Stack<IVertex<T>>();

            // Mark the current vertex as visited and push it on top of stack 
            visited[startingVertex] = true;
            stack.Push(startingVertex);

            while (stack.Count != 0)
            {
                var currentVertex = stack.Pop();
                Console.WriteLine($"{currentVertex.Value} | ");

                //Check if currentVertex meets search criteria
                if (searchCriteria(currentVertex.Value))
                {
                    return currentVertex;
                }

                //push all non visited vertices on the stack
                var adjacencyList = currentVertex.GetAdjacencyList();
                foreach (var vertexToQueue in adjacencyList)
                {
                    if (visited.ContainsKey(vertexToQueue) && !visited[vertexToQueue])
                    {
                        visited[vertexToQueue] = true;
                        stack.Push(vertexToQueue);
                    }
                }
            }

            return null;
        }
    }
}