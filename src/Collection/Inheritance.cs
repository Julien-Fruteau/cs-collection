namespace Collection
{
    public interface IBase
    {
        string GetClassName();
    }
    
    public class Inheritance : IBase
    {
        public string className;
        public Inheritance()
        {
            className = "Inheritance";
        }

        public virtual string GetClassName()
        {
            return className + " : called from Inheritance";
        }
    }

    public class Child : Inheritance
    {
        public Child(): base()
        {
            className = "Child";
        }
        

        public override string GetClassName()
        {
            return className + " : called from Child";
        }
    }
}