
public interface IImplementation {
    string OperationImplementation();
}
public class Abstraction {
    protected IImplementation _implementation;
    protected Abstraction(IImplementation implementation) {
        _implementation = implementation;
    }
    public virtual string Operation() {
        return "Abstract: base operation with: \n" + _implementation.OperationImplementation();
    }
}
public class ExtendedAbstraction : Abstraction {
    public ExtendedAbstraction(IImplementation implementation): base(implementation) {


    }
    public override string Operation() {
        return "ExtenddAbstraction: Extended operation with: \n" + base._implementation.OperationImplementation();
    }
    
}
public class ConcreteImplementationA : IImplementation {
    public string OperationImplementation() {
        return "ConcreteImplementationA: The result in platform A. \n";
    }
}
public class ConcreteImplementationB : IImplementation {
    public string OperationImplementation(){
        return "ConcreteImplementationB: The result in platform B. \n";
    }
}
public class Client {
    public void ClientCode(Abstraction abstraction) => Console.Write(abstraction.Operation());
}

public class Program {
    static void Main(string[] args){
        Client client = new Client();
        Abstraction abstraction;
        abstraction = new Abstraction(new ConcreteImplementationA());
        client.ClientCode(abstraction);
        Console.WriteLine("");
        abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
        client.ClientCode(abstraction);
    }
}

