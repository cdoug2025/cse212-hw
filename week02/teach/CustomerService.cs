using System.Runtime;
using System.Runtime.InteropServices.JavaScript;

/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Input is 0
        // Expected Result: Max size = 10
        Console.WriteLine("Test 1");
        var cs = new CustomerService(0);
        Console.WriteLine(cs);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add a customer to the queue
        // Expected Result: A queue with one Customer
        Console.WriteLine("Test 2");
        cs = new CustomerService(5);
        cs.AddNewCustomer();
        Console.WriteLine(cs);

        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Ensure an error message is sent when the queue overflows
        // Expected Result: A message saying the queue is full
        Console.WriteLine("Test 3");
        cs = new CustomerService(1);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        Console.WriteLine(cs);

        // Defect(s) Found: > instead of >=

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Testing the ServeCustomer function
        // Expected Result: Dequeue the next customer and display the details
        Console.WriteLine("Test 4");
        cs = new CustomerService(5);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.ServeCustomer();
        Console.WriteLine(cs);

        // Defect(s) Found: Dequeued before showing information of first customer in queue so the wrong info was displayed

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Testing the ServeCustomer function when the queue is empty
        // Expected Result: An error message
        Console.WriteLine("Test 5");
        cs = new CustomerService(5);
        cs.ServeCustomer();
        Console.WriteLine(cs);

        // Defect(s) Found: No error handling

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) {
            Console.WriteLine("No Customers in Queue.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}