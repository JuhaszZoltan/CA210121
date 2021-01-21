using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA210121
{
    abstract class Emlos
    {
        public int VegtagokSzama { get; set; }

        abstract public void Eszik(object dolog);
    }
    class Szarvas : Emlos, IHavePos
    {
        public int X => 0;

        public int Y => 0;

        override public void Eszik(object dolog)
        {
            if(!(dolog is Noveny))
                throw new Exception("nemjo");
            Console.WriteLine($"finom volt ez a {dolog.GetType()}");
        }

        public string GetPos()
        {
            return $"Ez a {GetType()} a [{X},{Y}]";
        }

        string IHavePos.TypeInfo()
        {
            return (this as object).GetType().ToString().Split('.')[1];
        }
    }


    sealed class Farkas : Emlos, IHavePos
    {
        public int X { get; set; }
        public int Y { get; set; }

        override public void Eszik(object dolog)
        {
            if (!(dolog is Emlos))
                throw new Exception("nemjo");
            Console.WriteLine($"finom volt ez a {dolog.GetType()}");
        }

        public string GetPos()
        {
            return $"Ez a {GetType()} a [{X},{Y}]";
        }

        string IHavePos.TypeInfo()
        {
            return (this as object).GetType().ToString().Split('.')[1];
        }
    }

    class Gomba : IHavePos
    {
        public int X { get; }
        public int Y { get; }

        public string GetPos()
        {
            return $"Ez a {TypeInfo()} a [{X},{Y}]";
        }

        public string TypeInfo() =>
            this.GetType().ToString().Split('.')[1];
    }

    interface IHavePos
    {
        int X { get; }
        int Y { get; }
        string GetPos();
        string TypeInfo();
    }


    class Noveny { }

    class Program
    {
        static void Main()
        {

            Farkas f = new Farkas();
            Szarvas sz = new Szarvas();
            Emlos m = new Farkas();

            (m as Farkas).X = 32;

            var erdo = new List<IHavePos>()
            {
                new Farkas(),
                new Szarvas(),
                new Farkas(),
                new Gomba(),
            };

            object s = m;

            if (s is IHavePos) Console.WriteLine((s as IHavePos).X);
            Console.ReadKey();

        }
    }
}
