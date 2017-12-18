using System;
using System.Collections.Generic;

namespace Bäume
{
    
        public class Node<T> //Klasse Knoten
        {
            private T value;        //Wert des Knoten
            private List<Node<T>> children;     //Liste der Kinder des Knoten
       

            public Node(T value)        //Erstellt einen Knoten
            {
                if (value == null)
                {
                    Console.WriteLine("Man kann den Knoten nicht mit Nichts füllen");
                }
                this.value = value;
                this.children = new List<Node<T>>();
            }
            public void SetValue(T value)       //Setzt den Wert des Knotens
            {
                this.value = value;
            }
            public T GetValue()     //Gibt den Wert des Knoten zurück
            {
                return this.value;
            }
            public int ChildrenCount()        //Gibt die Anzahl der Kinder eines Knotens zurück
            {
                    return this.children.Count;
            }
            public void AddChild(Node<T> child)       //Fügt einen neuen Nachfolger hinzu
            {
                if (child == null)
                {
                    Console.WriteLine("Man kann nicht Nichts einfügen");
                }
               
                this.children.Add(child);
            }
            public Node<T> GetChild(int index)      //Gibt die Position des Kindes zurück
            {
                return this.children[index];
            }
        }
        public class Tree<T>
        {
            private Node<T> root;       //Erstellt die Wurzel des Baumes

            public Tree(T value)        //Erstellt den Baum mit einem Wert
            {
                if (value == null)
                {
                    Console.WriteLine("Der Baum kann nicht mit nichts befüllt werden");
                }
                this.root = new Node<T>(value);
            }
            public Tree(T value, params Tree<T>[] children)     //Erstellt den Baum mit seinen einzelnen Elementen
            : this(value)
            {
                for (int i = 0; i < children.Length; i++)
                {
                    root.AddChild(children[i].root);
                }
            }

            public Node<T> Root()     //Gibt die Wurzel zurück
            {
                    return this.root;
            }
            public void DepthFirstPrint(Node<T> root)
            {
                if (this.root == null)
                {
                    return;
                }
                Console.WriteLine(root.GetValue());
                Node<T> child = null;
                for (int i = 0; i < root.ChildrenCount(); i++)
                {
                    child = root.GetChild(i);
                    DepthFirstPrint(child);        
                }
            }

        public bool DepthFirstSearch(Node<T> root,T Search)
        {
            
            if (this.root == null)
            {
                return false;
            }
            
            if (root.GetValue().Equals(Search))
            {
                return true;
            }
            Node<T> child = null;
            for (int i = 0; i < root.ChildrenCount(); i++)
            {
                
                child = root.GetChild(i);
                if (DepthFirstSearch(child, Search))
                {
                    return true;
                }
            }
            return false;
        }


    }

    class Programm
        {
            static void Main(string[] args)
            {
                Tree<int> tree =        //Erstellt einen Beispielbaum

                new Tree<int>(7,

                new Tree<int>(19,

                new Tree<int>(1),

                new Tree<int>(12),

                new Tree<int>(31)),

                new Tree<int>(21),

                new Tree<int>(14,

                new Tree<int>(23),

                new Tree<int>(6)));

            tree.DepthFirstPrint(tree.Root());
            Console.WriteLine("Nach welchem Wert suchen sie im Baum ?");
            if (tree.DepthFirstSearch(tree.Root(), Convert.ToInt32(Console.ReadLine())))
            {
                Console.WriteLine("Der Wert ist im Baum vorhanden");
            }
            else
            {
                Console.WriteLine("Der Wert ist im Baum nicht vorhanden");
            }
            Console.ReadLine();
            }
        }
    }


