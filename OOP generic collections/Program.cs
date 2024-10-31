namespace OOP_generic_collections;
//OOP generic collections, Axel Schubert.
class Program
{
    static void Main(string[] args)
    {
        //Stack-delen
        //Initierar fem objekt av employee-klassen
        var employee1 = new Employee(1234, "Erik", "Man", 23000 );
        var employee2 = new Employee(2345, "Göran", "Mank", 34000 ); //Stavade medvetet fel på "Man" för att testa min setter.
        var employee3 = new Employee(3456, "Kerstin", "Kvinna", 36000 );
        var employee4 = new Employee(4567, "Alva", "Kvinna", 21000 );
        var employee5 = new Employee(5678, "Bert", "Man", 29000 );
        //Har gör jag en stack och pushar dom. Hittade inget effektivare sätt att göra detta på utan att lägga till dom i en lista innan.
        var employeeStack = new Stack<Employee>();
        employeeStack.Push(employee1);
        employeeStack.Push(employee2);
        employeeStack.Push(employee3);
        employeeStack.Push(employee4);
        employeeStack.Push(employee5);
        foreach (var employee in employeeStack)
        {
            employee.DisplayInfo();
            Console.WriteLine($"Antal kvar i stacken: {employeeStack.Count}"); //Visar alltid 5 eftersom jag inte popar någut ur stacken.
        }
        Console.WriteLine("- - - - - - - - - - - - - - - - - -");
        for (int i = 0; i < 5; i++)
        {
            //Skriver ut allas namn och hur många som kvarstår i stacken efter varje.
            employeeStack.Pop().DisplayInfo();
            Console.WriteLine($"Antal kvar i stacken: {employeeStack.Count}");
        }
        //Lägger till alla i stacken igen.
        employeeStack.Push(employee1);
        employeeStack.Push(employee2);
        employeeStack.Push(employee3);
        employeeStack.Push(employee4);
        employeeStack.Push(employee5);
        Console.WriteLine("- - - - - - - - - - - - - - - - - -");
        Console.WriteLine(employeeStack.Peek().Name);
        Console.WriteLine($"Antal kvar i stacken: {employeeStack.Count}");
        Console.WriteLine(employeeStack.Peek().Name);
        Console.WriteLine($"Antal kvar i stacken: {employeeStack.Count}");
        Console.WriteLine("- - - - - - - - - - - - - - - - - -");
        if (employeeStack.Contains(employee3))
            Console.WriteLine("employee3 finns kvar i stacken.");
        else
            Console.WriteLine("employee3 finnsi inte kvar i stacken.");   
        
        //List-Delen
        var employeeList = new List<Employee> {employee1, employee2, employee3, employee4, employee5};
        if (employeeList.Contains(employee2))
        {
            Console.WriteLine("Objektet employee2 finns i listan.");
        }
        else
        {
            Console.WriteLine("Objektet employee2 finns inte i listan.");
        }
        //Använder lambda-operator för att söka specifikt på gender-egenskapen i employee-listan
        employeeList.Find(e => e.Gender == "Man").DisplayInfo();
        //Skapar en lista för att spara alla employee med Gender == "Man"
        var maleEmployees = employeeList.FindAll(e => e.Gender == "Man");
        Console.WriteLine("- - - - - - - - - - - - - - - - - -");
        foreach (var emp in maleEmployees)
        {
            emp.DisplayInfo();
        }
    }
}

class Employee
{
    private int _id;
    private string _name;
    private string _gender;
    private int _salary;

    public Employee(int id, string name, string gender, int salary)
    {
        this.ID = id;
        this.Name = name;
        this.Gender = gender;
        this.Salary = salary;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Namn:{this.Name} ID:{this.ID} Kön:{this.Gender} Lön:{this.Salary}");
    }
    //Jag ville öva på properties så jag skapade till alla variabler och kunde dessutom använda dom för att begränsa vad man kan sätta gender-variabeln till
    public int ID
    {
        get { return _id; } 
        private set { _id = value; } 
    }
    public string Name
    {
        get { return _name; }       
        private set { _name = value; } 
    }
    public string Gender
    {
        get { return _gender; }
        private set
        {
            if (value == "Man" || value == "Kvinna" || value == "Annat")
                _gender = value;
            else
                _gender = "Okänt";
        }
    }
    public int Salary
    {
        get { return _salary; }       
        private set { _salary = value; } 
    }
}