using System;
using System.Collections.Generic;

namespace Assignment_5
{
    /// <summary>
    /// Implements an undirected graph of "connections" between named people
    /// a la LinkedIn or Facebook.
    /// </summary>
    public class PersonGraph
    {
        /// <summary>
        /// Adds a new person (node) to the graph
        /// </summary>
        /// <param name="name">Name of the person</param>



        AdjListCell[] adj = new AdjListCell[100];


        List<string> nameArray = new List<string>();


        public class AdjListCell
        {

            public string name;
            public int nodeNumber;
            public int distance =0;
            public AdjListCell predecessor =null;

            public List<AdjListCell> next = new List<AdjListCell>();

        }



        public void AddPerson(string name)
        {



            nameArray.Add(name); //Add name to the array

            adj[nameArray.IndexOf(name)] = new AdjListCell();
            adj[nameArray.IndexOf(name)].name = name;
            adj[nameArray.IndexOf(name)].nodeNumber = nameArray.IndexOf(name);
        }

        /// <summary>
        /// Adds a new edge to the graph
        /// </summary>
        /// <param name="person1">Name of first person</param>
        /// <param name="person2">Name of second person</param>
        public void AddConnection(string person1, string person2)
        {


            if (!nameArray.Contains(person1))
            {
                AddPerson(person1);
            }

            if (!nameArray.Contains(person2))
            {
                AddPerson(person2);
            }



            adj[nameArray.IndexOf(person2)].next.Add(adj[nameArray.IndexOf(person1)]);
            adj[nameArray.IndexOf(person1)].next.Add(adj[nameArray.IndexOf(person2)]);
        }

        /// <summary>
        /// Returns the length of the shortest path between two people in the graph
        /// For example, the distance from a node to itself is 0, from a node to a
        /// neighbor is 1, etc.
        /// </summary>
        /// <param name="person1">Name of the first person</param>
        /// <param name="person2">Name of the second person</param>
        /// <returns>Length of the path</returns>
        public int Distance(string person1, string person2)
        {



            bool[] visited = new bool[100];

            if (!nameArray.Contains(person1) || !nameArray.Contains(person2))
            {
                return -1;
            }

            if (person1 == person2)
            {
                return 0;
            }



            Queue<AdjListCell> q = new Queue<AdjListCell>();
            q.Enqueue(adj[nameArray.IndexOf(person1)]);
            adj[nameArray.IndexOf(person1)].distance = 0;
            adj[nameArray.IndexOf(person1)].predecessor = null;
            visited[nameArray.IndexOf(person1)] = true;



            while (q.Count!=0)
            {
                AdjListCell node = q.Dequeue();
                
                foreach (AdjListCell c in node.next)
                {
                    if (visited[nameArray.IndexOf(c.name)] == false)
                    {
                        q.Enqueue(c);
                        c.distance = node.distance + 1;
                        c.predecessor = node;
                        //visited[nameArray.IndexOf(c.name)]=true;
                        //node = c;


                    }
                    visited[nameArray.IndexOf(c.name)] = true;
                    if (c.name == person2)
                    {
                        return c.distance;
                    }

                 

                }

            }
            return -1;


        }
    }
}