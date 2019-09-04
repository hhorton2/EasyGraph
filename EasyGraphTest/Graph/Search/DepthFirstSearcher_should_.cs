using EasyGraph.Graph;
using EasyGraph.Graph.Search;
using FluentAssertions;
using Xunit;

namespace EasyGraphTest.Graph.Search
{
    public class DepthFirstSearcher_should_
    {
        [Fact]
        public void return_null_if_nothing_meets_criteria()
        {
            var a = new Vertex<string>
            {
                Value = "Dog"
            };
            var b = new Vertex<string>
            {
                Value = "Dog"
            };
            a.AddEdge(b);
            var graph = new Graph<string>();
            graph.AddVertex(a);
            graph.AddVertex(b);
            var dfsSearcher = new DepthFirstSearcher<string>();

            var result = dfsSearcher.Search(graph, a, s => s == "Cat");

            result.Should().Be(null);
        }

        [Fact]
        public void return_null_if_starting_vertex_not_in_graph()
        {
            var a = new Vertex<string>
            {
                Value = "Dog"
            };
            var b = new Vertex<string>
            {
                Value = "Dog"
            };
            var c = new Vertex<string>
            {
                Value = "Dog"
            };
            a.AddEdge(b);
            b.AddEdge(c);
            var graph = new Graph<string>();
            graph.AddVertex(b);
            var dfsSearcher = new DepthFirstSearcher<string>();

            var result = dfsSearcher.Search(graph, a, s => s == "Dog");

            result.Should().Be(null);
        }

        [Fact]
        public void return_starting_vertex_if_meets_criteria()
        {
            var a = new Vertex<string>
            {
                Value = "Dog"
            };
            var b = new Vertex<string>
            {
                Value = "Dog"
            };
            a.AddEdge(b);
            var graph = new Graph<string>();
            graph.AddVertex(a);
            graph.AddVertex(b);
            var dfsSearcher = new DepthFirstSearcher<string>();

            var result = dfsSearcher.Search(graph, a, s => s == "Dog");

            result.Should().Be(a);
        }

        [Fact]
        public void search_depth_first()
        {
            var a = new Vertex<string>
            {
                Value = "Cat"
            };
            var b = new Vertex<string>
            {
                Value = "Rat"
            };
            var c = new Vertex<string>
            {
                Value = "Dog"
            };
            var d = new Vertex<string>
            {
                Value = "Turtle"
            };
            var e = new Vertex<string>
            {
                Value = "Parrot"
            };
            var f = new Vertex<string>
            {
                Value = "Raccoon"
            };
            var g = new Vertex<string>
            {
                Value = "Dog"
            };
            a.AddEdge(b);
            b.AddEdge(c);
            a.AddEdge(d);
            d.AddEdge(e);
            e.AddEdge(f);
            f.AddEdge(g);
            var graph = new Graph<string>();
            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);
            graph.AddVertex(g);

            var dfsSearcher = new DepthFirstSearcher<string>();

            var result = dfsSearcher.Search(graph, a, s => s == "Dog");

            result.Should().Be(g);
        }

        [Fact]
        public void only_search_nodes_on_graph()
        {
            var a = new Vertex<string>
            {
                Value = "Cat"
            };
            var b = new Vertex<string>
            {
                Value = "Rat"
            };
            var c = new Vertex<string>
            {
                Value = "Dog"
            };
            var d = new Vertex<string>
            {
                Value = "Dog"
            };
            a.AddEdge(b);
            b.AddEdge(c);
            a.AddEdge(d);
            var graph = new Graph<string>();
            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            var dfsSearcher = new DepthFirstSearcher<string>();

            var result = dfsSearcher.Search(graph, a, s => s == "Dog");

            result.Should().Be(c);
        }
    }
}