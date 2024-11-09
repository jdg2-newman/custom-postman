namespace CustomPostmanUI
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void callAPI_Click(object sender, EventArgs e)
        {
            //validate api url coming soon


            try
            {
                systemStatus.Text = "Calling API...";


                // placeholder delay - to be replaced
                await Task.Delay(2000);

                systemStatus.Text = "Ready";
            }
            catch (Exception ex)
            {

                resultsText.Text = "Error: " + ex.Message;
                systemStatus.Text = "Error";
            }
        }

        private void resultsLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
