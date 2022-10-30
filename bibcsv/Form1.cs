using System.Security.Cryptography.X509Certificates;

namespace bibcsv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
      
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "tytul";
            dataGridView1.Columns[1].Name = "autor";
            dataGridView1.Columns[2].Name = "id";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        public class Book
        {
            public string tytul { get; set; }
            public string autor { get; set; }
            public int id { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ZAPIS
            new ExportHelper().Export(loadCSV);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // ODCZYT
            dataGridView1.DataSource = loadCSV(textBox1.Text);
        }

        public List<Book> loadCSV(string csvFile)
        {
            var query = from l in File.ReadAllLines(csvFile)
                        let data = l.Split(",")
                        select new Book
                        {
                            tytul = data[0],
                            autor = data[1],
                            id = int.Parse(data[2])
                        };
            return query.ToList();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // ADD
            Form2 finfo = new Form2(this);
            finfo.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // BROWSE
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            textBox1.Text = dlg.FileName;
        }
    }
}