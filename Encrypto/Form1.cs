using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Encrypto
{
    public partial class Form1 : Form
    {
        //სტატიკური მასივები და ბუფერი ტექსტის წასაკითხად
        public static char[] symbols = new char[126];
        public static char[] key_symbols = { };
        public string read;

        
    public Form1()
        {
            InitializeComponent();
        }

        private string encrypt(string text)
        {
            //ყველა სიმბოლოს ჩაწერა მასივში
            int j = 0;
            for (int i = 0; i < 126; i++)
            {
                symbols[j] = (char)i;
                j++;
            }
            //სიმბოლოების მასივის აჩეხვა
            Random randomizer = new Random(text.Length);
            key_symbols = symbols.OrderBy(x => randomizer.Next()).ToArray();

            //მოცემული ტექსტის დაშიფვრა
            string encrypted = "";
            foreach (char s in text)
            {
                if (symbols.Contains(s))
                {
                    //სიმბოლოების მასივში სიმბოლოს ინდექსი შეესაბამება
                    //აჩეხილ მასივში იმავე ადგილზე მდგომი სიმბოლოს ინდექსს
                    //ანუ ხდება მასივთა 'მაპირება'  -  mapping
                    encrypted += key_symbols[Array.IndexOf(symbols, s)];
                }
            }
            return encrypted;
        }

        private string decrypt(string text)
        {
            //ყველა სიმბოლოს ჩაწერა მასივში
            int j = 0;
            for (int i = 0; i < 126; i++)
            {
                symbols[j] = (char)i;
                j++;
            }
            //სიმბოლოების მასივის აჩეხვა
            Random randomizer = new Random(text.Length);
            key_symbols = symbols.OrderBy(x => randomizer.Next()).ToArray();

            //ტექსტის გაშიფვრა
            string decrypted = "";
            foreach(char t in text)
            {
                decrypted += symbols[Array.IndexOf(key_symbols, t)];
            }
            return decrypted;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //ფაილის ასარჩევი დიალოგური ფანჯარა
                openFileDialog1.Title = "აირჩიეთ დასაშიფრი ფაილი...";
                openFileDialog1.ShowDialog();
                string filename = openFileDialog1.FileName;
                
                label5.Text = filename;
                read = File.ReadAllText(filename);
                plain_text1.Text = read;

            }
            catch(Exception)
            {
                //თუ ვერ წაიკითხა ვერაფერი პროგრამა დარესტარტდება
                System.Windows.Forms.Application.Restart();
            }
               
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //ტექსტის დაშიფვრის ღილაკი
        private void button2_Click(object sender, EventArgs e)
        {
            
            string text = encrypt(read);
            encrypted_text1.Text = text;
        }

        //ფაილში ჩაწერის ღილაკი
        private void write_to_file_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(openFileDialog1.FileName);
            string encrypted_filename = "encrypted_" + filename;
            File.WriteAllText(encrypted_filename, encrypt(read));
            MessageBox.Show("დაშიფრული ფაილი ჩაიწერა ფაილში " + encrypted_filename + "");
        }


        //დაშიფრული ტექსტის წაკითხვის ღილაკი
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "აირჩიეთ დასაშიფრი ფაილი...";
            openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;

            label8.Text = filename;
            read = File.ReadAllText(filename);
            encrypted_Text2.Text = read;
        }


        //დაშიფრული ტექსტის გაშიფვრის ღილაკი
        private void button4_Click(object sender, EventArgs e)
        {

            decrypted_text2.Text = decrypt(read);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        //გაშიფრული ტექსტის ფაილში ჩაწერის ღილაკი
        private void button5_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileName(openFileDialog1.FileName);
            string decrypted_filename = "decrypted_" + filename;
            File.WriteAllText(decrypted_filename, decrypt(read));
            MessageBox.Show("გაშიფრული ფაილი ჩაიწერა ფაილში " + decrypted_filename + "");
        }
    }
}
