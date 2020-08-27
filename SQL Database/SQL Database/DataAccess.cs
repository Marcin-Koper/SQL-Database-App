using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace SQL_Database
{
    /// <summary>
    /// Class which contains methods handling database.
    /// </summary>
    /// <remarks>
    /// This class can search database and also adds new transaction to the database using stored procedures.
    /// </remarks>
    class DataAccess
    {
        /// <summary>
        /// Public List method which search database for transactions by last name.
        /// </summary>
        /// <param name="lastName">Last name of a person which transactions we're looking for.</param>
        /// <returns>List of transactions.</returns>
        public List<Transaction> GetTransactions(string lastName)
        {

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("TransactionsDB")))
            {
                
               var output = connection.Query<Transaction>("dbo.Transactions_GetByLastName @last_name", new { last_name = lastName }).ToList();
               return output;
            }

        }

        /// <summary>
        /// Public void method which adds new transaction to the database.
        /// </summary>
        /// <param name="FirstName">First name of a person which made a transaction.</param>
        /// <param name="LastName">Last name of a person which made a transaction.</param>
        /// <param name="Email">Email of a person which made a transaction.</param>
        /// <param name="IpAddress">IP address of a network from which transaction was made.</param>
        /// <param name="Country">Country from which transaction was made.</param>
        /// <param name="CreditCardNumber">Credtic card number used to pay.</param>
        /// <param name="CreditCardType">Credtic card type used to pay.</param>
        /// <param name="Amount">Amount of money used in transaction.</param>
        public void AddTransaction(string FirstName, string LastName, string Email, string IpAddress, string Country, string CreditCardNumber, string CreditCardType, string Amount)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString("TransactionsDB")))
            {
                Transaction newTransaction = new Transaction { first_name = FirstName, last_name = LastName, email = Email, ip_address = IpAddress, country = Country, credit_card_number = CreditCardNumber, credit_card_type = CreditCardType, amount = Amount};

                List<Transaction> transactions = new List<Transaction>();
                transactions.Add(newTransaction);

                connection.Execute("dbo.Transactions_Add @first_name, @last_name, @email, @ip_address, @country, @credit_card_number, @credit_card_type, @amount", transactions);

            }
        }
    }
}
