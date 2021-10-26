using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyAccounting.DataLayer.Context;
using MyAccounting.DataLayer.Repositories;

namespace MyAccounting.App
{
    public partial class frmInfoPersons : Form
    {
        private UnitOfWork _uow = new UnitOfWork();
        public frmInfoPersons()
        {
            InitializeComponent();
        }

        private void frmInfoPersons_Load(object sender, EventArgs e)
        {
            dgvPersons.AutoGenerateColumns = false;
            dgvPersons.DataSource = _uow.personRepository.Get();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvPersons.DataSource = _uow.personRepository.Search(c =>
                c.Name.Contains(txtSearch.Text) || c.Family.Contains(txtSearch.Text) ||
                c.Mobile.Contains(txtSearch.Text));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmAddOrEditPerson frmAddOrEditPerson = new frmAddOrEditPerson();
            frmAddOrEditPerson.ShowDialog();
        }
    }
}
