using Practica.EF.Entities;
using Practica.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.UI
{
    internal class Program
    {
        static void Main()
        {
            string opMain, opMenuABM, idString;
            int idInt;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            do
            {
                Menu program = new Menu();
                opMain = program.MainMenu();    
                
                switch (opMain)
                {
                    case "1":
                        do
                        {
                            Console.Clear();
                            CategoryLogic categoryLogic = new CategoryLogic();
                            program.ShowTable(categoryLogic, null);
                            opMenuABM = program.MenuABM();
                            switch (opMenuABM)
                            {
                                case "1":
                                    Console.Clear();
                                    program.ShowTable(categoryLogic, "INSERTAR");
                                    dic = program.InsertValues();
                                    try
                                    {
                                        categoryLogic.Add(new Categories
                                        {
                                            CategoryName = dic["name"],
                                            Description = dic["description"]
                                        });
                                        Console.WriteLine("Carga Exitosa");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.WriteLine("\nPresione una tecla para continuar...");
                                    Console.ReadKey();
                                    break;
                                case "2":
                                    Console.Clear();
                                    program.ShowTable(categoryLogic, "ELIMINAR");
                                    Console.Write("Ingrese la ID del campo que desea eliminar: ");
                                    idString = Console.ReadLine();
                                    try
                                    {
                                        idInt = Convert.ToInt32(idString);
                                        categoryLogic.Delete(idInt);
                                        Console.WriteLine("Operacion exitosa");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    Console.WriteLine("\nPresione una tecla para continuar...");
                                    Console.ReadKey();
                                    break;
                                case "3":
                                    Console.Clear();
                                    program.ShowTable(categoryLogic, "MODIFICAR");
                                    Console.Write("Ingrese la ID del campo que desea modificar: ");
                                    idString = Console.ReadLine();
                                    int.TryParse(idString, out idInt);
                                    var search = categoryLogic.Search(idInt);
                                    if (search != null)
                                    {
                                        Console.WriteLine($"Categoria {search.CategoryID} - {search.CategoryName}  SELECCIONADA");
                                        dic = program.InsertValues();
                                        try
                                        {
                                            categoryLogic.Update(new Categories
                                            {
                                                CategoryName = dic["name"],
                                                Description = dic["description"]
                                            });
                                            Console.WriteLine("Operacion exitosa");
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No existe Categoría con ese ID");
                                    }
                                    Console.WriteLine("\nPresione una tecla para continuar...");
                                    Console.ReadKey();
                                    break;
                                default:
                                    if (opMenuABM != "4")
                                    {
                                        Console.WriteLine("Opcion no válida, intente de nuevo");
                                        Console.WriteLine("\nPresione una tecla para continuar...");
                                        Console.ReadKey();
                                    }
                                    break;
                            }
                        } while (opMenuABM != "4");    
                        
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("SHIPPERS");
                        Console.WriteLine("ID - NOMBRE DE LA EMPRESA - TELEFONO");
                        ShipperLogic shipperLogic = new ShipperLogic();
                        foreach (var shipper in shipperLogic.GetAll())
                        {
                            Console.WriteLine($"{shipper.ShipperID} - {shipper.CompanyName} - {shipper.Phone}");
                        }
                        
                        Console.WriteLine("\nPresione una tecla para volver al menu anterior...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        if (opMain != "3")
                        {
                            Console.WriteLine("Opcion no válida, intente de nuevo");
                            Console.WriteLine("\nPresione una tecla para continuar...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                }
            } while (opMain != "3" );


            Console.WriteLine("El programa ha finalizado");
            Console.ReadKey();



        }
    }
}
