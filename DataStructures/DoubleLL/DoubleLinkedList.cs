using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DoubleLL
{
    public class DoubleLinkedList
    {
        private DNode _root;
        private DNode _end;
        public int Length { get; private set; }

        public DoubleLinkedList()
        {
            _root = null;
            _end = null;
            Length = 0;
        }

        public DoubleLinkedList(int value)
        {
            _root = new DNode(value);
            _end = _root;
            Length = 1;
        }

        public DoubleLinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new DNode(array[0]);
                DNode tmp = _root;
                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new DNode(array[i]);
                    tmp.Next.Previous = tmp;
                    tmp = tmp.Next;
                }
                _end = tmp;
                Length = array.Length;
            }
            else
            {
                _root = null;
                _end = null;
                Length = 0;
            }
        }

        //добавление в конец
        public void Add(int value)
        {
            if (Length == 0)
            {
                _root = new DNode(value);
                _end = _root;
                Length = 1;
            }
            else
            {
                _end.Next = new DNode(value);
                _end.Next.Previous = _end;
                _end = _end.Next;
                Length++;
            }
        }

        //добавление массива в конец
        public void Add(int[] array)
        {
            if (Length == 0)
            {
                if (array.Length != 0)
                {
                    _root = new DNode(array[0]);
                    DNode tmp = _root;
                    for (int i = 1; i < array.Length; i++)
                    {
                        tmp.Next = new DNode(array[i]);
                        tmp.Next.Previous = tmp;
                        tmp = tmp.Next;
                    }
                    _end = tmp;
                    Length = array.Length;
                }
                else
                {
                    _root = null;
                    _end = null;
                    Length = 0;
                }
            }
            else
            {
                if (array.Length != 0)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        _end.Next = new DNode(array[i]);
                        _end.Next.Previous = _end;
                        _end = _end.Next;
                    }
                    Length += array.Length;
                }
            }
        }

        //добавление в начало
        public void AddToStart(int value)
        {
            if (Length == 0)
            {
                _root = new DNode(value);
                _end = _root;
                Length = 1;
            }
            else
            {
                _root.Previous = new DNode(value);
                _root.Previous.Next = _root;
                _root = _root.Previous;
                Length++;
            }
        }

        //добавление массива в начало
        public void AddToStart(int[] array)
        {
            if (Length == 0)
            {
                if (array.Length != 0)
                {
                    _root = new DNode(array[0]);
                    DNode tmp = _root;
                    for (int i = 1; i < array.Length; i++)
                    {
                        tmp.Next = new DNode(array[i]);
                        tmp.Next.Previous = tmp;
                        tmp = tmp.Next;
                    }
                    _end = tmp;
                    Length = array.Length;
                }
                else
                {
                    _root = null;
                    _end = null;
                    Length = 0;
                }
            }
            else
            {
                if (array.Length != 0)
                {
                    DNode tmp = new DNode(array[0]);
                    DNode b = tmp;
                    for (int i = 1; i < array.Length; i++)
                    {
                        tmp.Next = new DNode(array[i]);
                        tmp.Next.Previous = tmp;
                        tmp = tmp.Next;
                    }
                    tmp.Next = _root;
                    _root.Previous = tmp;
                    _root = b;
                    Length += array.Length;
                }
            }
        }

        //Добавление значения по индексу
        public void AddByIndex(int index, int value)
        {
            if (index >= 0)
            {
                if (Length == 0 || index >= Length)
                {
                    Add(value);
                }
                else
                {
                    if (index == 0)
                    {
                        AddToStart(value);
                    }
                    else
                    {
                        if (index <= Length / 2)
                        {
                            DNode tmp = _root;
                            for (int i = 1; i < index; i++)
                            {
                                tmp = tmp.Next;
                            }
                            DNode tmp2 = tmp.Next;
                            tmp.Next = new DNode(value);
                            tmp.Next.Previous = tmp;
                            tmp = tmp.Next;
                            tmp.Next = tmp2;
                            tmp2.Previous = tmp;
                            Length++;
                        }
                        else
                        {
                            DNode tmp = _end;
                            for (int i = Length - 1; i > index; i--)
                            {
                                tmp = tmp.Previous;
                            }
                            DNode tmp2 = tmp.Previous;
                            tmp.Previous = new DNode(value);
                            tmp.Previous.Next = tmp;
                            tmp = tmp.Previous;
                            tmp.Previous = tmp2;
                            tmp2.Next = tmp;
                            Length++;
                        }
                    }
                }
            }
        }

        //добавление массива по индексу
        public void AddByIndex(int index, int[] array)
        {
            if (index >= 0)
            {
                if (Length == 0 || index >= Length)
                {
                    Add(array);
                }
                else
                {
                    if (index == 0)
                    {
                        AddToStart(array);
                    }
                    else
                    {
                        if (index <= Length / 2)
                        {
                            DNode tmp = _root;
                            for (int i = 1; i < index; i++)
                            {
                                tmp = tmp.Next;
                            }
                            DNode b = tmp.Next;
                            for (int i = 0; i < array.Length; i++)
                            {
                                tmp.Next = new DNode(array[i]);
                                tmp.Next.Previous = tmp;
                                tmp = tmp.Next;
                            }
                            tmp.Next = b;
                            b.Previous = tmp;
                            Length += array.Length;
                        }
                        else
                        {
                            DNode tmp = _end;
                            for (int i = Length - 1; i > index; i--)
                            {
                                tmp = tmp.Previous;
                            }
                            DNode b = tmp.Previous;
                            for (int i = array.Length - 1; i >= 0; i--)
                            {
                                tmp.Previous = new DNode(array[i]);
                                tmp.Previous.Next = tmp;
                                tmp = tmp.Previous;
                            }
                            tmp.Previous = b;
                            b.Next = tmp;
                            Length += array.Length;
                        }
                    }
                }
            }
        }

        //удаление последнего элемента
        //удаление нескольких элемента из конца
        public void Delete(int number = 1)
        {
            if(Length < number)
            {
                throw new IndexOutOfRangeException();
            }
            else if(number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (Length > 0 && Length - number > 0)
            {
                for (int i = Length; i > Length - number; i--)
                {
                    _end = _end.Previous;
                }
                _end.Next = null;
                Length -= number;
            }
            else
            {
                _root = null;
                _end = null;
                Length = 0;
            }
        }

        //Удаление из начала одного элемента
        //Удаление из начала нескольких элементов
        public void DeleteStart(int number = 1)
        {
            if (Length < number)
            {
                throw new IndexOutOfRangeException();
            }
            else if (number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(Length > 0 && Length - number > 0)
            {
                for (int i = 0; i < number; i++)
                {
                    _root = _root.Next;
                }
                _root.Previous = null;
                Length -= number;
            }
            else
            {
                _root = null;
                _end = null;
                Length = 0;
            }
        }

        //удаление по индексу одного элемента
        //удаление по индексу нескольких элементов
        public void DeleteByIndex(int index, int number = 1)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (Length < number || number < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (index == 0)
            {
                DeleteStart(number);
            }
            else if(index == Length-1 || index + number == Length)
            {
                Delete(number);
            }
            else
            {
                DNode current = GetNodeByIndex(index);
                for (int i = 0; i < number; i++)
                {
                    current.Next.Previous = current.Previous;
                    current.Previous.Next = current.Next;
                    current = current.Next;
                }
                Length -= number;
            }            
        }

        //удаление по значению первого
        public void DeleteValue(int value)
        {
            if (Length > 0 &&_root != null)
            {
                DNode current = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        DeleteByIndex(i);
                        break;
                    }
                    current = current.Next;
                }
            }
        }

        //удаление по значению всех
        public void DeleteValues(int value)
        {
            if (Length > 0 && _root != null)
            {
                DNode current = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        DeleteByIndex(i);
                        i--;
                    }
                    current = current.Next;
                }
            }
        }

        //Получение индекса по значению
        public int GetIndex(int value)
        {
            if (Length > 0 && _root != null)
            {
                DNode current = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        return i;
                    }
                    current = current.Next;
                }
            }
            return -1;
        }

        //Изменение по индексу
        public void ChangeByIndex(int index, int value)
        {
            if (Length > 0 && _root != null)
            {
                DNode current = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (i == index)
                    {
                        current.Value = value;
                    }
                    current = current.Next;
                }
            }
        }

        //поиск максимального элемента
        public int Max()
        {
            DNode current = _root;
            int max = _root.Value;
            if (Length > 0 && _root != null)
            {
                for (int i = 1; i < Length; i++)
                {
                    current = current.Next;
                    if (current.Value > max)
                    {
                        max = current.Value;
                    }
                }
            }
            return max;
        }

        //поиск минимального элемента
        public int Min()
        {
            DNode current = _root;
            int min = _root.Value;
            if (Length > 0 && _root != null)
            {
                for (int i = 1; i < Length; i++)
                {
                    current = current.Next;
                    if (current.Value < min)
                    {
                        min = current.Value;
                    }
                }
            }
            return min;
        }

        //поиск индекса максимального элемента
        public int IndexByMax()
        {
            DNode current = _root;
            int max = _root.Value;
            int indexMax = 0;
            if (Length > 0 && _root != null)
            {
                for (int i = 1; i < Length; i++)
                {
                    current = current.Next;
                    if (current.Value > max)
                    {
                        max = current.Value;
                        indexMax = i;
                    }
                }
            }
            return indexMax;
        }

        //поиск индекса минимального элемента
        public int IndexByMin()
        {
            DNode current = _root;
            int min = _root.Value;
            int indexMin = 0;
            if (Length > 0 && _root != null)
            {
                for (int i = 1; i < Length; i++)
                {
                    current = current.Next;
                    if (current.Value < min)
                    {
                        min = current.Value;
                        indexMin = i;
                    }
                }
            }
            return indexMin;
        }

        //реверс
        public void Reverse()
        {
            DNode current = _root;
            DNode tmp;
            if (_root != null && _root.Next != null)
            {
                while (current != null)
                {
                    tmp = current.Next;
                    current.Next = current.Previous;
                    current.Previous = tmp;
                    current = current.Previous;
                }
                tmp = _root;
                _root = _end;
                _end = tmp;
            }
        }

        //сортировка по возрастанию
        public void Sort()
        {
            DNode rootNext = _root.Next;
            DNode tmp;
            DNode current;
            if (_root != null && _root.Next != null)
            {
                while (rootNext.Next != null)
                {
                    tmp = rootNext;
                    rootNext = rootNext.Next;
                    if (tmp.Previous != null)
                    {
                        tmp.Previous.Next = tmp.Next;
                    }
                    tmp.Next.Previous = tmp.Previous;
                    current = _root;
                    while (current.Next != null && current.Next.Value < tmp.Value)
                    {
                        current = current.Next;
                    }
                    tmp.Next = current.Next;
                    tmp.Previous = current;
                    if (tmp.Next != null)
                    {
                        tmp.Next.Previous = tmp;
                    }
                    current.Next = tmp;
                }
                _end = rootNext;
                if (_root.Value > _root.Next.Value)
                {
                    tmp = _root;
                    _root = tmp.Next;
                    _root.Previous = null;
                    current = _root;
                    while (current.Next != null && current.Next.Value < tmp.Value)
                    {
                        current = current.Next;
                    }
                    tmp.Next = current.Next;
                    tmp.Previous = current;
                    if (tmp.Next != null)
                    {
                        tmp.Next.Previous = tmp;
                    }
                    current.Next = tmp;
                    if (tmp.Next == null)
                    {
                        _end = tmp;
                    }
                }
            }
        }

        //сортировка по уменьшению
        public void SortDecrease()
        {
            DNode rootNext = _root.Next;
            DNode tmp;
            DNode current;
            if (_root != null && _root.Next != null)
            {
                while (rootNext.Next != null)
                {
                    tmp = rootNext;
                    rootNext = rootNext.Next;
                    if (tmp.Previous != null)
                    {
                        tmp.Previous.Next = tmp.Next;
                    }
                    tmp.Next.Previous = tmp.Previous;
                    current = _root;
                    while (current.Next != null && current.Next.Value > tmp.Value)
                    {
                        current = current.Next;
                    }
                    tmp.Next = current.Next;
                    tmp.Previous = current;
                    if (tmp.Next != null)
                    {
                        tmp.Next.Previous = tmp;
                    }
                    current.Next = tmp;
                }
                _end = rootNext;
                if (_root.Value < _root.Next.Value)
                {
                    tmp = _root;
                    _root = tmp.Next;
                    _root.Previous = null;
                    current = _root;
                    while (current.Next != null && current.Next.Value > tmp.Value)
                    {
                        current = current.Next;
                    }
                    tmp.Next = current.Next;
                    tmp.Previous = current;
                    if (tmp.Next != null)
                    {
                        tmp.Next.Previous = tmp;
                    }
                    current.Next = tmp;
                    if (tmp.Next == null)
                    {
                        _end = tmp;
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            DoubleLinkedList doubleLinkedList = (DoubleLinkedList)obj;

            if (Length != doubleLinkedList.Length)
            {
                return false;
            }

            DNode tmp1 = _root;
            DNode tmp2 = doubleLinkedList._root;

            for (int i = 0; i < Length; i++)
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

            DNode tmp = _root;
            for (int i = 0; i < Length; i++)
            {
                s += tmp.Value + ";";
                tmp = tmp.Next;
            }
            return s;
        }

        private DNode GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }
            DNode current;

            if (index < Length / 2)
            {
                current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
            }
            else
            {
                current = _end;

                for (int i = Length - 1; i > index; i--)
                {
                    current = current.Previous;
                }
            }
            return current;
        }
    }
}