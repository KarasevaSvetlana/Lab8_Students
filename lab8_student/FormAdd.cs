using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8_student
{
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }
        Student student = new Student();

        private void FormAdd_Load(object sender, EventArgs e)
        {
            try
            {
                string pathCodeG = "CodeG.txt";

                using (StreamReader sr = new StreamReader(pathCodeG, System.Text.Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        cmbBoxCodeG.Items.Add(line);
                    }
                }
                string pathDisciplina = "Disciplina.txt";

                using (StreamReader sr = new StreamReader(pathDisciplina, System.Text.Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        cmbBoxDisciplina.Items.Add(line);
                    }
                }
                cmbBoxCodeG.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbBoxDisciplina.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbBoxCodeG.SelectedIndex = 0;
                cmbBoxDisciplina.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form1.flagAdd = true;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            textBox1.Text.Trim(' ');
            textBox2.Text.Trim(' ');
            if (textBox1.Text != "" || textBox2.Text != "")
            {
                Student student = new Student(textBox1.Text, UInt64.Parse(textBox2.Text), UInt16.Parse(numericUpDown2.Value.ToString()), cmbBoxCodeG.Text, cmbBoxDisciplina.Text, UInt16.Parse(numericUpDown3.Value.ToString()));
                Form1.students.Add(student);
                Form1.flagAdd = true;
                this.Close();
            }
            else { MessageBox.Show("некоторые поля не заполнены, или заполнены неверно"); }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar)| e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }
    }
}
