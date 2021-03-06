using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            PanCakeHouseMenu panCakeHouseMenu = new PanCakeHouseMenu();
            DinerMenu dinerMenu = new DinerMenu();

            IEnumerable<MenuPosition> panCakeHouseEnumerable = panCakeHouseMenu.GetEnumerable();
            IEnumerable<MenuPosition> dinerMenuEnumerable = dinerMenu.GetEnumerable();            

            WriteMenu(panCakeHouseEnumerable);
            Console.WriteLine();
            WriteMenu(dinerMenuEnumerable);
            Console.ReadKey();
        }

        private static void WriteMenu(IEnumerable<MenuPosition> enumerable)
        {
            foreach(MenuPosition menuPosition in enumerable)
            {
                if(menuPosition != null)
                {
                    Console.WriteLine($"{menuPosition.Name}, {menuPosition.Description}, {menuPosition.IsVege}, {menuPosition.Cost}");
                }                
            }
        }

        public class MenuPosition
        {
            public string Name { get; }
            public string Description { get; }
            public bool IsVege { get; }
            public double Cost { get; }

            public MenuPosition(string name, string description, bool isVege, double cost)
            {
                this.Name = name;
                this.Description = description;
                this.IsVege = isVege;
                this.Cost = cost;
            }
        }                        

        public class PanCakeHouseMenu
        {
            public List<MenuPosition> MenuPositions { get; }

            public PanCakeHouseMenu()
            {
                MenuPositions = new List<MenuPosition>();

                AddMenuPosition("Pancake with eggs", "Pancake with scrumbled eggs and toast", true, 2.99);
                AddMenuPosition("Normal pancake", "Pancake with sausages", false, 5.99);
            }

            public void AddMenuPosition(string name, string description, bool isVege, double cost)
            {
                MenuPositions.Add(new MenuPosition(name, description, isVege, cost));
            }

            public IEnumerable<MenuPosition> GetEnumerable()
            {
                return MenuPositions;
            }            
        }

        public class DinerMenu
        {
            const int MAX_ITEMS = 6;
            int items = 0;
            public MenuPosition[] MenuPositions { get; }

            public DinerMenu()
            {
                MenuPositions = new MenuPosition[MAX_ITEMS];
                AddMenuPosition("Vege Sandwitch", "Sandwitch with cucumber, tomato and cheese", true, 1.99);
                AddMenuPosition("Normal Sandwitch", "Sandwitch with ham and tomato", true, 2.49);
            }

            public void AddMenuPosition(string name, string description, bool isVege, double cost)
            {
                if (items >= MAX_ITEMS)
                {
                    Console.WriteLine("Menu is full");
                }
                else
                {
                    MenuPositions[items] = new MenuPosition(name, description, isVege, cost);
                    items++;
                }
            }

            public IEnumerable<MenuPosition> GetEnumerable()
            {
                return MenuPositions;
            }
        }
    }
}
