using System.Collections.Generic;

namespace EasyGraph.Graph
{
    public interface IVertex<T>
    {
        T Value { get; set; }
        IEnumerable<IVertex<T>> GetAdjacencyList();
        void AddEdge(IVertex<T> vertexToConnect);
        bool RemoveEdge(IVertex<T> vertexToRemove);

    }
}