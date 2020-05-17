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
using System.Xml.Serialization;

namespace lab8_student
{
    public partial class FormFindAndARG : Form
    {
        static public List<Student> students = new List<Student>();
        static public List<Student> SaveStudents = new List<Student>();
        public FormFindAndARG(List<Student> arrayOfStudents)
        {
            InitializeComponent();
            students = arrayOfStudents;

        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SaveStudents.Clear();
            List<Student> FindOfStudents = new List<Student>();
            FindOfStudents.AddRange(students);
            if (checkBox1.Checked == true && textBox1.Text!="")
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.FIO.Equals(textBox1.Text)==true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                }
            }
            if (checkBox2.Checked == true && textBox2.Text != "")
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.NumBook.Equals(UInt64.Parse(textBox2.Text)) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                }
            }
            if (checkBox4.Checked == true)
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.Curs.Equals(ushort.Parse(numericUpDown2.Value.ToString())) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                };
            }
            if (checkBox3.Checked == true)
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.CodeG.Equals(cmbBoxCodeG.Text) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                }
            }
            if (checkBox6.Checked == true)
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.Discipline.Equals( cmbBoxDisciplina.Text) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                }
            }
            if (checkBox5.Checked==true)
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.Rating.Equals(UInt16.Parse(numericUpDown3.Value.ToString())) == true
                                             select i;
                Student st=FindOfStudents.First();
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                }
            }

            foreach (Student st in FindOfStudents)
                listBox1.Items.Add(st.FIO + " " + st.Curs + " " + st.NumBook + " " + st.CodeG + " " + st.Discipline + " " + st.Rating);
            SaveStudents.AddRange(FindOfStudents);

            //int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

            //IEnumerable<int> evens1 = from i in numbers
            //                          where i % 2 == 0
            //                          select i;
            //foreach (int i in evens1)
            //    MessageBox.Show(i.ToString());
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void FormFindAndARG_Load(object sender, EventArgs e)
        {

            try
            {
                foreach (Student st in students)
                    listBox1.Items.Add(st.FIO + " " + st.Curs + " " + st.NumBook + " " + st.CodeG + " " + st.Discipline + " " + st.Rating);

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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresher_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Student st in students)
                listBox1.Items.Add(st.FIO + " " + st.Curs + " " + st.NumBook + " " + st.CodeG + " " + st.Discipline + " " + st.Rating);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                formatter.Serialize(fs, SaveStudents);
                MessageBox.Show("File сохранен");
            }
        }

        private void btnARG_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            SaveStudents.Clear();
            List<Student> FindOfStudents = new List<Student>();
            FindOfStudents.AddRange(students);
            if (checkBox1.Checked == true && textBox1.Text != "")
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.FIO.Equals(textBox1.Text) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                }
            }
            if (checkBox2.Checked == true && textBox2.Text != "")
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.NumBook.Equals(UInt64.Parse(textBox2.Text)) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                }
            }
            if (checkBox4.Checked == true)
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.Curs.Equals(ushort.Parse(numericUpDown2.Value.ToString())) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                };
            }
            if (checkBox3.Checked == true)
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.CodeG.Equals(cmbBoxCodeG.Text) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                }
            }
            if (checkBox6.Checked == true)
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.Discipline.Equals(cmbBoxDisciplina.Text) == true
                                             select i;
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                }
            }
            if (checkBox5.Checked == true)
            {
                IEnumerable<Student> evens = from i in FindOfStudents
                                             where i.Rating.Equals(UInt16.Parse(numericUpDown3.Value.ToString())) == true
                                             select i;
                Student st = FindOfStudents.First();
                if (evens.ToList().Count != 0)
                {
                    FindOfStudents = new List<Student>(evens);
                }
            }

            foreach (Student st in FindOfStudents)
                listBox1.Items.Add(st.FIO + " " + st.Curs + " " + st.NumBook + " " + st.CodeG + " " + st.Discipline + " " + st.Rating);
            SaveStudents.AddRange(FindOfStudents);

            double AVG = 0;
            foreach (Student st in SaveStudents)
            {
                AVG += st.Rating;
            }
            AVG = AVG / SaveStudents.Count;
            MessageBox.Show("Средняя оценка найденной группы записей:"+AVG.ToString());
        }
    }
}
