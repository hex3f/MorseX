using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorseXClient
{
    public partial class MorseTranslator : Form
    {
        public MorseTranslator()
        {
            InitializeComponent();
        }

        private void MorseTranslator_Load(object sender, EventArgs e)
        {
            MorseCodeTranslator.InitialiseDictionary();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string morse = MorseCodeTranslator.DecodeMorse(InputText.Text);
            if (string.IsNullOrEmpty(morse)) return;
            TranslateText.Text = morse;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TranslateText.Text = MorseCodeTranslator.translate(InputText.Text);
        }
    }
}
