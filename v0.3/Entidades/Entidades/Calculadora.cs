using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Calculadora
    {

        /// <summary>
        /// Método que valida operadores aritmericos.
        /// </summary>
        /// <param name="operador">Cadena a validar</param>
        /// <returns>Cadena validada</returns>
        private static string ValidarOperador(string operador)
        {
            string ans = "+";

            if (operador == "-")
                ans = "-";
            else if (operador == "*")
                ans = "*";
            else if (operador == "/")
                ans = "/";

            return ans;
        }

        /// <summary>
        /// Valida, y realiza la operacion pedida entre ambos numeros.
        /// </summary>
        /// <param name="num1">El primer numero se pasa como parametro</param>
        /// <param name="num2">El segundo numero se pasa como parametro</param>
        /// <param name="operador">El operador se pasa como parametro</param>
        /// <returns>retorna el resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double ans=0;
            string op;

            if (!(object.ReferenceEquals(num1, null)) && !(object.ReferenceEquals(num2, null)) && !(object.ReferenceEquals(operador, null)))
            {
                switch (op = ValidarOperador(operador))
                {
                    case "+":
                        ans = num1 + num2;
                        break;
                    case "-":
                        ans = num1 - num2;
                        break;
                    case "/":
                        ans = num1 / num2;
                        break;
                    case "*":
                        ans = num1 * num2;
                        break;
                }
            }
            return ans;
        }

    }
}
