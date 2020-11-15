using NUnit.Framework;
using DataStructures;

namespace ArrayListTests
{
    public class Tests
    {
        [TestCase(0)]
        public void ConstructorTest(int expected)
        {
            ArrayList Array = new ArrayList();
            int actual = Array.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(4659, 1)]
        [TestCase(-864, 1)]
        [TestCase(4, 1)]
        public void ConstructorTest(int value, int expected)
        {
            ArrayList Array = new ArrayList(value);
            int actual = Array.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2 }, 3)]
        [TestCase(new int[] { 0, 1, 2, 0 }, 4)]
        [TestCase(new int[] { 0 }, 1)]
        public void ConstructorTest(int[] value, int expected)
        {
            ArrayList Array = new ArrayList(value);
            int actual = Array.Length;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1 }, 2, new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 0, new int[] { 0, 1, 2, 3, 4, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3 }, -2, new int[] { 0, 1, 2, 3, -2 })]
        public void AddTest(int[] array, int value, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1 }, new int[] { 2, 3 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, new int[] { 5, 6, 7 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { }, new int[] { 20, 21, 22, 23 }, new int[] { 20, 21, 22, 23 })]
        public void AddTest(int[] actualArray, int[] array, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(actualArray);
            actual.Add(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1 }, 2, new int[] { 2, 0, 1 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 2, new int[] { 2, 0, 1, 2, 3, 4 })]
        [TestCase(new int[] {  }, 27, new int[] { 27 })]
        public void AddToStartTest(int[] actualArray, int array, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddToStart(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1 }, new int[] { 2, 3 }, new int[] { 2, 3, 0, 1 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, new int[] { 5, 6, 7 }, new int[] { 5, 6, 7, 0, 1, 2, 3, 4 })]
        [TestCase(new int[] {  }, new int[] { 20, 21, 22, 23 }, new int[] { 20, 21, 22, 23 })]
        public void AddToStartTest(int[] actualArray, int[] array, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddToStart(array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 5, new int[] { 5, 1, 2, 3, 4 })]
        [TestCase(new int[] { 0, 1 }, 1, 2, new int[] { 0, 2, 1 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 4, 2, new int[] { 0, 1, 2, 3, 2, 4 })]
        public void AddToIndexTest(int[] actualArray, int index, int value, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddToIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3 }, new int[] { 2, 3, 1, 2, 3, 4 })]
        [TestCase(new int[] { 0, 1 }, 1, new int[] { 5, 6, 7 }, new int[] { 0, 5, 6, 7, 1 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 2, new int[] { 20, 21, 22, 23 }, new int[] { 0, 1, 20, 21, 22, 23, 2, 3, 4, 5 })]
        public void AddToIndexTest(int[] actualArray, int index, int[] array, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(actualArray);
            actual.AddToIndex(index, array);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 0 }, new int[] { 0, 1, 2, 3, 4 })]
        public void DeleteTest(int[] array, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.Delete();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 4, new int[] { 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5 }, 3, new int[] { 0, 1, 2 })]
        public void DeleteTest(int[] array, int numbers, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.Delete(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        public void DeleteStartTest(int[] array, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.DeleteStart();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, new int[] { 3, 4 })]
        [TestCase(new int[] { 0, 1, 2 }, 1, new int[] { 1, 2 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 0, new int[] { 0, 1, 2, 3, 4, 5, 6 })]
        public void DeleteStartTest(int[] array, int numbers, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.DeleteStart(numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0, new int[] { 2, 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 3, new int[] { 0, 1, 2, 4 })]
        [TestCase(new int[] { 0, 1 }, 1, new int[] { 0 })]
        public void DeleteByIndexTest(int[] array, int index, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.DeleteByIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 2, new int[] { 3, 4 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 2, 3, new int[] { 0, 1 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6 }, 0, 5, new int[] { 5, 6 })]
        public void DeleteByIndexTest(int[] array, int index, int numbers, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.DeleteByIndex(index, numbers);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 1, 0)]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 3, 3)]
        [TestCase(new int[] { 0, -2, -4, 0, 9 }, 2, -1)]
        public void GetIndexTest(int[] array, int value, int expected)
        {
            ArrayList Array = new ArrayList(array);
            int actual = Array.GetIndex(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, 0, -7, new int[] { -7, 1, 2, 3 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, 3, -7, new int[] { 0, 1, 2, -7, 4 })]
        [TestCase(new int[] { 0 }, 0, 100, new int[] { 100 })]
        public void ChangeByIndexTest(int[] array, int index, int value, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.ChangeByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, new int[] { 3, 2, 1, 0 })]
        [TestCase(new int[] { 0, 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { -5, 4, 4, -3, 1, 0}, new int[] { 0, 1, -3, 4, 4, -5 })]
        public void ReverseTest(int[] array, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, 3)]
        [TestCase(new int[] { 0, 1, 4, 3, 4 }, 4)]
        [TestCase(new int[] { 0, 0, 0, 0 }, 0)]
        [TestCase(new int[] { -15, 0, -9, - 100 }, 0)]
        public void MaxTest(int[] array, int expected)
        {
            ArrayList Array = new ArrayList(array);
            int actual = Array.Max();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, 0)]
        [TestCase(new int[] { 1, 0, 4, 24 }, 0)]
        [TestCase(new int[] { -14, 2, 0, -2, -20, 30, 101 }, -20)]
        public void MinTest(int[] array, int expected)
        {
            ArrayList Array = new ArrayList(array);
            int actual = Array.Min();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, 0)]
        [TestCase(new int[] { 4, 1, 2, 3, 0 }, 4)]
        [TestCase(new int[] { -1, 0, 28, 1, -5, 0, 11}, 4)]
        public void IndexByMinTest(int[] array, int expected)
        {
            ArrayList Array = new ArrayList(array);
            int actual = Array.IndexByMin();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 1, 2, 3 }, 3)]
        [TestCase(new int[] { 4, 1, 2, 3, 0 }, 0)]
        [TestCase(new int[] { -9, -23, -214, - 42, -1, -12, -10 }, 4)]
        public void IndexByMaxTest(int[] array, int expected)
        {
            ArrayList Array = new ArrayList(array);
            int actual = Array.IndexByMax();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 1, 0, 2 }, new int[] { 0, 1, 2, 3 })]
        [TestCase(new int[] { 4, 1, 2, 3, 0 }, new int[] { 0, 1, 2, 3, 4 })]
        [TestCase(new int[] { -5, 1, 0, 2, 16, -35, 0 }, new int[] { -35, -5, 0, 0, 1, 2, 16 })]
        public void SortTest(int[] array, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.Sort();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 1, 0, 2 }, new int[] { 3, 2, 1, 0 })]
        [TestCase(new int[] { 4, 1, 2, 3, 0 }, new int[] { 4, 3, 2, 1, 0 })]
        [TestCase(new int[] { -5, 1, 0, 2, 16, -35, 0 }, new int[] { 16, 2, 1, 0, 0, -5, -35 })]
        public void SortDecreaseTest(int[] array, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.SortDecrease();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 1, 3, 2 }, 3, new int[] { 1, 3, 2 })]
        [TestCase(new int[] { 4, 1, 4, 3, 4 }, 4, new int[] { 1, 4, 3, 4 })]
        [TestCase(new int[] { 1, 5, -5, 0, -2, -5, 10 }, -5, new int[] { 1, 5, 0, -2, -5, 10 })]
        [TestCase(new int[] { 1, 5, -5, 0, -2, -5, 10 }, -41, new int[] { 1, 5, -5, 0, -2, -5, 10 })]
        public void DeleteValueTest(int[] array, int value, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.DeleteValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 2, 2, 2, 2 }, 2, new int[] { })]
        [TestCase(new int[] { 2, 2, 2, -3, 4 }, 2, new int[] { -3, 4 })]
        [TestCase(new int[] { 3, 1, 3, 2 }, 3, new int[] { 1, 2 })]
        [TestCase(new int[] { 4, 1, 4, 3, 4 }, 4, new int[] { 1, 3 })]
        [TestCase(new int[] { -41, 2, 5, -5, -5, 213 }, -5, new int[] { -41, 2, 5, 213 })]
        public void DeleteValuesTest(int[] array, int value, int[] exp)
        {
            ArrayList expected = new ArrayList(exp);
            ArrayList actual = new ArrayList(array);
            actual.DeleteValues(value);
            Assert.AreEqual(expected, actual);
        }
    }
}