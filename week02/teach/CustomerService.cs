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

        // ========== Test 1 ==========
        // Scenario: Invalid max size.
        // Expected Result: It should default to 10.
        Console.WriteLine("Test 1 - Invalid Max Size");
        Console.WriteLine();
        Console.WriteLine("####################");
        Console.WriteLine("Expected Output: max size = 10");
        Console.WriteLine("####################");
        Console.WriteLine();


        int n = 0;
        var cs = new CustomerService(n);

        Console.WriteLine($"Max size should be 10: {cs}");

        Console.WriteLine();
        Console.WriteLine("----- End of Test 1 -----");
        Console.WriteLine();


        // Defect(s) Found: None

        Console.WriteLine("=================");
        Console.WriteLine();


        // ========== Test 2 ==========
        // Scenario: Enqueue 3 customers and dequeue all of them
        // Expected Result: An empty queue
        Console.WriteLine("Test 2 - Enqueque customers and dequeue them");
        Console.WriteLine();
        Console.WriteLine("####################");
        Console.WriteLine("Expected Output: An empty queue");
        Console.WriteLine("####################");
        Console.WriteLine();

        n = 3;
        cs = new CustomerService(n);

        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine($"Max size should be {n}");
        Console.WriteLine($"Before ADDING customers: {cs}");
        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine();

        Console.WriteLine("Adding Customers . . .");
        Console.WriteLine();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("********************"); 
            cs.AddNewCustomer();
            Console.WriteLine("********************");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine($"After ADDING customers: {cs}");
        Console.WriteLine("++++++++++++++++++++");

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("--------------------");
        Console.WriteLine($"Before SERVING customers: {cs}");
        Console.WriteLine("--------------------");
        Console.WriteLine();

        Console.WriteLine("Serving Customers . . .");
        Console.WriteLine();

        for (int j = 0; j < n; j++)
        {
            Console.WriteLine("////////////////////");
            cs.ServeCustomer();
            Console.WriteLine("////////////////////");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("--------------------");
        Console.WriteLine($"After SERVING customers: {cs}");
        Console.WriteLine("--------------------");

        Console.WriteLine();
        Console.WriteLine("----- End of Test 2 -----");
        Console.WriteLine();

        // Defect(s) Found: ServeCustomer should get the customer first before removing it.

        Console.WriteLine("=================");
        Console.WriteLine();

        // ========== Test 3 ==========
        // Scenario: Enqueue 4 when the maxlist is 3.
        // Expected Result: Error message: "Maximum Number of Customers in Queue."
        Console.WriteLine("Test 3 - Enqueue a customer to a full queue");
        Console.WriteLine();
        Console.WriteLine("####################");
        Console.WriteLine("Expected Output: 'Maximum Number of Customers in Queue.'");
        Console.WriteLine("####################");
        Console.WriteLine();

        n = 3;
        cs = new CustomerService(n);

        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine($"Max size should be {n}");
        Console.WriteLine($"Before ADDING customers: {cs}");
        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine();

        Console.WriteLine("Adding Customers . . .");
        Console.WriteLine();


        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine("********************");
            cs.AddNewCustomer();
            Console.WriteLine("********************");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine($"After ADDING customers: {cs}");
        Console.WriteLine("++++++++++++++++++++");

        Console.WriteLine();
        Console.WriteLine("----- End of Test 3 -----");
        Console.WriteLine();


        // Defect(s) Found: AddCustomer should limit adding customers based on the max size. That is >=

        Console.WriteLine("=================");

        // ========== Test 4 ==========
        // Scenario: Enqueue 3 customers, dequeue 2, enqueue 5, dequeue 4
        // Expected Result: A queue with 2 customers, the last 2 customers
        Console.WriteLine("Test 4 - Enqueue and dequeue in batches");
        Console.WriteLine();
        Console.WriteLine("####################");
        Console.WriteLine("Expected Output: A queue with the last 2 customers");
        Console.WriteLine("####################");
        Console.WriteLine();

        n = 6;
        cs = new CustomerService(n);


        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine($"Max size should be {n}");
        Console.WriteLine($"Before ADDING the first batch of customers: {cs}");
        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine();


        Console.WriteLine("Adding the FIRST BATCH of Customers . . .");
        Console.WriteLine();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("********************");
            cs.AddNewCustomer();
            Console.WriteLine("********************");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine($"After ADDING the first batch of customers: {cs}");
        Console.WriteLine("++++++++++++++++++++");

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("--------------------");
        Console.WriteLine($"Before SERVING the first batch of customers: {cs}");
        Console.WriteLine("--------------------");
        Console.WriteLine();

        Console.WriteLine("Serving the FIRST BATCH of Customers . . .");
        Console.WriteLine();

        for (int j = 0; j < 2; j++)
        {
            Console.WriteLine("////////////////////");
            cs.ServeCustomer();
            Console.WriteLine("////////////////////");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("--------------------");
        Console.WriteLine($"After SERVING the first batch of customers: {cs}");
        Console.WriteLine("--------------------");
        Console.WriteLine();

        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine($"Max size should be {n}");
        Console.WriteLine($"Before ADDING the second batch of customers: {cs}");
        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine();


        Console.WriteLine("Adding the SECOND BATCH of Customers . . .");
        Console.WriteLine();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("********************");
            cs.AddNewCustomer();
            Console.WriteLine("********************");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine($"After ADDING the second batch of customers: {cs}");
        Console.WriteLine("++++++++++++++++++++");

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("--------------------");
        Console.WriteLine($"Before SERVING the second batch of customers: {cs}");
        Console.WriteLine("--------------------");
        Console.WriteLine();

        Console.WriteLine("Serving the SECOND BATCH of Customers . . .");
        Console.WriteLine();
        for (int j = 0; j < 4; j++)
        {
            Console.WriteLine("////////////////////");
            cs.ServeCustomer();
            Console.WriteLine("////////////////////");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("--------------------");
        Console.WriteLine($"After SERVING the second batch of customers: {cs}");
        Console.WriteLine("--------------------");

        Console.WriteLine();
        Console.WriteLine("----- End of Test 4 -----");
        Console.WriteLine();

        // Defect(s) Found: None

        Console.WriteLine("=================");


        // ========== Test 5 ==========
        // Scenario: Enqueue 3 and serve 5
        // Expected Result: Display an error message: "No customers in queue. You may take a break."
        Console.WriteLine("Test 5");
        Console.WriteLine();
        Console.WriteLine("####################");
        Console.WriteLine("Expected Output: 'No customers in queue. You may take a break.''");
        Console.WriteLine("####################");
        Console.WriteLine();

        n = 3;
        cs = new CustomerService(n);

        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine($"Max size should be {n}");
        Console.WriteLine($"Before ADDING customers: {cs}");
        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine();


        Console.WriteLine("Adding Customers . . .");
        Console.WriteLine();
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("********************");
            cs.AddNewCustomer();
            Console.WriteLine("********************");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine($"After ADDING customers: {cs}");
        Console.WriteLine("++++++++++++++++++++");

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("--------------------");
        Console.WriteLine($"Before SERVING customers: {cs}");
        Console.WriteLine("--------------------");
        Console.WriteLine();

        Console.WriteLine("Serving Customers . . .");
        Console.WriteLine();

        for (int j = 0; j < 5; j++)
        {
            Console.WriteLine("////////////////////");
            cs.ServeCustomer();
            Console.WriteLine("////////////////////");
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("--------------------");
        Console.WriteLine($"After SERVING customers: {cs}");
        Console.WriteLine("--------------------");

        Console.WriteLine();
        Console.WriteLine("----- End of Test 5 -----");
        Console.WriteLine();

        // Defect(s) Found: ServeCustomer needs a case when there are no customers to serve.

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
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }
        else
        {
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
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {

        if (_queue.Count == 0)
        {
            Console.WriteLine("No customers in queue. You may take a break.");
        }
        else
        {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }

        if (_queue.Count != 0)
        {
            Console.WriteLine($"There are still {_queue.Count} customers waiting. Please go back and serve them.");
        }
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