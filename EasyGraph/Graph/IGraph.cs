using System.Collections.Generic;

namespace EasyGraph.Graph
{
    public interface IGraph<T>
    {
        IEnumerable<IVertex<T>> GetVertices();
        void AddVertex(IVertex<T> vertex);
        bool RemoveVertex(IVertex<T> vertex);
    }
}