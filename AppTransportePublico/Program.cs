using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransportePublico
{
    internal class Program
    {
        static int ConvertirEntero(string numeroString)
        {
            if (int.TryParse(numeroString, out int numeroInt))
            {
                return numeroInt;
            }
            else
            {
                return 0;
            }
        }
        private static void InicializarLista(List<TransportePublico> transportesPublicos)
        {
            for (int i = 0; i < 5; i++)
            {
                TransportePublico taxi = new Taxi(0);
                transportesPublicos.Add(taxi);
            }
            for (int i = 0; i < 5; i++)
            {
                TransportePublico omnibus = new Omnibus(0);
                transportesPublicos.Add(omnibus);
            }
        }
        private static void CargarPasajeros(List<TransportePublico> transportesPublicos)
        {
            string opcionCarga;
            do
            {
                Console.WriteLine("*********CARGA DE PASAJEROS*********");
                Console.WriteLine("\n\tTIPO\t   CANT PASAJEROS");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{i + 1}-\t" + transportesPublicos[i].Tipo + $"{i + 1}" + "          ");
                    Console.WriteLine(transportesPublicos[i].CantPasajeros);
                }
                for (int i = 5; i < 10; i++)
                {
                    Console.Write($"{i + 1}-\t" + transportesPublicos[i].Tipo + $"{i - 4}" + "       ");
                    Console.WriteLine(transportesPublicos[i].CantPasajeros);
                }
                Console.WriteLine("11-VOLVER AL MENU ANTERIOR");
                Console.Write("\nIngrese una opción: ");
                
                opcionCarga = Console.ReadLine();
                int opcionCargaInt = ConvertirEntero(opcionCarga);
                
                if (opcionCargaInt < 1 || opcionCargaInt > 10)
                {
                    if (!(opcionCargaInt == 11))
                    {
                        Console.WriteLine("Opcion no valida, intente nuevamente");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine($"\nLa opcion {opcionCargaInt} está seleccionada");
                    Console.WriteLine($"Ingrese la cantidad de pasajeros");
                    Console.SetCursorPosition(23, opcionCargaInt + 2);
                    string cantPasajerosString = Console.ReadLine();
                    try
                    {
                        int cantPasajerosInt = Convert.ToInt32(cantPasajerosString);
                        if (cantPasajerosInt > transportesPublicos[opcionCargaInt - 1].CantMaxPasajeros)
                        {
                            Console.SetCursorPosition(26, opcionCargaInt + 2);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write($"Capacidad máxima {transportesPublicos[opcionCargaInt - 1].CantMaxPasajeros} pasajeros, presione una tecla para continuar...");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                        else
                        {
                            if (cantPasajerosInt < 0)
                            {
                                Console.SetCursorPosition(26, opcionCargaInt + 2);
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("No se pueden poner valores negativos, presione una tecla para continuar...");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                            else
                            {
                                transportesPublicos[opcionCargaInt - 1].CantPasajeros = cantPasajerosInt;
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.SetCursorPosition(26, opcionCargaInt + 2);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("Igrese solo valores numericos, presione una tecla para continuar...");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }
                Console.Clear();
            } while (opcionCarga != "11");
        }
        private static void Estado(List<TransportePublico> transportesPublicos)
        {
            Console.WriteLine("\tTRANSPORTE\tCANTIDAD DE PASAJEROS\tESTADO");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("\t  "+transportesPublicos[i].Tipo + $"{i + 1}" + "          \t");
                Console.Write(transportesPublicos[i].CantPasajeros + "\t\t");
                Console.WriteLine(transportesPublicos[i].Estado);
            }
            for (int i = 5; i < 10; i++)
            {
                Console.Write("\t " + transportesPublicos[i].Tipo + $"{i - 4}" + "        \t");
                Console.Write(transportesPublicos[i].CantPasajeros + "\t\t");
                Console.WriteLine(transportesPublicos[i].Estado);
            }
        }
        private static void CambiarEstado(List<TransportePublico> transportesPublicos)
        {
            string stringSeleccion;

            do
            {
                Console.WriteLine("*******CAMBIAR ESTADO*******");
                Console.WriteLine("\n\tTRANSPORTE\tESTADO");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"{i + 1}-\t" + transportesPublicos[i].Tipo + $"{i + 1}" + "   \t");
                    Console.WriteLine(transportesPublicos[i].Estado);
                }
                for (int i = 5; i < 10; i++)
                {
                    Console.Write($"{i + 1}-\t" + transportesPublicos[i].Tipo + $"{i - 4}" + "\t");
                    Console.WriteLine(transportesPublicos[i].Estado);
                }
                Console.WriteLine("11-VOLVER AL MENU ANTERIOR");
                Console.Write("\nSeleccione el transporte que desea cambiar el estado: ");
                stringSeleccion = Console.ReadLine();
                int intSeleccion = ConvertirEntero(stringSeleccion);
                if (intSeleccion > 0 && intSeleccion < 11)
                {
                    if (transportesPublicos[intSeleccion - 1].Estado == "Detenido")
                    {
                        transportesPublicos[intSeleccion - 1].Avanzar();
                    } 
                    else
                    {
                        transportesPublicos[intSeleccion - 1].Detenerse();
                    }
                }
                else
                {
                    if (intSeleccion != 11)
                    {
                        Console.WriteLine("Opcion no valida, intente nuevamente");
                        Console.ReadKey();
                    }
                }
                Console.Clear();
            } while (stringSeleccion != "11");
        }
        static int Menu()
        {
            string opcionMenu;
            
            Console.WriteLine("\tAPP de TRANSPORTE PUBLICO");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("*****MENU PRINCIPAL*****");
            Console.WriteLine("  1-\t Cargar pasajeros");
            Console.WriteLine("  2-\t Cambiar estado");
            Console.WriteLine("  3-\t Ver transporte");
            Console.WriteLine("  4-\t SALIR");
            Console.Write("\nIngrese una opción: ");
            opcionMenu = Console.ReadLine();
            
            return ConvertirEntero(opcionMenu);
        }
        
        static void Main()
        {
            int opcion;
            List<TransportePublico> transportesPublicos = new List<TransportePublico>();
            InicializarLista(transportesPublicos);
            do
            {
                opcion = Menu();
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        CargarPasajeros(transportesPublicos);
                        break;
                    case 2:
                        Console.Clear();
                        CambiarEstado(transportesPublicos);
                        break;
                    case 3:
                        Console.Clear();
                        Estado(transportesPublicos);
                        Console.WriteLine("\nPresione una tecla para volver al menu anterior");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Opcion no válida, intente nuevamente");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            } while (opcion != 4);
            Console.WriteLine($"\nGRACIAS POR UTILIZAR NUESTRA APP!!!");
            Console.WriteLine($"\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
