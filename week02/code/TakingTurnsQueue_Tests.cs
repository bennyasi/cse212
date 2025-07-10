using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class TakingTurnsQueue_Tests
{
    [TestMethod]
    // Scenario: Add a person with 3 turns. Dequeue them once.
    // Expected Result: Person returned with 3 turns, then re-enqueued with 2 turns.
    // Test Result: Passed ✅
    public void SinglePerson_With_Turns_Should_Decrement()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Alice", 3);

        var person = queue.GetNextPerson();
        Assert.AreEqual("Alice", person.Name);
        Assert.AreEqual(3, person.Turns); // First return still has 3
        Assert.AreEqual("[(Alice:2)]", queue.ToString()); // Remaining in queue with 2 turns
    }

    [TestMethod]
    // Scenario: Add a person with infinite turns (0 turns).
    // Expected Result: Person should stay in the queue and be re-enqueued after every turn.
    // Test Result: Passed ✅
    public void InfiniteTurns_Should_Stay_In_Queue()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Bob", 0);

        var person1 = queue.GetNextPerson();
        var person2 = queue.GetNextPerson();

        Assert.AreEqual("Bob", person1.Name);
        Assert.AreEqual("Bob", person2.Name);
        Assert.AreEqual("[(Bob:Forever)]", queue.ToString());
    }

    [TestMethod]
    // Scenario: Add two people with different turn values. Ensure correct rotation and decrement.
    // Expected Result: Proper rotation, one removed after turns expire, other remains.
    // Test Result: Passed ✅
    public void MultiplePeople_Should_Respect_Turns()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Charlie", 1); // Should be removed after one turn
        queue.AddPerson("Dana", 2);    // Should remain with 1 after one turn

        var first = queue.GetNextPerson();  // Charlie returned, not re-added
        var second = queue.GetNextPerson(); // Dana returned, re-added with 1

        Assert.AreEqual("Charlie", first.Name);
        Assert.AreEqual("Dana", second.Name);
        Assert.AreEqual("[(Dana:1)]", queue.ToString());
    }

    [TestMethod]
    // Scenario: Empty queue should throw an exception on GetNextPerson().
    // Expected Result: InvalidOperationException is thrown.
    // Test Result: Passed ✅
    public void EmptyQueue_Should_Throw_Exception()
    {
        var queue = new TakingTurnsQueue();

        Assert.ThrowsException<InvalidOperationException>(() => queue.GetNextPerson());
    }

    [TestMethod]
    // Scenario: Person with 1 turn should not be re-added to queue.
    // Expected Result: Person dequeued once and queue becomes empty.
    // Test Result: Passed ✅
    public void Person_With_One_Turn_Should_Be_Removed()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Eve", 1);

        var person = queue.GetNextPerson(); // Dequeued, not re-added

        Assert.AreEqual("Eve", person.Name);
        Assert.AreEqual(true, queue.ToString() == "[]"); // Empty queue
    }
}
