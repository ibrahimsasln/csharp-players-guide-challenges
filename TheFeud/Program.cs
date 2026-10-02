using IField;
using McDroid;

namespace IField
{
    class Sheep
    {
        public string Baa()
        {
            
            return "Baa!";
        }
    }

    class Pig
    {
        public string Oink()
        {
            return "Oink!";
        }
    }
}

namespace McDroid
{
    class Cow
    {
        public string Moo()
        {
            return "Moo!";
        }
    }

    class Pig
    {
        public string Oink()
        {
            return "Oink!";
        }
    }
}

class Program
{
    static void Main(System.String[] args)
    {
        Sheep sheep = new();
        string baa = sheep.Baa();
        System.Console.WriteLine(baa);

        Cow cow = new();
        string moo = cow.Moo();
        System.Console.WriteLine(moo);
        
        IField.Pig pig1 = new();
        string oink1 = pig1.Oink();
        System.Console.WriteLine(oink1);

        McDroid.Pig pig2 = new();
        string oink2 = pig2.Oink();
        System.Console.WriteLine(oink2);
    }
}