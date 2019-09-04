using System.Collections.Generic;

namespace EasyGraph.Graph
{
    public class Vertex<T> : IVertex<T>
    {
        public T Value { get; set; }
        private readonly ICollection<IVertex<T>> _adjacentVertices = new List<IVertex<T>>();

        public IEnumerable<IVertex<T>> GetAdjacencyList()
        {
            return _adjacentVertices;
        }

        public void AddEdge(IVertex<T> vertexToConnect)
        {
            _adjacentVertices.Add(vertexToConnect);
        }

        public bool RemoveEdge(IVertex<T> vertexToRemove)
        {
            return _adjacentVertices.Remove(vertexToRemove);
        }
    }
}