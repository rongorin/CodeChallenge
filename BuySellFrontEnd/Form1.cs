
using BuySell.BusinessLogic;
using Common.Utils;
using System; 
using System.Linq;
using System.Text; 
using System.Windows.Forms;

namespace BuySellFrontEnd
{
    public partial class Form1 : Form
    {  
        public Form1()
        {
            InitializeComponent(); 

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            lblResults.Text = string.Empty;

            try
            {
                decimal[] pricesLastMonth = ReadInputFile.ReadPrices(lblSelectedFile.Text).ToArray();

                var results = ProcessBuySell.CalculateBestProfit(pricesLastMonth);
  
                lblResults.Text = $"{results.BuyDay}({results.BuyPrice}),{results.SellDay}({results.SellPrice})";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Your entry was not valid: {ex.Message}");
            }
        } 
 
        private void btnFileFind_Click_1(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"c:\",
                Title = "Browse Text Files",  
                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt", 
            }; 
            if (openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                lblSelectedFile.Text = openFileDialog1.FileName;
                btnLoadFile.Enabled = true; 
            }
        }
         

    }
}
