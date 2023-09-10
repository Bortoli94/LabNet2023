using Practica.EF.Logic;
using Practica.EF.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.UI
{
    public class Menu
    {
        public string MainMenu()
        {
            Console.WriteLine("PRACTICA 3 - ENTITY FRAMEWORK");
            Console.WriteLine("\nMenu principal - ENTIDADES");
            Console.WriteLine("1-\tCategories (ABM COMPLETO)");
            Console.WriteLine("2-\tShippers (SOLO VISUALIZAR TABLA)");
            Console.WriteLine("3-\tSALIR");
            Console.Write("\nSeleccione una opción: ");

            return Console.ReadLine();

        }

        public string MenuABM()
        {
            Console.WriteLine("\n\tMENU ABM");
            Console.WriteLine("1-\tInsertar nuevo campo");
            Console.WriteLine("2-\tEliminar campo por ID");
            Console.WriteLine("3-\tModificar un campo");
            Console.WriteLine("4-\tVolver al menu anterior");
            Console.Write("Seleccione una opción: ");

            return Console.ReadLine();
        }

        public Dictionary<string, string> InsertValues()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            Console.Write("Nombre Categoria: ");
            string nameCategory = Console.ReadLine();
            Console.Write("Descripcion Categoria: ");
            string descriptionCategory = Console.ReadLine();

            dic.Add("name", nameCategory);
            dic.Add("description", descriptionCategory);

            return dic;
        }

        public void ShowTable(CategoryLogic categoryLogic, string title)
        {
            Console.WriteLine("CATEGORIES");
            Console.WriteLine("ID - NOMBRE - DESCRIPCION");
            foreach (var category in categoryLogic.GetAll())
            {
                Console.WriteLine($"{category.CategoryID} - {category.CategoryName} - {category.Description}");
            }
            Console.WriteLine("-------------------------------------------------------------------");
            if (title != null) Console.WriteLine($"\n\t{title}");
        }


    }
}
