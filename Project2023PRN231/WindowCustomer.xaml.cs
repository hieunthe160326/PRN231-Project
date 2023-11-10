using Project2023PRN221.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace Project2023PRN221
{
    /// <summary>
    /// Interaction logic for WindowCustomer.xaml
    /// </summary>
    public partial class WindowCustomer : Window
    {
        HttpClient client = new HttpClient();
        private PRN231PROJECTContext context;
        public WindowCustomer()
        {
            context = new PRN231PROJECTContext();
            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:7135/api/Customers/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            GetListCustomerName();
            LoadData();
        }

        private async void GetListCustomerName()
        {
            var res = await client.GetStringAsync("GetCustomernNameList");
            txtSearch.ItemsSource = JsonConvert.DeserializeObject<List<string>>(res);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private async void GetListCustomer()
        {
            var res = await client.GetStringAsync("GetCustomerList");
            listCus.ItemsSource = JsonConvert.DeserializeObject<List<TblKhachHang>>(res);
        }

        private void LoadData()
        {
            GetListCustomer();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtCustomerId.Text = String.Empty;
            txtCustomerName.Text = String.Empty;
            txtCustomerAddress.Text = String.Empty;
            txtCustomerDob.Text = String.Empty;
            if (rbFemale.IsChecked == true)
            {
                rbFemale.IsChecked = false;
            }
            else
            {
                rbMale.IsChecked = false;
            }
        }

        private void listView_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                var gender = ((TblKhachHang)item).Gt;

                if (gender == true)
                {
                    rbMale.IsChecked = true;
                }
                else
                {
                    rbFemale.IsChecked = true;
                }
            }
        }


        private async void AddCustomer(TblKhachHang c)
        {
            await client.PostAsJsonAsync("AddCustomer", c);
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TblKhachHang t = context.TblKhachHangs.OrderBy(a => a.MakH).LastOrDefault();
                int newid = Convert.ToInt32(t.MakH.ToString().Substring(2)) + 1;
                String nid = "KH" + newid;
                var customer = new TblKhachHang
                {
                    MakH = nid,
                    TenKh = txtCustomerName.Text,
                    Gt = rbMale.IsChecked == true ? true : false,
                    Diachi = txtCustomerAddress.Text,
                    NgaySinh = DateTime.Parse(txtCustomerDob.Text),
                    Active = true
                };
                if (customer != null)
                {
                    //context.TblKhachHangs.Add(customer);
                    //context.SaveChanges();
                    AddCustomer(customer);
                    MessageBox.Show("Add customer successfully");
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void UpdateCustomer(TblKhachHang c)
        {
            await client.PutAsJsonAsync("UpdateCustomer/" + txtCustomerId.Text, c);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            bool gender = true;
            if (rbFemale.IsChecked == true)
            {
                gender = false;
            }
            try
            {
                TblKhachHang c = context.TblKhachHangs.FirstOrDefault(item => item.MakH.Equals(txtCustomerId.Text));
                if (c != null)
                {
                    c.TenKh = txtCustomerName.Text;
                    c.Gt = gender;
                    c.Diachi = txtCustomerAddress.Text;
                    c.NgaySinh = DateTime.Parse(txtCustomerDob.Text);

                    if (context.SaveChanges() > 0)
                    {
                        LoadData();
                        MessageBox.Show("Update customer successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

private void btnDelete_Click(object sender, RoutedEventArgs e)
{
    try
    {
        TblKhachHang c = context.TblKhachHangs.FirstOrDefault(a => a.MakH.Equals(txtCustomerId.Text));
        if (c != null)
        {
            c.Active = false;

            if (context.SaveChanges() > 0)
            {
                LoadData();
                MessageBox.Show("Delete customer successfully");
            }

        }
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}

private void btnBack_Click(object sender, RoutedEventArgs e)
{
    MainWindow mainWindow = new MainWindow();
    mainWindow.Show();
    this.Hide();
}

private void btnSearch_Click(object sender, RoutedEventArgs e)
{
    var customer = context.TblKhachHangs.FirstOrDefault(a => a.TenKh.Contains(txtSearch.Text) || a.MakH.Contains(txtSearch.Text) || a.Diachi.Contains(txtSearch.Text));
    if (customer != null)
    {
        txtCustomerName.Text = customer.TenKh;
        txtCustomerId.Text = customer.MakH.ToString();
        txtCustomerAddress.Text = customer.Diachi;
        txtCustomerDob.Text = customer.NgaySinh.ToString();
        if (customer.Gt == true)
        {
            rbMale.IsChecked = true;
        }
        else
        {
            rbFemale.IsChecked = true;
        }
    }
    else
    {
        MessageBox.Show("The customer doesn't exist");
    }
}
    }
}
