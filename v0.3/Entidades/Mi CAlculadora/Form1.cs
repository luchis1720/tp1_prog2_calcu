using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {

        #region CONSTRUCTOR
        public LaCalculadora()
        {
            InitializeComponent();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Realiza la operacion ingresada. llamando a la funcion "Operar"
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns> Resultado de la operacion</returns>
        public static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            double ans=0;

            if (!(object.ReferenceEquals(num1,null)) && !(object.ReferenceEquals(num2,null)))
                ans = Calculadora.Operar(num1, num2, operador);

            return ans;
        }

        /// <summary>
        ///  Borra los datos de los TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        public void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.Text = "";
            this.lblResultado.Text = "";
        }

        #endregion

        /// <summary>
        /// Carga la etiqueta resultado en vacio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaCalculadora_Load_1(object sender, EventArgs e)
        {
            this.Text = "Calculadora de Luis Toncic - Curso 2ºC";
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
            lblResultado.Text = "";          
        }

        #region BOTONES
        /// <summary>
        /// Realiza la operacion segun los numeros y operando ingresados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            int index = cmbOperador.SelectedIndex;
            if (index != -1)
                if (index == 2 && (String.IsNullOrEmpty(txtNumero2.Text) || index == 2 && (Convert.ToDouble(txtNumero2.Text)) == 0))
                {
                    //lblResultado.Text = "ERROR";
                    MessageBox.Show("NO SE PUEDE DIVIDIR POR CERO","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    lblResultado.Text = (LaCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Items[index].ToString())).ToString("0.#######");
        }

        /// <summary>
        /// llama a la funcion limpiar, que limpia los campos TextBox, ComboBox y Label de la pantalla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// cierra la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Convertirá el resultado, de existir a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string ans="";
            if (!(object.ReferenceEquals(lblResultado.Text,"")))
                ans= Numero.DecimalBinario(lblResultado.Text);

            lblResultado.Text = ans;
        }

        /// <summary>
        /// Convertirá el resultado, de existir y ser binario, a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string ans="";

            if (lblResultado.Text != "")
                ans=  Numero.BinarioDecimal(lblResultado.Text);

            lblResultado.Text =ans;
        }

        #endregion






    }
}
