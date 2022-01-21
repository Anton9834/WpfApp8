using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public DataTable Select(string selectSQL) 
        {
            DataTable dataTable = new DataTable("dataBase");                
                                                                           
            const string ConnectionString = "server=DESKTOP-7PPGAEU\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=FastFood;";
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();                                          
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          
            sqlCommand.CommandText = selectSQL;                             
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); 
            sqlDataAdapter.Fill(dataTable);                                 
            return dataTable;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Phone.Text.Length > 0)     
            {
                if (Password.Text.Length > 0)       
                {                   
                    DataTable dt_user = Select("SELECT * FROM [dbo].[Employee] WHERE [Phone] = '" + Phone.Text + "' AND [Password] = '" + Password.Text + "'");
                    if (dt_user.Rows.Count > 0)       
                    {
                        MessageBox.Show("Пользователь авторизовался");       
                    }
                    else MessageBox.Show("Пользователь не найден"); 
                }
                else MessageBox.Show("Введите пароль"); 
            }
            else MessageBox.Show("Введите логин"); 
        }
    }
}
