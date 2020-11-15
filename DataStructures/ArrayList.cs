using System;
using System.Linq;

namespace DataStructures
{
    public class ArrayList
    {
        public int Length { get; private set; }
        private int[] _array;
        private int _TrueLength
        {
            get
            {
                return _array.Length;
            }
        }

        public ArrayList()
        {
            _array = new int[9];
            Length = 0;
        }

        public ArrayList(int value)
        {
            _array = new int[9];
            _array[0] = value;
            Length = 1;
        }

        public ArrayList(int[] array)
        {
            _array = new int[(int)(array.Length * 1.33)];
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
            Length = array.Length;
        }

        //добавление в конец
        public void Add(int value)
        {
            if (_TrueLength <= Length)
            {
                IncreaseLength();
            }
            _array[Length] = value;
            Length++;
        }

        //добавление массива в конец
        public void Add(int[] arrayGet)
        {
            int startIndex = Length;
            int valuesIndex = 0;
            Length += arrayGet.Length;
            if (_TrueLength <= Length)
            {
                IncreaseLength(arrayGet.Length);
            }
            for (int i = startIndex; i < Length; i++)
            {
                _array[i] = arrayGet[valuesIndex];
                valuesIndex++;
            }
        }

        //добавление в начало
        public void AddToStart(int value)
        {
            if (Length <= _TrueLength)
            {
                IncreaseLength();
            }
            for (int i = Length + 1; i >= 1; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[0] = value;
            Length++;
            DecreaseLength();
        }

        //добавление массива в начало
        public void AddToStart(int[] array)
        {
            int startIndex = array.Length;
            Length += array.Length;
            if (_TrueLength <= Length)
            {
                IncreaseLength(array.Length);
            }
            for (int i = Length; i >= startIndex; i--)
            {
                _array[i] = _array[i - startIndex];
            }
            for (int i = 0; i < startIndex; i++)
            {
                _array[i] = array[i];
            }
        }

        //добавление по индексу
        public void AddToIndex(int index, int value)
        {
            if (index >= 0 && index < Length)
            {
                if (Length <= _TrueLength)
                {
                    IncreaseLength();
                }
                for (int i = Length + 1; i > index; i--)
                {
                    _array[i] = _array[i - 1];
                }
                _array[index] = value;
                Length++;
                DecreaseLength();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //добавление массива по индексу
        public void AddToIndex(int index, int[] array)
        {
            int valuesIndex = 0;
            int lastIndex = index + array.Length;
            Length = Length + array.Length;

            if (_TrueLength <= Length)
            {
                IncreaseLength(array.Length);
            }

            for (int i = Length - 1; i >= lastIndex; i--)
            {
                _array[i] = _array[i - lastIndex + index];
            }

            for (int i = index; i < lastIndex; i++)
            {
                _array[i] = array[valuesIndex];
                valuesIndex++;
            }
        }

        //индекс по значению
        public int GetIndex(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        //изменение по индексу
        public void ChangeByIndex(int index, int value)
        {
            if (index >= 0 && index < Length)
            {
                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //реверс
        public void Reverse()
        {
            for (int i = 0; i < Length / 2; i++)
            {
                int a = _array[i];
                _array[i] = _array[Length - i - 1];
                _array[Length - i - 1] = a;
            }
        }

        //поиск значения максимального элемента
        public int Max()
        {
            int max = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }

        //поиск значения минимального элемента
        public int Min()
        {
            int min = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }

        //поиск индекса минимального элемента
        public int IndexByMin()
        {
            int indexMin = 0;
            int min = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] < min)
                {
                    indexMin = i;
                }
            }
            return indexMin;
        }

        //поиск индекса максимального элемента
        public int IndexByMax()
        {
            int indexMax = 0;
            int max = _array[0];
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    indexMax = i;
                }
            }
            return indexMax;
        }

        //сортировка по возрастанию
        public void Sort()
        {
            for (int i = 1; i < Length; i++)
            {
                int j;
                int buf = _array[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (_array[j] < buf)
                        break;

                    _array[j + 1] = _array[j];
                }
                _array[j + 1] = buf;
            }
        }

        //сортировка по убыванию
        public void SortDecrease()
        {
            for (int i = 1; i < Length; i++)
            {
                int j;
                int buf = _array[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (_array[j] > buf)
                        break;

                    _array[j + 1] = _array[j];
                }
                _array[j + 1] = buf;
            }
        }

        //удаление одного элемента из конца
        public void Delete()
        {
            Length--;
            DecreaseLength();
        }

        //удаление N элементов из конца
        public void Delete(int number)
        {
            Length -= number;
        }

        //удаление одного элемента из начала
        public void DeleteStart()
        {
            for (int i = 0; i < Length; i++)
            {
                _array[i] = _array[i + 1];
            }
            Length--;
            DecreaseLength();
        }

        //удаление N элементов из начала
        public void DeleteStart(int value)
        {
            for (int i = value; i < Length; i++)
            {
                _array[i - value] = _array[i];
            }
            DecreaseLength();
            Length -= value;
        }

        //удаление элемента по индексу
        public void DeleteByIndex(int index)
        {
            if (index >= 0 || index < Length)
            {
                for (int i = index; i < Length; i++)
                {
                    if (i + 1 < Length)
                    {
                        _array[i] = _array[i + 1];
                    }
                }
                Length--;
                DecreaseLength();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        //удаление по индексу N элементов
        public void DeleteByIndex(int index, int amount)
        {
            for (int i = index; i < Length; i++)
            {
                if ((i + amount) < Length)
                {
                    _array[i] = _array[i + amount];
                }
            }
            Length -= amount;
        }

        //удаление по значению первого
        public void DeleteValue(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    for (int j = i; j < Length; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    Length--;
                    break;
                }
            }
            DecreaseLength();
        }

        //удаление всех значений
        public void DeleteValues(int value)
        {
            for (int i = 0; i < Length; i++)
            {
                if (_array[i] == value)
                {
                    for (int j = i; j < Length; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    i -= 1;
                    Length--;
                }
            }
            DecreaseLength();
        }

        public int this[int i]
        {
            get
            {
                if (i >= Length || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[i];
            }
            set
            {
                if (i >= Length || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[i] = value;
            }
        }

        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;
            if (Length != arrayList.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            return string.Join(";", _array.Take(Length));
        }

        //изменение размера массива
        private void IncreaseLength(int number = 1)
        {
            int newLength = _TrueLength;
            while (newLength <= Length + number)
            {
                newLength = (int)(newLength * 1.33 + 1);
            }
            int[] newArray = new int[newLength];
            Array.Copy(_array, newArray, _TrueLength);
            _array = newArray;
        }

        //уменьшение размера массива
        private void DecreaseLength(int number = 1)
        {
            int newLength = _TrueLength;
            int[] newArray = new int[newLength];
            if (Length > 0 && _TrueLength / Length >= 2)
            {
                newLength = newLength * 2 / 3 + number;
                Array.Copy(_array, newArray, Length);
                _array = newArray;
            }
        }
    }
}
