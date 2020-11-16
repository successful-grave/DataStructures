﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LL
{
    public class LinkedList
    {
        public int Length { get; set; }
        private Node _root;

        public LinkedList()
        {
            Length = 0;
            _root = null;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
            Length = 1;
        }

        public LinkedList(int[] array)
        {
            if(array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;
                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        //добавление в начало
        public void AddToStart(int value)
        {
            Node tmp = _root;
            _root = new Node(value);
            _root.Next = tmp;
            Length++;
        }

        //добавление массива в начало
        public void AddToStart(int[] array)
        {
            Node tmp;
            Node current = _root;
            Length += array.Length;
            for(int i = array.Length-1; i >= 0; i--)
            {
                tmp = new Node(array[i]);
                current = tmp;
                current.Next = _root;
                _root = tmp;
            }
        }

        //добавление в конец
        public void Add(int value)
        {
            if (Length > 0)
            {
                Node current = _root;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new Node(value);
                Length++;
            }
            else
            {
                _root = new Node(value);
                Length = 1;
            }
        }

        //добавление массива в конец
        public void Add(int[] array)
        {
            int oldLength = Length;
            Node current = _root;
            if (Length > 0)
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }
                Length += array.Length;
                if (array.Length > 0)
                {
                    for (int i = oldLength; i < Length; i++)
                    {
                        int tmp = array[i - oldLength];
                        current.Next = new Node(tmp);
                        current = current.Next;
                    }
                }
            }
            else if (Length == 0 && array.Length > 0)
            {
                _root = new Node(array[0]);
                Length = array.Length;
                if (array.Length > 0)
                {
                    for (int i = 1; i < array.Length; i++)
                    {
                        current.Next = new Node(array[i]);
                        current = current.Next;
                    }
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //добавление по индексу
        public void AddByIndex(int index, int value)
        {
            if (index == 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
            }
            else
            {
                Node current = _root;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                Node tmp = current.Next;
                current.Next = new Node(value);
                current.Next.Next = tmp;
            }
            Length++;
        }

        //доступ по индексу
        public void ChangeByIndex(int index, int value)
        {
            if (index > 0 && Length > 0)
            {
                Node current = _root;
                int count = 0;
                while (count != (index-1))
                {
                    count++;
                }
                for (int i = 0; i < count; i++)
                {
                    current = current.Next;
                }
                current.Next = new Node(value);
            }
            else if(index == 0 && Length > 0)
            {
                Node current = _root;
                current = current.Next;
                _root = new Node(value);
                _root.Next = current;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //индекс по значению
        public int GetIndex(int value)
        {
            Node current = _root;
            int count = 0;
            while(current.Next != null)
            {
                if(current.Value == value)
                {
                    return count;
                }
                current = current.Next;
                count++;
            }
            return -1;
        }

        public void Reverse()
        {
            Node oldRoot = _root;
            Node tmp;
            while(oldRoot.Next != null)
            {
                tmp = oldRoot.Next;
                oldRoot.Next = oldRoot.Next.Next;
                tmp.Next = _root;
                _root = tmp;
            }
        }

        public int Max()
        {
            int max = _root.Value;
            Node current = _root;
            while(current.Next != null)
            {
                if(current.Value > max)
                {
                    max = current.Value;
                }
                current = current.Next;
            }
            return max;
        }

        public int this[int index]
        {
            get
            {
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            set
            {
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;
            if(Length != linkedList.Length)
            {
                return false;
            }
            Node tmp1 = _root;
            Node tmp2 = linkedList._root;
            for (int i = 1; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";

            if (_root != null)
            {
                Node tmp = _root;
                while (tmp != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;
                }
            }
            return s;
        }
    }
}