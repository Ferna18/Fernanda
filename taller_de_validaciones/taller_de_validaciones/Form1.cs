using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using taller_de_validaciones.Elementos;

namespace taller_de_validaciones
{
    public partial class Form1 : Form
    {
        public Form1()

        {
            InitializeComponent();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                erpMensaje.SetError(txtNombre, "Ingresar su nombre");
                return;
            }
            else
            {
                erpMensaje.SetError(txtNombre, "");

            }

            if (string.IsNullOrEmpty(txtNumDocumento.Text))
            {
                erpMensaje.SetError(txtNumDocumento, "Ingrese su numero de documento");
                return;
            }
        
            if(Convert.ToInt64( txtNumDocumento.Text) <= 0)
            {
                erpMensaje.SetError(txtNumDocumento, "Ingrese numero mayor a 0");
                return;
            }


            if (((TipoDocumento)cbTipoDocumento.SelectedItem).Id == 3)


            { if (Convert.ToInt64( txtNumDocumento.Text) <= 1000000000)
                {
                    MessageBox.Show("debe ingresar un numero mayor a 1000000000");

                }
                    
               if (Convert.ToInt64(txtNumDocumento.Text) >= 9999999999)
                {
                    MessageBox.Show("debe ingresar un numero menor  a 9999999999");
                }
                return;
            }

            if (string.IsNullOrEmpty(txtCosto .Text))
            {
                erpMensaje.SetError(txtCosto, "costo del servicio");
                return;
            }
         
            if (Convert.ToInt64(txtCosto.Text) <= 0)
            {
                erpMensaje.SetError(txtCosto, "Ingrese numero mayor a 0");
                return;
            }
            Elementos.RPS Registro = new Elementos.RPS();
            Registro.Nombre = txtNombre.Text;
            Registro.NumeroDocumento = Convert.ToInt64(txtNumDocumento.Text);
            Registro.CostoServicio = Convert.ToInt64(txtCosto.Text);

            MessageBox.Show("En hora buena!");
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Collections.Generic.List<Elementos.TipoDocumento>
                tiposDocumento = new List<Elementos.TipoDocumento>();

            tiposDocumento.Add(new Elementos.TipoDocumento() { Id = 3, Nombre = "NUIP" });
            tiposDocumento.Add(new Elementos.TipoDocumento() { Id = 4, Nombre = "Tarjeta de identidad" });
            tiposDocumento.Add(new Elementos.TipoDocumento() { Id = 1, Nombre = "Cedula Ciudania" });
            tiposDocumento.Add(new Elementos.TipoDocumento() { Id = 2, Nombre = "Tarjeta de  extranjeria" });
            
            cbTipoDocumento.DataSource = tiposDocumento;
            cbTipoDocumento.DisplayMember = "Nombre";

            System.Collections.Generic.List<Elementos.Rango>
            rangos = new List<Elementos.Rango>();

            rangos.Add(new Elementos.Rango() { Id = 1, Nombre = "Rango A" });
            rangos.Add(new Elementos.Rango() { Id = 2, Nombre = "Rango B" });
            rangos.Add(new Elementos.Rango() { Id = 3, Nombre = "Rango C" });

            cbRango.DataSource = rangos;
            cbRango.DisplayMember = "Nombre";

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        { double ValorApagar= 0 ;

            if (((Rango)cbRango.SelectedItem).Id == 1)

             {
                 ValorApagar = (Convert.ToInt64(txtCosto.Text) - ((Convert.ToInt64(txtCosto.Text) * 0.30)));

             }
            if (((Rango)cbRango.SelectedItem).Id == 2)
            {
                 ValorApagar = (Convert.ToInt64(txtCosto.Text) - ((Convert.ToInt64(txtCosto.Text) * 0.20)));

             }
            if (((Rango)cbRango.SelectedItem).Id == 3)
            {
                 ValorApagar = (Convert.ToInt64(txtCosto.Text) - ((Convert.ToInt64(txtCosto.Text) * 0.10)));
             }

             MessageBox.Show("Total a pagar " + ValorApagar);


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((int)e.KeyChar == 8 ||
              (int)e.KeyChar >= 48 && (int)e.KeyChar <= 59))
            {
                e.Handled = true;
            }
        }
    }
}
