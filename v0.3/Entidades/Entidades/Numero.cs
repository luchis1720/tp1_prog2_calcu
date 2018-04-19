using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Numero
    {
        #region ATRIBUTOS
        private double numero;
        #endregion

        #region CONSTRUCTORES

        public Numero(double numero)
        {
            this.SetNumero = numero;
        }

        public Numero(string strNumero)
        {
            double aux;
            if (double.TryParse(strNumero, out aux))
                this.numero = aux;
        }
        #endregion


        #region PROPIEDADES  Preguntar xq
      
        /// <summary>
        /// Valida y asigna un valor al atributo Numero
        /// </summary>
        public double SetNumero
        {
            set
            {
                
                if (ValidarNumero(Convert.ToString(value)) != 0)  
                    this.numero = value;
                else
                    this.numero = 0;
            }
        }
        #endregion

        #region METODOS

        /// <summary>
        /// Comprobará que el valor recibido sea numérico.
        /// </summary>
        /// <param name="strNumero">El numero a ser validado</param>
        /// <returns>Retorna el numero Validado, o retorna 0 en caso de error.</returns>
        private static double ValidarNumero(string strNumero)
        {
            double ans=0, aux;

            if (strNumero != null ) //&& strNumero >= "0" && strNumero <= "9")
            {
                if (double.TryParse(strNumero, out aux))
                    ans=aux;
            }

            return ans;

        }
        
        /// <summary>
        /// Método que convierte un binario ASCII en un número entero
        /// </summary>
        /// <param name="binario">Binario ASCII a convertir. EJ: 1001</param>
        /// <returns>Valor entero resultado de la conversión. EJ: 9</returns>
        public static string BinarioDecimal(string binario)
        {
            string ans="";
            int Decimal=0;

            for (int i = 1; i <= binario.Length; i++)
            {
                Decimal += int.Parse(binario[i - 1].ToString()) * (int)Math.Pow(2, binario.Length - i);
            }
            ans= Decimal.ToString();

            return ans;
        }

        /// <summary>
        /// Método que convierte un número Decimal en un binario ASCII
        /// </summary>
        /// <param name="numero">Número a convertir. EJ: 9</param>
        /// <returns>Valor binario ASCII resultado de la conversión. EJ: 1001</returns>
        public static string DecimalBinario(double numero)
        {
            string ans = "";
            while (numero >=2)
            {
                ans = (numero % 2).ToString() + ans;
                numero = (int)numero / 2;
            }

            return numero.ToString()+ans;
        }

        /// <summary>
        /// Método que convierte un número Decimal en un binario ASCII
        /// </summary>
        /// <param name="numero">Numero a convertir. EJ: 9</param>
        /// <returns>Valor binario ASCII resultado de la conversion. EJ: 1001</returns>
        public static string DecimalBinario(string numero)
        {
            string error = "Valor invalido";
            for (int i = 0; i < numero.Length; i++)
            {
                if (!char.IsDigit(numero, i))
                    return error;
            }
            return DecimalBinario(double.Parse(numero));

            //string ans="";
            //double aux, doble=0;

            //if(double.TryParse(numero, out aux))
            //    doble=aux;

            //while(doble>0)
            //{
            //    ans= (doble % 2).ToString() + ans;
            //    doble = doble / 2;
            //}

            //return ans;
        }
#endregion

        #region OPERADORES

        /// <summary>
        /// Método que sobrecarga el operador +
        /// </summary>
        /// <param name="............">...............</param>
        /// <returns>......................</returns>
        public static double operator + (Numero n1, Numero n2)
        {
            double ans=0;

            if (n1 != null && n2 !=null)
                ans = n1.numero + n2.numero;

            return ans;
        }

        /// <summary>
        /// Método que sobrecarga el operador -
        /// </summary>
        /// <param name="............">...............</param>
        /// <returns>......................</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double ans=0;
            
            if (n1 != null && n2 !=null)
               ans = n1.numero - n2.numero;

            return ans;
        }

        /// <summary>
        /// Método que sobrecarga el operador *
        /// </summary>
        /// <param name="............">...............</param>
        /// <returns>......................</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double ans=0;

            if (n1 != null && n2 !=null)
                ans = n1.numero * n2.numero;

            return ans;
        }

        /// <summary>
        /// Método que sobrecarga el operador /
        /// </summary>
        /// <param name="............">...............</param>
        /// <returns>......................</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double ans=0;
            
            if (n1 != null && n2 !=null)
                ans = n1.numero / n2.numero;

            return ans;
        }
#endregion

    }
}
