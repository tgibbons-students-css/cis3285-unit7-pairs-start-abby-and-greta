using Domain;
using Services;
using System;
using System.Windows.Forms;

namespace AccountsForms
{
    /// <summary>
    /// This is the main GUI form for the accounts
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// accService is the link to the accounts through the 
        /// IAccountServices interface
        /// </summary>
        IAccountServices accService = new AccountService();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create a new account button. Only do so if the name of the account is not null or plain white space.
        /// Clear the text area when added. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAccount_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAccountName.Text))
            {
                string accountName = txtAccountName.Text;
                listBoxAccounts.Items.Add(accountName);
                accService.CreateAccount(accountName, AccountType.Silver);
                txtAccountName.ResetText();
            }
        }

        /// <summary>
        /// Account listbox item selected
        /// Find the account and update the balance displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accName = listBoxAccounts.SelectedItem.ToString();
            updateBalanceText(accName);
            updateRewardsPointsText(accName);
        }

        /// <summary>
        /// Adds the amount to deposit into the selected account.
        /// Updates the account balance text box and the rewards points text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeposit_Click_1(object sender, EventArgs e)
        {
            string selectedAcct = listBoxAccounts.SelectedItem.ToString();
            decimal depositAmount = decimal.Parse(txtDepositAmount.Text);

            accService.Deposit(selectedAcct, depositAmount);

            txtDepositAmount.ResetText();
            updateBalanceText(selectedAcct);
            updateRewardsPointsText(selectedAcct);
        }

        /// <summary>
        /// Subtracts the amount to withdraw from the selected account.
        /// Updates the account balance text box. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWithDrawal_Click_1(object sender, EventArgs e)
        {
            string selectedAcct = listBoxAccounts.SelectedItem.ToString();
            decimal withdrawalAmount = decimal.Parse(txtWithdrawalAmount.Text);

            accService.Withdrawal(selectedAcct, withdrawalAmount);

            txtWithdrawalAmount.ResetText();
            updateBalanceText(selectedAcct);
        }

        /// <summary>
        /// Updates the amount displayed in the balance text box
        /// </summary>
        /// <param name="accName"></param>
        private void updateBalanceText(string accName)
        {
            decimal balance = accService.GetAccountBalance(accName);
            txtBalance.Text = balance.ToString();
        }

        /// <summary>
        /// Updates the amount displayed in the rewards points text box
        /// </summary>
        /// <param name="accName"></param>
        private void updateRewardsPointsText(string accName)
        {
            decimal rewardPoints = accService.GetRewardPoints(accName);
            txtRewardPoints.Text = rewardPoints.ToString();
        }
    }
}
