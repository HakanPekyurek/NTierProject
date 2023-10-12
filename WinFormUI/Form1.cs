using Business.DesignPatters.GenericRepository.Concrete;
using Entities.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using WinFormUI.ViewModels;

namespace WinFormUI
{
    public partial class Form1 : Form
    {
        CategoryRepository _categoryRepository;
        public Form1()
        {
            InitializeComponent();
            _categoryRepository = new CategoryRepository();
        }

        void ListCategories()
        {
            lstCategories.DataSource = _categoryRepository.Select(h => new CategoryVM
            {
                Id = h.Id,
                CategoryName = h.CategoryName,
                Description = h.Description,
                Products = h.Products
            }).ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListCategories();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ListCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoryName.Text.Trim()))
            {
                MessageBox.Show("Please insert Category Name");
                return;
            }

            Category category = new Category
            {
                CategoryName = txtCategoryName.Text,
                Description = txtDescription.Text
            };

            _categoryRepository.Add(category);
            ListCategories();
        }

        CategoryVM _selected;
        private void lstCategories_Click(object sender, EventArgs e)
        {
            if (lstCategories.SelectedIndex > -1)
            {
                _selected = (CategoryVM)lstCategories.SelectedItem;
                txtCategoryName.Text = _selected.CategoryName;
                txtDescription.Text = _selected.Description;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected != null)
            {
                Category toBeDeleted = _categoryRepository.Find(_selected.Id);
                _categoryRepository.Delete(toBeDeleted);
                _selected = null;
                txtCategoryName.Text = null;
                txtDescription.Text = null;
                ListCategories();
            }
            else
            {
                MessageBox.Show("Select a category!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selected != null)
            {
                Category toBeUpdated = _categoryRepository.Find(_selected.Id);
                toBeUpdated.CategoryName = txtCategoryName.Text;
                toBeUpdated.Description = txtDescription.Text;
                _categoryRepository.Update(toBeUpdated);
                _selected = null;
                txtCategoryName.Text = null;
                txtDescription.Text = null;
                ListCategories();
            }
            else
            {
                MessageBox.Show("Select a category!");
            }
        }

        private void btnForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
