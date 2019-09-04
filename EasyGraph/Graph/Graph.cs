using System.Collections.Generic;

namespace EasyGraph.Graph
{
    public class Graph<T> : IGraph<T>
    {
        private readonly ICollection<IVertex<T>> _vertices = new List<IVertex<T>>();

        public IEnumerable<IVertex<T>> GetVertices()
        {
            return _vertices;
        }

        public void AddVertex(IVertex<T> vertex)
        {
            _vertices.Add(vertex);
        }

        public bool RemoveVertex(IVertex<T> vertexToRemove)
        {
            if (!_vertices.Remove(vertexToRemove))
            {
                return false;
            }

            foreach (var vertex in _vertices)
            {
                vertex.RemoveEdge(vertex);
            }

            return true;
        }
    }
}