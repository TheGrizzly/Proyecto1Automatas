using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAutomatas1
{
    class Program
    {

        static void VerifTokens(string input)
        {
            Char delimiter = ' ';
            String[] Tokens = input.Split(delimiter);
            int TokenAceptado = 0, TokenNoAceptado = 0, Identificador = 0, RealSinSigno = 0, EnteroSinSigno = 0, Asignacion = 0, FinDeSentencia = 0, Suma = 0;
            int NumOfTokens = Tokens.Count();
            Char[] ChainVerif;
            for (int i = 0; i < NumOfTokens; i++)
            {
                ChainVerif = Tokens[i].ToCharArray();
                int NumChar = ChainVerif.Count();
                if (Char.IsLetter(ChainVerif[0]))
                {
                    if (NumChar == 1)
                        Identificador++;
                    else
                    {
                        int j = 1;
                        bool valido = true;
                        while (j < NumChar)
                        {
                            if (Char.IsLetterOrDigit(ChainVerif[j]))
                                j++;
                            else
                            {
                                valido = false;
                                break;
                            }    
                        }
                        if (valido)
                            Identificador++;
                        else
                            TokenNoAceptado++;

                    }
                }
                else if (Char.IsNumber(ChainVerif[0]))
                {
                    if (NumChar == 1)
                        EnteroSinSigno++;
                    else
                    {
                        int j = 1;
                        bool validoEntero = true;
                        bool validoDecimal = false;
                        bool intentoDecimal = false;
                        while (j < NumChar)
                        {
                            if (Char.IsDigit(ChainVerif[j]))
                                j++;
                            else if (ChainVerif[j] == '.')
                            {
                                intentoDecimal = true;
                                validoEntero = false;
                                break;
                            }
                            else
                            {
                                validoEntero = false;
                                break;
                            }
                        }

                        if (intentoDecimal)
                        {
                            if(j == (NumChar - 1))
                            {
                                validoDecimal = false;
                            }else
                                while(j < NumChar)
                                {
                                    if (Char.IsDigit(ChainVerif[j]))
                                    {
                                        j++;
                                        validoDecimal = true;
                                    }
                                    else
                                    {
                                        validoDecimal = false;
                                        break;
                                    }
                                    
                                }
                        }


                        if (validoEntero)
                            EnteroSinSigno++;
                        else if (validoDecimal)
                            RealSinSigno++;
                        else
                            TokenNoAceptado++;
                    }
                }
                else if (ChainVerif[0] == ':')
                {
                    if (NumChar == 2)
                    {
                        if (ChainVerif[1] == '=')
                            Asignacion++;
                        else
                            TokenNoAceptado++;
                    }
                    else
                        TokenNoAceptado++;
                }
                else if (ChainVerif[0] == ';')
                {
                    if (NumChar == 1)
                        FinDeSentencia++;
                    else if (NumChar > 1)
                        TokenNoAceptado++;
                }
                else if (ChainVerif[0] == '+')
                {
                    if (NumChar == 1)
                        Suma++;
                    else if (NumChar > 1)
                        TokenNoAceptado++;
                }
                else
                    TokenNoAceptado++;
            }
            TokenAceptado = Identificador + RealSinSigno + EnteroSinSigno + Asignacion + FinDeSentencia + Suma;
            Console.WriteLine("Cadena ingresada: " + input);
            Console.WriteLine("Cantidad de tokens acpetados: " + TokenAceptado.ToString());
            Console.WriteLine("Cantidad de tokens no acpetados: " + TokenNoAceptado.ToString());
            Console.WriteLine("Identificador: " + Identificador.ToString());
            Console.WriteLine("Real sin signo: " + RealSinSigno.ToString());
            Console.WriteLine("Entero sin signo: " + EnteroSinSigno.ToString());
            Console.WriteLine("Asignacion: " + Asignacion.ToString());
            Console.WriteLine("Fin de sentencia: " + FinDeSentencia.ToString());
            Console.WriteLine("Suma: " + Suma.ToString());
        }
        static void Main(string[] args)
        {
            bool loop = false;
            char loopverif;
            string input;
            do
            {
                Console.WriteLine("Proyecto 1");
                Console.WriteLine();
                Console.WriteLine("Ingrese la cadena que quiera verificar: ");
                input = Console.ReadLine();
                Console.WriteLine();
                VerifTokens(input);
                Console.WriteLine();
                Console.WriteLine("Desea ingresar otro cadena para verificar (Y/N): ");
                loopverif = Console.ReadKey().KeyChar;
                if (loopverif == 'Y' || loopverif == 'y')
                    loop = true;
                else if (loopverif == 'N' || loopverif == 'n')
                    loop = false;
            } while (loop);
        }
    }
}
