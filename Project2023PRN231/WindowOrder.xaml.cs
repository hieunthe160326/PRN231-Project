﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project2023PRN221.Models;
using Project2023PRN231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Project2023PRN221
{
    /// <summary>
    /// Interaction logic for WindowOrder.xaml
    /// </summary>
    public partial class WindowOrder : Window
    {
        HttpClient client = new HttpClient();
        public WindowOrder()
        {
            context = new PRN231PROJECTContext();
            client.BaseAddress = new Uri("https://localhost:7135/api/Orders/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            InitializeComponent();
            GetListProductName();
            btnOrder.IsEnabled = false;
            btnUpdateOrder.IsEnabled = false;
            btnRemoveOrder.IsEnabled = false;
            LoadData();
        }

        private async void GetListProductName()
        {
            var res = await client.GetStringAsync("getlistproductname");
            cbProductName.ItemsSource = JsonConvert.DeserializeObject<List<string>>(res);
        }

        private async void GetListOrderDetail()
        {
            var res = await client.GetStringAsync("getorderdetaillist");
            listOrder.ItemsSource = JsonConvert.DeserializeObject<List<OrderDetailDTO>>(res); ;
        }

        private async void GetListOrderDetailById()
        {
            var res = await client.GetStringAsync("getorderdetaillistbyid/" + txtOrderId.Text);
            listOrder.ItemsSource = JsonConvert.DeserializeObject<List<OrderDetailDTO>>(res); ;
        }

        private void LoadData()
        {
            if (txtOrderId.Text != String.Empty)
            {
                GetListOrderDetailById();
            }
            else
            {
                GetListOrderDetail();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtCustomerId.Text = String.Empty;
            txtCustomerName.Text = String.Empty;
            txtCustomerAddress.Text = String.Empty;
            txtOrderId.Text = String.Empty;
            txtOrderDate.Text = String.Empty;
            cbProductName.Text = String.Empty;
            txtPrice.Text = String.Empty;
            txtQuantity.Text = String.Empty;

            LoadData();
            btnUpdateOrder.IsEnabled = false;
            btnRemoveOrder.IsEnabled = false;
        }

        private async void AddOrder(TblHoadon p)
        {
            await client.PostAsJsonAsync("addorder", p);
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TblHoadon p = new TblHoadon
                {
                    MaKh = txtCustomerId.Text,
                    NgayHd = DateTime.Today,
                };
                AddOrder(p);
                btnUpdateOrder.IsEnabled = true;
                btnRemoveOrder.IsEnabled = true;
                btnOrder.IsEnabled = false;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool exist = true;
        private async void CheckOrderDetailExist(int orderId, string productName)
        {
            var res = await client.GetStringAsync("checkorderdetailexist/" + orderId + "/" + productName);
            exist = JsonConvert.DeserializeObject<bool>(res);
        }

        private async void AddOrderDetail(TblChiTietHd p)
        {
            await client.PostAsJsonAsync("addorderdetail", p);
        }

        private async void UpdateOrderDetailQuantity(int orderId, string productName, int quantity)
        {
            await client.PutAsJsonAsync("updateorderdetail"+"/"+orderId+"/"+productName, quantity);
        }
        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            TblChiTietHd data = context.TblChiTietHds.FirstOrDefault(a => a.MaHd == decimal.Parse(txtOrderId.Text)
         && a.MaHangNavigation.TenHang.Equals(cbProductName.Text));
            //CheckOrderDetailExist(Int32.Parse(txtOrderId.Text), cbProductName.Text);
            if (data != null)
            {
                data.Soluong = Int32.Parse(txtQuantity.Text);
                if (context.SaveChanges() > 0)
                {
                    LoadData();
                }
                //UpdateOrderDetailQuantity(Int32.Parse(txtOrderId.Text), cbProductName.Text, Int32.Parse(txtQuantity.Text));
            }
            else
            {
                try
                {
                    TblChiTietHd p = new TblChiTietHd
                    {
                        MaHd = decimal.Parse(txtOrderId.Text),
                        MaHang = txtProductId.Text.ToString(),
                        Soluong = Int32.Parse(txtQuantity.Text)
                    };
                    //AddOrderDetail(p);
                    context.TblChiTietHds.Add(p);
                    if (context.SaveChanges() > 0)
                    {
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void DeleteOrderDetail(int id)
        {
            await client.DeleteAsync("deleteorderdetail/" + id);
        }
        private void btnRemoveOrder_Click(object sender, RoutedEventArgs e)
        {

            if (txtOrderId.Text != String.Empty)
            {
                int a = Int32.Parse(txtOrderId.Text);
                DeleteOrderDetail(a);
                LoadData();
            }
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void listView_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                txtQuantity.Text = item.GetType().GetProperty("Soluong").GetValue(item, null).ToString();
                txtOrderId.Text = item.GetType().GetProperty("MaHd").GetValue(item, null).ToString();
                txtCustomerId.Text = item.GetType().GetProperty("MaKh").GetValue(item, null).ToString();
                cbProductName.Text = item.GetType().GetProperty("TenHang").GetValue(item, null).ToString();
            }
        }

        private void txtCustomerId_TextChanged(object sender, TextChangedEventArgs e)
        {
            var customer = context.TblKhachHangs.FirstOrDefault(a => a.MakH.Equals(txtCustomerId.Text) && a.Active == true);
            if (customer != null)
            {
                txtCustomerName.Text = customer.TenKh.ToString();
                txtCustomerAddress.Text = customer.Diachi.ToString();
            }
        }

        private void cbProductName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbProductName.Text != String.Empty)
            {
                var product = context.TblMatHangs.FirstOrDefault(a => a.TenHang.Equals(cbProductName.SelectedItem.ToString()) && a.Active == true);
                if (product != null)
                {
                    txtPrice.Text = product.Gia.ToString();
                    txtProductId.Text = product.MaHang.ToString();
                }
            }
        }

        private void txtOrderId_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtOrderId.Text != String.Empty)
            {
                var order = context.TblHoadons.FirstOrDefault(a => a.MaHd == decimal.Parse(txtOrderId.Text));
                if (order != null)
                {
                    txtOrderDate.Text = order.NgayHd.ToString();
                    txtCustomerId.Text = order.MaKh.ToString();
                    var data = context.TblKhachHangs.FirstOrDefault(a => a.MakH.Equals(txtCustomerId.Text));
                    if (data != null)
                    {
                        txtCustomerName.Text = data.TenKh.ToString();
                        txtCustomerAddress.Text = data.Diachi.ToString();
                    }

                    btnUpdateOrder.IsEnabled = true;
                    btnRemoveOrder.IsEnabled = true;
                    btnOrder.IsEnabled = false;

                    LoadData();
                }
                else
                {
                    btnOrder.IsEnabled = true;
                    btnUpdateOrder.IsEnabled = false;
                    btnRemoveOrder.IsEnabled = false;
                }
            }
        }
        private readonly PRN231PROJECTContext context;
    }
}
