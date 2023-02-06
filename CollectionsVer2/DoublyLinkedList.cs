using System.Collections;
using System.Collections.Generic;


#nullable enable
namespace Collections
{
  public class DoublyLinkedList<T> : IEnumerable<T>, IEnumerable
  {
    private DoublyLinkedList<T>.DoubleNode<T> head;
    private DoublyLinkedList<T>.DoubleNode<T> tail;
    private int counter;

    public void Add(T data)
    {
      DoublyLinkedList<T>.DoubleNode<T> doubleNode = new DoublyLinkedList<T>.DoubleNode<T>(data);
      if (this.head == null)
      {
        this.head = doubleNode;
      }
      else
      {
        this.tail.Next = doubleNode;
        doubleNode.Previous = this.tail;
      }
      this.tail = doubleNode;
      ++this.counter;
    }

    public void AppendFirst(T data)
    {
      DoublyLinkedList<T>.DoubleNode<T> doubleNode = new DoublyLinkedList<T>.DoubleNode<T>(data);
      doubleNode.Next = this.head;
      this.head.Previous = doubleNode;
      this.head = doubleNode;
      if (this.counter == 0)
        this.tail = doubleNode;
      ++this.counter;
    }

    public bool Remove(T data)
    {
      DoublyLinkedList<T>.DoubleNode<T> doubleNode1 = this.head;
      DoublyLinkedList<T>.DoubleNode<T> doubleNode2 = (DoublyLinkedList<T>.DoubleNode<T>) null;
      for (; doubleNode1 != null; doubleNode1 = doubleNode1.Next)
      {
        if (doubleNode1.Data.Equals((object) data))
        {
          if (doubleNode2 != null)
          {
            doubleNode2.Next = doubleNode1.Next;
            doubleNode1.Next.Previous = doubleNode1.Previous;
            if (doubleNode1.Next == null)
              this.tail = doubleNode2;
          }
          else
          {
            this.head = this.head.Next;
            if (this.head == null)
              this.tail = (DoublyLinkedList<T>.DoubleNode<T>) null;
          }
          --this.counter;
          return true;
        }
        doubleNode2 = doubleNode1;
      }
      return false;
    }

    public int Counter => this.counter;

    public bool isEmpty => this.counter == 0;

    public void Clear()
    {
      this.head = (DoublyLinkedList<T>.DoubleNode<T>) null;
      this.tail = (DoublyLinkedList<T>.DoubleNode<T>) null;
      this.counter = 0;
    }

    public bool Contains(T data)
    {
      for (DoublyLinkedList<T>.DoubleNode<T> doubleNode = this.head; doubleNode != null; doubleNode = doubleNode.Next)
      {
        if (doubleNode.Data.Equals((object) data))
          return true;
      }
      return false;
    }

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) this).GetEnumerator();

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      for (DoubleNode<T> current = this.head; current != null; current = current.Next)
        yield return current.Data;
    }

    public IEnumerable<T> BackEnumerator()
    {
      for (DoubleNode<T> current = this.tail; current != null; current = current.Previous)
        yield return current.Data;
    }

    public class DoubleNode<T>
    {
      public DoubleNode(T data) => this.Data = data;

      public T Data { get; set; }

      public DoublyLinkedList<T>.DoubleNode<T> Previous { get; set; }

      public DoublyLinkedList<T>.DoubleNode<T> Next { get; set; }
    }
  }
}