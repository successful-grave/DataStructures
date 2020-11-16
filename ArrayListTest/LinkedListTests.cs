﻿using System;
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
        public void Max(int[] actualArray, int expected)
        {
            LinkedList Array = new LinkedList(actualArray);
            int actual = Array.Max();
            Assert.AreEqual(expected, actual);
        }
    }
}