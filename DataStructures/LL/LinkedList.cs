using System;
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
        public void Add(int[] array)//подумать как сделать через один цикл
        {
            if(Length == 0 && array.Length == 0)
            {
                _root = null;
                Length = 0;
            }
            else if(Length == 0 && array.Length > 0)
            {
                _root = new Node(array[0]);
                Node current = _root;
                for(int i = 1; i < array.Length; i++)
                {
                    current = new Node(array[i]);
                    current = current.Next;
                }
                Length = array.Length;
            }
            else
            {
                Node current = _root;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                int oldLength = Length;
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

        //реверс
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

        //поиск максимального значения
        public int Max()
        {
            int max = _root.Value;
            Node current = _root;
            while (current != null)
            {
                if (current.Value > max)
                {
                    max = current.Value;
                }
                current = current.Next;
            }
            return max;
        }

        //поиск минимального значения
        public int Min()
        {
            int min = _root.Value;
            Node current = _root;
            while (current != null)
            {
                if (current.Value < min)
                {
                    min = current.Value;
                }
                current = current.Next;
            }
            return min;
        }

        //поиск индекса максимального значения
        public int IndexByMax()
        {
            int max = _root.Value;
            int count = 0;
            Node current = _root;
            while (current != null)
            {
                if (current.Value > max)
                {
                    max = current.Value;
                }
                current = current.Next;
            }
            current = _root;
            while(current != null)
            {
                if(max == current.Value)
                {
                    break;
                }
                count++;
                current = current.Next;
            }
            return count;
        }

        //поиск индекса минимального элемента
        public int IndexByMin()
        {
            int min = _root.Value;
            int count = 0;
            Node current = _root;
            while (current != null)
            {
                if (current.Value < min)
                {
                    min = current.Value;
                }
                current = current.Next;
            }
            current = _root;
            while (current != null)
            {
                if (min == current.Value)
                {
                    break;
                }
                count++;
                current = current.Next;
            }
            return count;
        }
        
        //удаление из начала одного элемента
        public void DeleteStart()
        {
            if(Length > 0)
            {
                _root = _root.Next;
                Length--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //удаление из начала N элемента
        public void DeleteStart(int number)
        {
            if(Length > number)
            {
                for(int i = 0; i < number; i++)
                {
                    _root = _root.Next;
                }
                Length -= number;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //удаление из конца одного элемента
        public void Delete()
        {
            if(Length > 0)
            {
                Node current = _root;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
                Length--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //удаление из конца N элементов
        public void Delete(int number)
        {
            if(Length > number)
            {
                if(number > 0)
                {
                    Node current = _root;
                    int count = 0;
                    while (current != null)
                    {
                        current = current.Next;
                        count++;
                    }
                    current = _root;
                    for (int i = 0; i < (count - number); i++)
                    {
                        current = current.Next;
                    }
                    Length -= number;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //удалению по индексу одного элемента
        public void DeleteByIndex(int index)
        {
            if(index > 0)
            {
                Node current = _root;
                Node tmp = current;
                //for (int i = 1; i < index; i++)
                //{
                //    _root.Next = current.Next;
                //}
                //_root.Next = current.Next.Next;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                    tmp = current.Next;
                }
                current  = tmp.Next;

            }
            else if(index == 0)
            {
                _root = _root.Next;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            Length--;
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
