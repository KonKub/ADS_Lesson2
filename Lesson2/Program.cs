using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {

        public class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }
        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
        }

        public class DLList : ILinkedList
        {

            private Node _head;
            private Node _tail;
            private int Count=0;

            public int GetCount() // возвращает количество элементов в списке
            {
                return Count;
            }

            public void AddNode(int value)  // добавляет новый элемент списка
            {
                Node node = new Node { Value = value };
                Node temp = _head; // Сохраняем ссылку на первый элемент.
                _head = node;   // _head указывает на новый узел.
                _head.Next = temp; // Вставляем список позади первого элемента.
                if (Count == 0) // Если список был пуст, то head and tail должны указывать на новой узел.
                {
                    _tail = _head;
                }
                else
                {
                    temp.Prev = _head;
                }
                Count++;
            }

            public void AddNodeAfter(Node node, int value) // добавление после любого элемента
            {
                Node current = _head;

                while (current != null)
                {
                    if (current.Value == node.Value)
                    {
                        Node newnode = new Node { Value = value };
                        Node N = current.Next;
                        newnode.Prev = current;
                        current.Next = newnode;
                        if (N != null)
                        {
                            newnode.Next = N;
                            N.Prev = newnode;
                        }
                        Count++;
                        return;
                    }
                    current = current.Next;
                }
            }

            public void RemoveNode(int index) // удаляет элемент по порядковому номеру
            {
                Node previous = null;
                Node current = _head;
                int I=0;

                while (current != null)
                {
                    I++;
                    if (I==index)
                    {
                        if (previous != null)
                        {
                            previous.Next = current.Next;

                            if (current.Next == null)
                            {
                                _tail = previous;
                            }
                            else
                            {
                                current.Next.Prev = previous;
                            }
                            Count--;
                        }
                        else
                        {
                            _head = _head.Next;
                            Count--;
                            if (Count == 0)
                            {
                                _tail = null;
                            }
                            else
                            {
                                _head.Prev = null;
                            }
                        }
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }

            public void RemoveNode(Node node) // удаляет указанный элемент
            {
                Node previous = null;
                Node current = _head;

                while (current != null)
                {
                    if (current.Value == node.Value)
                    {
                        if (previous != null)
                        {
                            previous.Next = current.Next;

                            if (current.Next == null)
                            {
                                _tail = previous;
                            }
                            else
                            {
                                current.Next.Prev = previous;
                            }
                            Count--;
                        }
                        else
                        {
                            _head = _head.Next;
                            Count--;
                            if (Count == 0)
                            {
                                _tail = null;
                            }
                            else
                            {
                                _head.Prev = null;
                            }
                        }
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }

            public Node FindNode(int searchValue) // ищет элемент по его значению
            {
                Node current = _head;

                while (current != null)
                {
                    if (current.Value == searchValue)
                    {
                        return current;
                    }
                    current = current.Next;
                }
                return null;
            }

            public void Print()
            {
                Node current = _head;

                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Next;
                }
                Console.WriteLine("===================");
            }

            public void PrintBack()
            {
                Node current = _tail;

                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Prev;
                }
                Console.WriteLine("===================");
            }
        }


        static void Main(string[] args)
        {
            DLList L = new DLList();
            Node node = new Node { Value = 2};

            L.AddNode(1);
            L.AddNode(2);
            L.AddNode(3);
            L.AddNode(4);
            L.AddNode(5);
            L.AddNode(6);
            L.AddNodeAfter(node, 22);

            L.Print();
            L.PrintBack();
            L.RemoveNode(3);
            L.Print();
            L.PrintBack();

            Console.WriteLine("---");
            Console.ReadKey();
        }
    }
}
