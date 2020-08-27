using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Permissions;
using System.Text;

namespace SQL_Database
{
    /// <summary>
    /// Transaction class.
    /// Conteins all the informations about transaction.
    /// </summary>
    public class Transaction
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string ip_address { get; set; }
        public string country { get; set; }
        public string credit_card_number { get; set; }
        public string credit_card_type { get; set; }
        public string amount { get; set; }

        public string Info
        {
            get 
            {
                return $"Transaction ID: { id } - { first_name } { last_name } ( { email } ) - Amount: { amount }";
            }
            
        }

    }
}
