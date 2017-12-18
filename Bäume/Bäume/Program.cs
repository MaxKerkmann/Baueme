using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bäume
{
    
        public class Node<T> //Klasse Knoten
        {
            private T value;        //Wert des Knoten

            private List<Node<T>> children;     //Liste der Kinder des Knoten
            private bool hasParent;     //Checked ob der Knoten Eltern hat

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
            public int ChildrenCount        //Gibt die Anzahl der Kinder eines Knotens zurück
            {
                get
                {
                    return this.children.Count;
                }
            }
            public void AddChild(Node<T> child)       //Fügt einen neuen Nachfolger hinzu
            {
                if (child == null)
                {
                    Console.WriteLine("Man kann nicht Nichts einfügen");
                }
                child.hasParent = true;
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
                for (int i = 0; i <= children.Length; i++)
                {
                    this.root.AddChild(children.root);
                }
            }
            public Node<T> Root     //Gibt die Wurzel zurück
            {
                get
                {
                    return this.root;

                }
            }
            private void DepthFirstSearch(Node<T> root)
            {
                if (this.root == null)
                {
                    return;
                }
                Console.WriteLine(root.value);
                Node<T> child = null;
                for (int i = 0; i < root.ChildrenCount; i++)
                {
                    child = root.GetChild(i);
                    DepthFirstSearch(child);
                }
            }

        }

        class programm
        {
            static void Main()
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

            }
        }
    }


