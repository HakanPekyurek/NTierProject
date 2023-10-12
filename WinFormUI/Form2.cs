using Business.DesignPatters.GenericRepository.Concrete;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormUI.ViewModels;

namespace WinFormUI
{
    public partial class Form2 : Form
    {
        ProductRepository _productRep;
        CategoryRepository _categoryRep;

        public Form2()
        {
            InitializeComponent();
            _productRep = new ProductRepository();
            _categoryRep = new CategoryRepository();
        }

        void ListCategories()
        {
            cmbCategories.DataSource = _categoryRep.Select(h => new CategoryVM
            {
                Id = h.Id,
                CategoryName = h.CategoryName,
                Description = h.Description
            }).ToList();

            cmbCategories.DisplayMember = "CategoryName";
            cmbCategories.ValueMember = "Id";
        }

        void ListProducts()
        {
            lstProducts.DataSource = _productRep.Select(h => new ProductVM
            {
                Id = h.Id,
                ProductName = h.ProductName,
                UnitPrice = h.UnitPrice,
                CategoryId = h.CategoryId,
                CategoryName = h.Category == null ? "No Category" : h.Category.CategoryName
            }).ToList();
        }

        ProductVM _selected;

        private void Form2_Load(object sender, EventArgs e)
        {
            ListProducts();
            ListCategories();
            cmbCategories.SelectedIndex = -1;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductName.Text.Trim()))
            {
                MessageBox.Show("Please enter product Name");
            }

            try
            {
                Product product = new Product();

                product.ProductName = txtProductName.Text;
                product.UnitPrice = Convert.ToDecimal(txtPrice.Text);
                if (cmbCategories.SelectedIndex > -1)
                    product.CategoryId = Convert.ToInt32(cmbCategories.SelectedValue);

                _productRep.Add(product);
                ListProducts();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void lstProducts_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndex > -1)
            {
                _selected = (ProductVM)lstProducts.SelectedItem;
                txtProductName.Text = _selected.ProductName;
                txtPrice.Text = _selected.UnitPrice.ToString();
                cmbCategories.SelectedValue = _selected.CategoryId != null ? _selected.CategoryId : -1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected != null)
            {
                Product toBeDeleted = _productRep.Find(_selected.Id);
                _productRep.Delete(toBeDeleted);
                _selected = null;
                txtProductName.Text = null;
                txtPrice.Text = null;
                cmbCategories.SelectedIndex = -1;
                ListProducts();
            }
            else
            {
                MessageBox.Show("Select a category!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selected != null)
                {
                    Product toBeUpdated = _productRep.Find(_selected.Id);
                    toBeUpdated.ProductName = txtProductName.Text;
                    toBeUpdated.UnitPrice = Convert.ToDecimal(txtPrice.Text);
                    if (cmbCategories.SelectedIndex > -1)
                        toBeUpdated.CategoryId = Convert.ToInt32(cmbCategories.SelectedValue);
                    _productRep.Update(toBeUpdated);
                    ListProducts();
                    _selected = null;
                    txtPrice.Text = null;
                    txtProductName.Text = null;
                    cmbCategories.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Select a Product!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
