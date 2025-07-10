using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace week02.code.Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        [TestMethod]
        // Scenario: Enqueue adds items to the back; Dequeue returns highest priority item.
        // Expected Result: "High" is dequeued before "Medium" and "Low".
        // Defect(s) Found: None
        public void Enqueue_Adds_To_Back_Highest_Priority_Dequeued()
        {
            var queue = new PriorityQueue();
            queue.Enqueue("Low", 1);
            queue.Enqueue("Medium", 3);
            queue.Enqueue("High", 5);

            string result = queue.Dequeue();
            Assert.AreEqual("High", result); // Highest priority expected first
        }

        [TestMethod]
        // Scenario: Two items with the same priority, inserted in order.
        // Expected Result: The first added item should be dequeued first (FIFO among ties).
        // Defect(s) Found: None
        public void Dequeue_Tied_Priority_Returns_First_Added()
        {
            var queue = new PriorityQueue();
            queue.Enqueue("First", 4);
            queue.Enqueue("Second", 4);

            string result = queue.Dequeue();
            Assert.AreEqual("First", result);
        }

        [TestMethod]
        // Scenario: Multiple items with descending priorities.
        // Expected Result: Items should be dequeued from highest to lowest priority.
        // Defect(s) Found: None
        public void Dequeue_Multiple_Items_Returns_In_Descending_Priority()
        {
            var queue = new PriorityQueue();
            queue.Enqueue("Low", 1);
            queue.Enqueue("Mid", 5);
            queue.Enqueue("Urgent", 9);

            Assert.AreEqual("Urgent", queue.Dequeue());
            Assert.AreEqual("Mid", queue.Dequeue());
            Assert.AreEqual("Low", queue.Dequeue());
        }

        [TestMethod]
        // Scenario: Dequeue from an empty queue.
        // Expected Result: Should throw InvalidOperationException.
        // Defect(s) Found: None
        public void Dequeue_From_Empty_Throws_Exception()
        {
            var queue = new PriorityQueue();
            Assert.ThrowsException<InvalidOperationException>(() => queue.Dequeue());
        }

        [TestMethod]
        // Scenario: All items in the queue have the same priority.
        // Expected Result: They are dequeued in the same order they were added (FIFO).
        // Defect(s) Found: None
        public void Dequeue_All_Tied_Priorities_Respects_FIFO()
        {
            var queue = new PriorityQueue();
            queue.Enqueue("A", 2);
            queue.Enqueue("B", 2);
            queue.Enqueue("C", 2);

            Assert.AreEqual("A", queue.Dequeue());
            Assert.AreEqual("B", queue.Dequeue());
            Assert.AreEqual("C", queue.Dequeue());
        }

        [TestMethod]
        // Scenario: Items added in random order, check if correct one dequeued first.
        // Expected Result: Highest priority item is returned, regardless of position in queue.
        // Defect(s) Found: None
        public void Dequeue_Highest_Priority_Regardless_Of_Position()
        {
            var queue = new PriorityQueue();
            queue.Enqueue("X", 3);
            queue.Enqueue("Y", 9);
            queue.Enqueue("Z", 5);

            string result = queue.Dequeue();
            Assert.AreEqual("Y", result); // Highest priority
        }
    }
}
