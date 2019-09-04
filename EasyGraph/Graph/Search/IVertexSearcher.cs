using System;

namespace EasyGraph.Graph.Search
{
    public interface IVertexSearcher<T>
    {
        IVertex<T> Search(IGraph<T> graph, IVertex<T> startingVertex, Func<T, bool> searchCriteria);
    }
}