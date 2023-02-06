using System;
using System.Collections.Generic;


#nullable enable
namespace Collections
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Проверка 2-у связного списка
            // Создание и добавление элементов
            DoublyLinkedList<string> doublyLinkedList = new DoublyLinkedList<string>();
            doublyLinkedList.Add("Bob");
            doublyLinkedList.Add("Bill");
            doublyLinkedList.Add("Tom");
            doublyLinkedList.AppendFirst("Kate");
            // Вывод элементов списка
            foreach (string str in doublyLinkedList)
                Console.WriteLine(str);
            Console.WriteLine();
            
            // Удаление элемента
            doublyLinkedList.Remove("Bill");
            
            // Проверка, есть ли элемент в списке
            Console.WriteLine(doublyLinkedList.Contains("Bob") ? "Bob присутствует" : "Bob отсутствует");
            Console.WriteLine();
            foreach (string str in doublyLinkedList.BackEnumerator())
                Console.WriteLine(str);
            Console.WriteLine();
            foreach (string str in  doublyLinkedList)
                Console.WriteLine(str);
        }
    }
}