using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_Database
{
    public partial class Viewer : Form
    {
        List<Transaction> transactions = new List<Transaction>();

        public Viewer()
        {
            InitializeComponent();

            UpdateBinding();
        }

        private void UpdateBinding()
        {
            transactionsListBox.DataSource = transactions;
            transactionsListBox.DisplayMember = "Info";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            transactions = db.GetTransactions(lastNameTextBox.Text);

            UpdateBinding();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            db.AddTransaction(firstNameText.Text, lastNameText.Text, emailText.Text, ipAddressText.Text, countryText.Text, creditCardNumberLabelText.Text, creditCardTypeText.Text, amountText.Text);

            firstNameText.Text = "";
            lastNameText.Text = "";
            emailText.Text = "";
            ipAddressText.Text = "";
            countryText.Text = "";
            creditCardNumberLabelText.Text = "";
            creditCardTypeText.Text = "";
            amountText.Text = "";
        }
    }
}