using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SortBD.NewFolder;

namespace SortBD
{
    public partial class Form1 : Form
    {
        Model1 database = new Model1();
        List<Pavilion> pavilions = new List<Pavilion>();
        List<Pavilion> PavilionsChange = new List<Pavilion>();
        List<string> pavilionsProp = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PavilionsChange = pavilions = database.Pavilion.ToList();
            loadStartData();
            LoadDataCombo();
        }
        private void loadStartData()//Загрузка данных списка в источник данных
        {
            pavilionBindingSource.DataSource = PavilionsChange;
        }

        private void LoadOrder()
        {
            if (checkBox1.Checked == false)
            {
                switch (comboBox1.SelectedItem)
                {
                    case "Num_pav": PavilionsChange = PavilionsChange.OrderBy(p => p.Num_pav).ToList(); break;
                    case "ID_mall": PavilionsChange = PavilionsChange.OrderBy(p => p.ID_mall).ToList(); break;
                    case "Floor": PavilionsChange = PavilionsChange.OrderBy(p => p.Floor).ToList(); break;
                    case "Status": PavilionsChange = PavilionsChange.OrderBy(p => p.Status).ToList(); break;
                    case "Square": PavilionsChange = PavilionsChange.OrderBy(p => p.Square).ToList(); break;
                    case "Cost_meter": PavilionsChange = PavilionsChange.OrderBy(p => p.Cost_meter).ToList(); break;
                    case "Coeff_cost": PavilionsChange = PavilionsChange.OrderBy(p => p.Coeff_cost).ToList(); break;
                }
            }

            else if (checkBox1.Checked == true)
            {
                switch (comboBox1.SelectedItem)
                {
                    case "Num_pav": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Num_pav).ToList(); break;
                    case "ID_mall": PavilionsChange = PavilionsChange.OrderByDescending(p => p.ID_mall).ToList(); break;
                    case "Floor": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Floor).ToList(); break;
                    case "Status": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Status).ToList(); break;
                    case "Square": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Square).ToList(); break;
                    case "Cost_meter": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Cost_meter).ToList(); break;
                    case "Coeff_cost": PavilionsChange = PavilionsChange.OrderByDescending(p => p.Coeff_cost).ToList(); break;
                }
            }

            loadStartData();
        }
        private void LoadDataCombo()//Загрузщка данных в comboBox1
        {
            //загружаем поля
            pavilionsProp = typeof(Pavilion).GetProperties().Select(x => x.Name).ToList();
            //удаляем поля - связи
            pavilionsProp.RemoveRange(pavilionsProp.Count - 2, 2);
            //загружаем полученные данные в comboBox1
            comboBox1.DataSource = pavilionsProp;
            //выбираем первый элемент в comboBox1
            comboBox1.SelectedIndex = 0;
        }

        private void pavilionBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PavilionsChange = pavilions.Where(x => x.Status.Contains(textBox1.Text) ).ToList();
            LoadOrder();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pavilionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
