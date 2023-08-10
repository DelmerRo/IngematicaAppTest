using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngematicaAppTest.Model;
using IngematicaAppTest.Service;

namespace IngematicaAppTest
{
    public partial class FrmTest : Form
    {
        private CalculoService calculoService;
        public FrmTest()
        {
            InitializeComponent();

            InitializeCombos();

            calculoService = new CalculoService();

            btnCalcular.Click += BtnCalcular_Click;
            btnLimpiar.Click += BtnLimpiar_Click;

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            dtpFechaInicial.Value = DateTime.Now;
            cbLocalidadDestino.SelectedIndex = -1;
            cbTipoTransporte.SelectedIndex = -1;
            cbVialidad.SelectedIndex = -1;
            txtDiasDemora.Clear();
            txtFechaLlegada.Clear();
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaPartida = dtpFechaInicial.Value;
                int idLocalidadDestino = ((LocalidadModel)cbLocalidadDestino.SelectedItem).IdLocalidad;
                int idTipoTransporte = ((TipoTransporteModel)cbTipoTransporte.SelectedItem).IdTipoTransporte;
                int idVialidad = ((VialidadModel)cbVialidad.SelectedItem).IdVialidad;

                DateTime fechaLlegada = calculoService.CalcularFechaLlegada(fechaPartida, idLocalidadDestino, idTipoTransporte, idVialidad);

                int diasDemora = (int)(fechaLlegada - fechaPartida).TotalDays;

                txtDiasDemora.Text = diasDemora.ToString();
                txtFechaLlegada.Text = fechaLlegada.ToShortDateString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha Ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeCombos()
        {
            InitializeComboTipoTransporte();

            InitializeComboLocalidad();

            InitializeComboVialidad();

        }

        private void InitializeComboVialidad()
        {
            _ = new List<VialidadModel>();
            VialidadService vialidadService = new VialidadService();
            List<VialidadModel> vialidadList = vialidadService.GetList();

            var bindingSourceVialidad = new BindingSource();
            bindingSourceVialidad.DataSource = vialidadList;

            cbVialidad.DataSource = bindingSourceVialidad;
            cbVialidad.DisplayMember = "Nombre";
            cbVialidad.ValueMember = "Id";
        }

        private void InitializeComboTipoTransporte()
        {
            _ = new List<TipoTransporteModel>();
            TipoTransporteService tipoTransporteService = new TipoTransporteService();
            List<TipoTransporteModel> tipoTransporteList = tipoTransporteService.GetList();

            var bindingSourceTipoTransporte = new BindingSource();
            bindingSourceTipoTransporte.DataSource = tipoTransporteList;

            cbTipoTransporte.DataSource = bindingSourceTipoTransporte;
            cbTipoTransporte.DisplayMember = "Nombre";
            cbTipoTransporte.ValueMember = "Id";
        }

        private void InitializeComboLocalidad()
        {
            _ = new List<LocalidadModel>();
            LocalidadService localidadService = new LocalidadService();
            List<LocalidadModel> localidadList = localidadService.GetList();

            var bindingSourceLocalidad = new BindingSource();
            bindingSourceLocalidad.DataSource = localidadList;

            cbLocalidadDestino.DataSource = bindingSourceLocalidad;
            cbLocalidadDestino.DisplayMember = "Nombre";
            cbLocalidadDestino.ValueMember = "Id";
        }
    }
}
