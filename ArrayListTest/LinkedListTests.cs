using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using DataStructures.LL;

namespace DataStructuresTest
{
    public class LinkedListTests
    {
        [TestCase(new int[] { 1, 2, 3}, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 0 }, 4, new int[] { 0, 4 })]
        [TestCase(new int[] { }, 4, new int[] { 4 })]
        [TestCase(new int[] { }, 0, new int[] { 0 })]
        public void AddTest(int[] actualArray, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3}, new int[] { 1, 2, 3, 1, 2, 3 })]
        [TestCase(new int[] { 0 }, new int[] { 4 }, new int[] { 0, 4 })]
        [TestCase(new int[] { }, new int[] { 4 }, new int[] { 4 })]
        public void AddTest(int[] actualArray, int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.Add(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, -12, new int[] { -12, 1, 2, 3, 4 })]
        [TestCase(new int[] {  }, 11, new int[] { 11 })]
        public void AddToStartTest(int[] actualArray, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.AddToStart(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 0 }, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 12, 0 ,-12 }, new int[] { 12, 0, -12, 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 11 }, new int[] { 11 })]
        public void AddToStartTest(int[] actualArray, int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.AddToStart(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3}, 1, 4, new int[] { 1, 4, 2, 3})]
        [TestCase(new int[] { 1, 2, 3}, 0, 4, new int[] { 4, 1, 2, 3})]
        [TestCase(new int[] { 1, 2, 3}, 3, 4, new int[] { 1, 2, 3, 4})]
        public void AddByIndex(int[] actualArray, int index, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(actualArray);
            actual.AddByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3 }, new int[] { 2, 3, 1, 2, 3, 4 })]
        [TestCase(new int[] { 0, 1 }, 1, new int[] { 5, 6, 7 }, new int[] { 0, 5, 6, 7, 1 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 2, new int[] { 20, 21, 22, 23 }, new int[] { 0, 1, 20, 21, 22, 23, 2, 3, 4, 5 })]
        public void AddByIndexTest(int[] actualArray, int index, int[] array, int[] exp)
        {
            LinkedList expected = new LinkedList(exp);
            LinkedList actual = new LinkedList(actualArray);
            actual.AddByIndex(index, array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3}, 1, 0, new int[] { 1, 0, 3})]
        [TestCase(new int[] { 1, 2, 3}, 0, 0, new int[] { 0, 2, 3})]
        [TestCase(new int[] { 1, 2, 3, 5, 8}, 4, 0, new int[] { 1, 2, 3, 5, 0})]
        public void ChangeByIndexTest(int[] actualArray, int index, int value, int[] expArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expArray);
            actual.ChangeByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3}, 1, 0)]
        [TestCase(new int[] { 1, 2, 3, -7, -7, 9}, -7, 3)]
        [TestCase(new int[] { 1, 2, 3}, 5, -1)]
        [TestCase(new int[] { 1, 1, 1}, 1, 0)]
        public void GetIndexTest(int[] array, int value, int expected)
        {
            LinkedList Array = new LinkedList(array);
            int actual = Array.GetIndex(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 5}, new int[] { 5, 3, 2, 1})]
        [TestCase(new int[] { 0, 1, 2, -5, 0}, new int[] { 0, -5, 2, 1, 0})]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void ReverseTest(int[] actualArray, int[] expArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expArray);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, -5}, 4)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, -5}, 0)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1}, 1)]
        [TestCase(new int[] { -4, -12, -5, -321, -2, -31, -3}, -2)]
        [TestCase(new int[] { -5, 12, 0, -3, 1, 10, -8, 15}, 15)]
        public void MaxTest(int[] actualArray, int expected)
        {
            LinkedList Array = new LinkedList(actualArray);
            int actual = Array.Max();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, -5 }, -5)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, -5 }, -5)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, 1)]
        [TestCase(new int[] { -4, -12, -5, -321, -2, -31, -3 }, -321)]
        public void MinTest(int[] actualArray, int expected)
        {
            LinkedList Array = new LinkedList(actualArray);
            int actual = Array.Min();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, -5 }, 4)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, -5 }, 0)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, 0)]
        [TestCase(new int[] { -4, -12, -5, -321, -2, -31, -3 }, 4)]
        public void IndexByMaxTest(int[] actualArray, int expected)
        {
            LinkedList Array = new LinkedList(actualArray);
            int actual = Array.IndexByMax();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3, 4, -5 }, 5)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, -5 }, 5)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, 0)]
        [TestCase(new int[] { -4, -12, -5, -321, -2, -31, -3 }, 3)]
        [TestCase(new int[] { -4, -12, -5, -3, -2, -31, -321 }, 6)]
        public void IndexByMinTest(int[] actualArray, int expected)
        {
            LinkedList Array = new LinkedList(actualArray);
            int actual = Array.IndexByMin();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4}, new int[] { 2, 3, 4})]
        [TestCase(new int[] { 1}, new int[] { })]
        [TestCase(new int[] { 0, 1, 2, 3, 4}, new int[] { 1, 2, 3, 4})]
        public void DeleteStartTest(int[] actualArray, int[] expArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expArray);
            actual.DeleteStart();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 3, 4 })]
        [TestCase(new int[] { 1, 0, 0, 0 }, 1, new int[] { 0, 0, 0})]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 0, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(new int[] { 0 }, 0, new int[] { 0 })]
        public void DeleteStartTest(int[] actualArray, int number, int[] expArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expArray);
            actual.DeleteStart(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        [TestCase(new int[] { 0, 1, 2, 3 }, new int[] { 0, 1, 2 })]
        public void DeleteTest(int[] actualArray, int[] expArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expArray);
            actual.Delete();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 0, 1, 2, 3 }, 1, new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 0, 1, 2, 3 }, 0, new int[] { 0, 1, 2, 3 })]
        public void DeleteTest(int[] actualArray, int number, int[] expArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expArray);
            actual.Delete(number);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3 }, 1, new int[] { 0, 2, 3 })]
        [TestCase(new int[] { 0, 1, 2, 3 }, 0, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 0, 1, 2, 3, -5, 12, 0, 5 }, 6, new int[] { 0, 1, 2, 3, -5, 12, 5 })]
        [TestCase(new int[] { 0, 1, 2, 3, -5, 12, 0, 5 }, 5, new int[] { 0, 1, 2, 3, -5, 0, 5 })]
        [TestCase(new int[] { 0, 1, 2, 3, -5, 12, 0, 5 }, 3, new int[] { 0, 1, 2, -5, 12, 0, 5 })]
        [TestCase(new int[] { 0, 1, 2, 3, -5, 12, 0, 5 }, 4, new int[] { 0, 1, 2, 3, 12, 0, 5 })]
        public void DeleteByIndexTest(int[] actualArray, int index, int[] expArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expArray);
            actual.DeleteByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 0, 1, 2, 3 }, 1, 2, new int[] { 0, 3 })]
        [TestCase(new int[] { 0, 1, 2, 3 }, 0, 0, new int[] { 0, 1, 2, 3 })]
        [TestCase(new int[] { 0, 1, 2, 3, -5, 12, 0, 5 }, 6, 2, new int[] { 0, 1, 2, 3, -5, 12 })]
        public void DeleteByIndexTest(int[] actualArray, int index, int numbers, int[] expArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expArray);
            actual.DeleteByIndex(index, numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4}, 1, new int[] { 2, 3, 4})]
        [TestCase(new int[] { 1, 2, 3, 4}, 3, new int[] { 1, 2, 4})]
        [TestCase(new int[] { 1, 2, 3, 4, 0}, 0, new int[] { 1, 2, 3, 4})]
        [TestCase(new int[] { 1, 2, -5, 4, -5}, -5, new int[] { 1, 2, 4, -5 })]
        [TestCase(new int[] { -5, 1, 0, 3, 5}, 0, new int[] { -5, 1, 3, 5 })]
        [TestCase(new int[] { -5, 0, 0, 3, 5}, 0, new int[] { -5, 0, 3, 5 })]
        public void DeleteValueTest(int[] actualArray, int value, int[] expArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expArray);
            actual.DeleteValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 1 }, 1, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 3 }, 3, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 0 }, 0, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, -5, 4, -5 }, -5, new int[] { 1, 2, 4 })]
        [TestCase(new int[] { -5, 1, 0, 3, 0, 5 }, 0, new int[] { -5, 1, 3, 5 })]
        [TestCase(new int[] { -5, 0, 0, 0, 0, 3, 5 }, 0, new int[] { -5, 3, 5 })]
        public void DeleteValuesTest(int[] actualArray, int value, int[] expArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expArray);
            actual.DeleteValues(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 1, 0, 2 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(new int[] { 4, 1, 2, 3, 0 }, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(new int[] { -5, 1, 0, 2, 16, -35, 0 }, new int[] { -35, -5, 0, 0, 1, 2, 16 })]
        public void SortTest(int[] actualArray, int[] expArray)
        {
            LinkedList actual = new LinkedList(actualArray);
            LinkedList expected = new LinkedList(expArray);
            actual.Sort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 1, 0, 2 }, new int[] { 3, 2, 1, 0 })]
        [TestCase(new int[] { 4, 1, 2, 3, 0 }, new int[] { 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { -5, 1, 0, 2, 16, -35, 0 }, new int[] { 16, 2, 1, 0, 0, -5, -35 })]
        public void SortDecreaseTest(int[] array, int[] exp)
        {
            LinkedList expected = new LinkedList(exp);
            LinkedList actual = new LinkedList(array);
            actual.SortDecrease();

            Assert.AreEqual(expected, actual);
        }
    }
}
