using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyAccounting.DataLayer;
using MyAccounting.DataLayer.Context;
using ValidationComponents;

namespace MyAccounting.App
{
    public partial class frmAddOrEditPerson : Form
    {
        private UnitOfWork _uow = new UnitOfWork();
        public frmAddOrEditPerson()
        {
            InitializeComponent();
        }

        private void btnPicSelect_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                bool genderChecked = true;

                if (radMen.Checked)
                {
                    genderChecked = true; //Men Means true
                }

                if (radFemale.Checked)
                {
                    genderChecked = false; // Female Means false
                }

                var person = new Persons
                {
                    Name = txtName.Text,
                    Family = txtFamily.Text,
                    Mobile = txtMobile.Text,
                    Address = txtAddress.Text,
                    Gender = genderChecked,
                    Image = "nophoto"
                };

                _uow.personRepository.Add(person);

                DialogResult = DialogResult.OK;
            }
        }
    }
}
