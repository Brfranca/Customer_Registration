using CustomerRegistration.Models;
using CustomerRegistration.Services;
using NcMaster;
using System;
using System.Windows.Forms;

namespace CustomerRegistration
{
    public partial class Customer_Registration : Form
    {
        private RegisterService _service;

        public Customer_Registration()
        {
            InitializeComponent();

            _service = new RegisterService();

            cboBloodType.SelectedIndex = 0;
            cboGender.SelectedIndex = 0;
            cboSchooling.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ClientModel client = new ClientModel
                (
                    txtName.Text,
                    mtxtCpf.Text,
                    dtpBirth.Value,
                    cboGender.Text,
                    cboBloodType.Text,
                    txtNationality.Text,
                    cboSchooling.Text,
                    mtxtPhone.Text,
                    txtEmail.Text,
                    mtxtCEP.Text,
                    txtStreet.Text,
                    txtNumber.Text,
                    txtDistrict.Text,
                    txtCity.Text,
                    txtState.Text
                );

            string result = _service.RegisterClient(client);

            if (!string.IsNullOrWhiteSpace(result))
                MessageBox.Show(result);
            else
                MessageBox.Show("Cadastrado com sucesso!");
        }

        private void mtxtCEP_Leave(object sender, EventArgs e)
        {
            WebCEP cep = new WebCEP(mtxtCEP.Text);
            txtStreet.Text = cep.Logradouro;
            txtDistrict.Text = cep.Bairro;
            txtCity.Text = cep.Cidade;
            txtState.Text = cep.UF;
        }
    }
}
