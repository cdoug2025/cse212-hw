using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following values and priority: priorityItem1 (4), priorityItem2 (6), priorityItem3 (1), priorityItem4 (6) and
    // run until the queue is empty
    // Expected Result: priorityItem2, priorityItem4, priorityItem1, priorityItem3
    // Defect(s) Found: Did not remove priorityItem2 from the queue, wasn't checking the last item in queue, was checking >= for highest priority
    // when only > should be checked
    public void TestPriorityQueue_1()
    {
        string[] expectedResult = ["priorityItem2", "priorityItem4", "priorityItem1", "priorityItem3"];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("priorityItem1", 4);
        priorityQueue.Enqueue("priorityItem2", 6);
        priorityQueue.Enqueue("priorityItem3", 1);
        priorityQueue.Enqueue("priorityItem4", 6);

        int index = 0;
        while (index < 4)
        {
            string currentItem = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[index], currentItem);
            index++;
        }
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue
    // Expected Result: Exception should be thrown with appropriate error message
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException exception)
        {
            Assert.AreEqual("The queue is empty.", exception.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception exception)
        {
            Assert.Fail(string.Format("Unexpected exception of type {0}: {1}", exception.GetType(), exception.Message));
        }
    }

    // Add more test cases as needed below.
}