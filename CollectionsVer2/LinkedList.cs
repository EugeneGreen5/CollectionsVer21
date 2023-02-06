using System.Collections;
using System.Collections.Generic;


#nullable enable
namespace Collections
{
  public class LinkedList<T> : IEnumerable<T>, IEnumerable
  {
    private LinkedList<
    #nullable disable
    T>.Node<
    #nullable enable
    T> head;
    private LinkedList<
    #nullable disable
    T>.Node<
    #nullable enable
    T> tail;
    private int counter;

    public void Add(T data)
    {
      LinkedList<T>.Node<T> node = new LinkedList<T>.Node<T>(data);
      if (this.head == null)
        this.head = node;
      else
        this.tail.Next = node;
      this.tail = node;
      ++this.counter;
    }

    public void AppendFirst(T data)
    {
      LinkedList<T>.Node<T> node = new LinkedList<T>.Node<T>(data);
      node.Next = this.head;
      this.head = node;
      if (this.counter == 0)
        this.tail = node;
      ++this.counter;
    }

    public bool Remove(T data)
    {
      LinkedList<T>.Node<T> node1 = this.head;
      LinkedList<T>.Node<T> node2 = (LinkedList<T>.Node<T>) null;
      if (!this.Contains(data))
        return false;
      for (; node1 != null; node1 = node1.Next)
      {
        if (node1.Data.Equals((object) data))
        {
          if (node2 != null)
          {
            node2.Next = node1.Next;
            if (node1.Next == null)
              this.tail = node2;
          }
          else
          {
            this.head = this.head.Next;
            if (this.head == null)
              this.tail = (LinkedList<T>.Node<T>) null;
          }
          --this.counter;
          return true;
        }
        node2 = node1;
      }
      return false;
    }

    public int Counter => this.counter;

    public bool IsEmpty => this.counter == 0;

    public void Clear()
    {
      this.head = (LinkedList<T>.Node<T>) null;
      this.tail = (LinkedList<T>.Node<T>) null;
      this.counter = 0;
    }

    public bool Contains(T data)
    {
      for (LinkedList<T>.Node<T> node = this.head; node != null; node = node.Next)
      {
        if (node.Data.Equals((object) data))
          return true;
      }
      return false;
    }

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) this).GetEnumerator();

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      for (LinkedList<T>.Node<T> current = this.head; current != null; current = current.Next)
        yield return current.Data;
    }

    private class Node<T>
    {
      public Node(T data) => this.Data = data;

      public T Data { get; set; }

      public LinkedList<
      #nullable disable
      T>.Node<
      #nullable enable
      T> Next { get; set; }
    }
  }
}
