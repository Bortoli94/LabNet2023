using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransportePublico
{
    internal class Program
    {
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
                if (int.TryParse(stringSeleccion, out int intSeleccion))
                {
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
                }
                else
                {
                    Console.WriteLine("Debe ingresar un número");
                    Console.ReadKey();
                }
                Console.Clear();
            } while (stringSeleccion != "11");
        }
        static void Menu()
        {
            Console.WriteLine("\tAPP de TRANSPORTE PUBLICO");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine("*****MENU PRINCIPAL*****");
            Console.WriteLine("  1-\t Cargar pasajeros");
            Console.WriteLine("  2-\t Cambiar estado");
            Console.WriteLine("  3-\t Ver transporte");
            Console.WriteLine("  4-\t SALIR");
            Console.Write("\nIngrese una opción: ");
        }
        
        static void Main(string[] args)
        {
            string opcionMenu;
            string opcionCarga;
            string cantPasajerosString;

            List<TransportePublico> transportesPublicos = new List<TransportePublico>();
            TransportePublico taxi1 = new Taxi(0);
            TransportePublico taxi2 = new Taxi(0);
            TransportePublico taxi3 = new Taxi(0);
            TransportePublico taxi4 = new Taxi(0);
            TransportePublico taxi5 = new Taxi(0);
            TransportePublico omnibus1 = new Omnibus(0);
            TransportePublico omnibus2 = new Omnibus(0);
            TransportePublico omnibus3 = new Omnibus(0);
            TransportePublico omnibus4 = new Omnibus(0);
            TransportePublico omnibus5 = new Omnibus(0);
            transportesPublicos.Add(taxi1);
            transportesPublicos.Add(taxi2);
            transportesPublicos.Add(taxi3);
            transportesPublicos.Add(taxi4);
            transportesPublicos.Add(taxi5);
            transportesPublicos.Add(omnibus1);
            transportesPublicos.Add(omnibus2);
            transportesPublicos.Add(omnibus3);
            transportesPublicos.Add(omnibus4);
            transportesPublicos.Add(omnibus5);
            do
            {
                Menu();
                opcionMenu = Console.ReadLine();
                if (int.TryParse(opcionMenu, out int opcionMenuInt))
                {
                    switch (opcionMenuInt)
                    {
                    case 1:
                        Console.Clear();
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
                            
                            if(int.TryParse(opcionCarga, out int opcionCargaInt))
                            {
                                if (opcionCargaInt < 1 || opcionCargaInt > 10)
                                {
                                    if(!(opcionCargaInt == 11))
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
                                    cantPasajerosString = Console.ReadLine();
                                    if (int.TryParse(cantPasajerosString, out int cantPasajerosInt))
                                    {
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
                                    else
                                    {
                                        Console.SetCursorPosition(26, opcionCargaInt + 2);
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.Write("Solo numeros, presione una tecla para continuar...");
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                        
                                }
                            }
                            else
                            {
                                Console.WriteLine("Solo numeros, intente de nuevo");
                                Console.ReadKey();
                            }
                            Console.Clear();
                        } while (opcionCarga != "11");
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
                }
                else
                {
                    Console.WriteLine("Solo debe ingresar números, intente nuevamente");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (opcionMenu != "4");
            Console.WriteLine($"\nGRACIAS POR UTILIZAR NUESTRA APP!!!");
            Console.WriteLine($"\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
