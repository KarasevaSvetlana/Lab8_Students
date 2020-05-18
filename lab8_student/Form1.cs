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
using System.Xml;
using System.Xml.Serialization;

namespace lab8_student
{
    public partial class Form1 : Form
    {
        public static bool flagAdd = false;
        static public List<Student> students = new List<Student>();
        
        public Form1()
        {
            InitializeComponent();
           
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            int errorInXml = 0;
            int record = 1;
            string filename = "Students.xml";
            LoadMyFile(filename);
            foreach (Student st in students)
                listBox1.Items.Add(st.FIO + " " + st.Curs + " " + st.NumBook + " " + st.CodeG + " " + st.Discipline + " " + st.Rating);
            if (listBox1.Items.Count == 0)
            {
                btnFind.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            formAdd.ShowDialog();
            if (flagAdd == true)
            {
                Student st = students.Last();
                listBox1.Items.Add(st.FIO + " " + st.Curs + " " + st.NumBook + " " + st.CodeG + " " + st.Discipline + " " + st.Rating);
            }

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            students.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FormFindAndARG formFindAndARG = new FormFindAndARG(students);
            formFindAndARG.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
                XmlSerializer formatter = new XmlSerializer(typeof(List<Student>));
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    formatter.Serialize(fs, students);
                MessageBox.Show("File сохранен");
                }
           

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDel.Enabled = true;
            btnFind.Enabled = true;
            if (listBox1.SelectedIndex == -1)
            {
                btnDel.Enabled = false;
                btnFind.Enabled = false;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            LoadMyFile(filename);
            listBox1.Items.Clear();
            foreach (Student st in students)
                listBox1.Items.Add(st.FIO + " " + st.Curs + " " + st.NumBook + " " + st.CodeG + " " + st.Discipline + " " + st.Rating);
        }
        public static int LoadMyFile(string filename)
        {
            int errorInXml = 0;
            int record = 1;
            students.Clear();
            try
            {
                //asdasas
                XmlDocument xDoc = new XmlDocument();

                xDoc.Load(filename);
                errorInXml = 7;
                // получим корневой элемент
                XmlElement xRoot = xDoc.DocumentElement;


                // обход всех узлов в корневом элементе
                foreach (XmlNode xnode in xRoot)
                {
                    string Element = "";
                    Student student = new Student();

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {

                        // если узел - company

                        if (childnode.Name == "FIO")
                        {
                            errorInXml = 1;
                            student.FIO = childnode.InnerText;
                            // Element += childnode.InnerText + " ";
                        }
                        // если узел age
                        if (childnode.Name == "NumBook")
                        {
                            errorInXml = 2;
                            student.NumBook = UInt64.Parse(childnode.InnerText);
                            // Element += childnode.InnerText + " ";
                        }
                        if (childnode.Name == "Curs")
                        {
                            errorInXml = 3;
                            student.Curs = UInt16.Parse(childnode.InnerText);
                            // Element += childnode.InnerText + " ";
                        }
                        // если узел age
                        if (childnode.Name == "CodeG")
                        {
                            errorInXml = 4;
                            student.CodeG = childnode.InnerText;
                            // Element += childnode.InnerText + " ";
                        }
                        if (childnode.Name == "Discipline")
                        {
                            errorInXml = 5;
                            student.Discipline = childnode.InnerText;
                            // Element += childnode.InnerText + " ";
                        }
                        // если узел age
                        if (childnode.Name == "Rating")
                        {
                            errorInXml = 6;
                            student.Rating = UInt16.Parse(childnode.InnerText);
                            // Element += childnode.InnerText + " ";
                        }

                    }
                    errorInXml = -1;
                    record++;
                    students.Add(student);
                }

            }
            catch (Exception ex)
            {
                switch (errorInXml)
                {
                    case 0: MessageBox.Show("xml-файл " + filename + " не найден"); break;
                    case 1: MessageBox.Show("Данные с xml-документа о FIO в записи" + record + " были прочитаны неверно"); break;
                    case 2: MessageBox.Show("Данные с xml-документа о NumBook в записи" + record + " были прочитаны неверно"); break;
                    case 3: MessageBox.Show("Данные с xml-документа о Curs в записи" + record + " были прочитаны неверно"); break;
                    case 4: MessageBox.Show("Данные с xml-документа о CodeG в записи" + record + " были прочитаны неверно"); break;
                    case 5: MessageBox.Show("Данные с xml-документа о Discipline в записи" + record + " были прочитаны неверно"); break;
                    case 6: MessageBox.Show("Данные с xml-документа о Rating в записи " + record + " были прочитаны неверно"); break;
                    case 7: MessageBox.Show(ex.Message); break;
                    default: MessageBox.Show(ex.Message); errorInXml = 8; break;
                }
                MessageBox.Show("Загрузка последующих записей остановлена");
            }
            return errorInXml;
        }

    }

}
