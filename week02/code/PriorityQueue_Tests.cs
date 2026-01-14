using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and priority: Bob (2), Tim (5), Sue (3), and run until the queue is empty to check enqueue and dequeue.
    // Expected Result: Tim, Sue, Bob
    // Defect(s) Found: The highest priority person is not removed from the queue during Dequeue.
    public void TestPriorityQueue_EnqueueDequeue()
    {
        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 3);

        PriorityItem[] expectedResult = [tim, sue, bob];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        int i = 0;
        while (priorityQueue.Count() > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and priority: Bob (2), Tim (5), Sue (3), and dequeue twice, then, enqueue John (3), Jane (5), and George (3) to check enqueue and dequeue if there is an enqueue midway.
    // Expected Result: Tim, Sue, Jane, John, George, Bob
    // Defect(s) Found: 
    public void TestPriorityQueue_MultipleEnqueueDequeue()
    {
        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 3);
        var john = new PriorityItem("John", 3);
        var jane = new PriorityItem("Jane", 5);
        var george = new PriorityItem("George", 3);

        PriorityItem[] expectedResult = [tim, sue, jane, john, george, bob];

        var priorityQueue = new PriorityQueue();

        // Enqueue 3 items
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        int i = 0;

        // Dequeue 2 items
        for (int j = 0; j < 2; j++)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }

        // Enqueue 3 more items midway
        priorityQueue.Enqueue(john.Value, john.Priority);
        priorityQueue.Enqueue(jane.Value, jane.Priority);
        priorityQueue.Enqueue(george.Value, george.Priority);

        // Dequeue everything
        while (priorityQueue.Count() > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and priority: Bob (2), Tim (5), Sue (3), and check whether the Enqueue function adds the item with data and priority to the back of the queue.
    // Expected Result: [Bob (Pri:2), Tim (Pri:5), Sue (Pri:3)]
    // Defect(s) Found: None
    public void TestPriorityQueue_EnqueueOrder()
    {
        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 3);

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);

        string actualResult = priorityQueue.ToString();

        string expectedResult = "[Bob (Pri:2), Tim (Pri:5), Sue (Pri:3)]";

        Assert.AreEqual(expectedResult, actualResult);
    }


    [TestMethod]
    // Scenario: Create a queue with the following people: Bob (2), Tim (5), Sue (3), John (3), Jane (5), and check if the Dequeue function follows FIFO if there are more than one item with the same highest priority.
    // Expected Result: Tim, Jane, Sue, John, Bob
    // Defect(s) Found: FIFO is not followed for same hight priority values. Hence, the '=' was removed in the Dequeue `if` condition.
    public void TestPriorityQueue_FIFOforSameHighestPriorityValue()
    {
        var bob = new PriorityItem("Bob", 2);
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 3);
        var john = new PriorityItem("John", 3);
        var jane = new PriorityItem("Jane", 5);

        PriorityItem[] expectedResult = [tim, jane, sue, john, bob];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);
        priorityQueue.Enqueue(john.Value, john.Priority);
        priorityQueue.Enqueue(jane.Value, jane.Priority);

        int i = 0;
        while (priorityQueue.Count() > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following people: Bob (5), Tim (5), Sue (5), John (5), Jane (5), and check if the Dequeue function follows FIFO if there are more than one item with the same highest priority.
    // Expected Result: Bob, Tim, Sue, John, Jane
    // Defect(s) Found: FIFO is not followed for same hight priority values. Hence, the '=' was removed in the Dequeue `if` condition.
    public void TestPriorityQueue_FIFOforSamePriorityValue()
    {
        var bob = new PriorityItem("Bob", 5);
        var tim = new PriorityItem("Tim", 5);
        var sue = new PriorityItem("Sue", 5);
        var john = new PriorityItem("John", 5);
        var jane = new PriorityItem("Jane", 5);

        PriorityItem[] expectedResult = [bob, tim, sue, john, jane];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob.Value, bob.Priority);
        priorityQueue.Enqueue(tim.Value, tim.Priority);
        priorityQueue.Enqueue(sue.Value, sue.Priority);
        priorityQueue.Enqueue(john.Value, john.Priority);
        priorityQueue.Enqueue(jane.Value, jane.Priority);

        int i = 0;
        while (priorityQueue.Count() > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Try to dequeue an empty queue.
    // Expected Result: "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
    
    // Add more test cases as needed below.
}