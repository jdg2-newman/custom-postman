using CustomPostman;

namespace CustomPostmanUI
{
    public partial class Dashboard : Form
    {
        private readonly ApiAccess api = new ();

        public Dashboard()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void callAPI_Click(object sender, EventArgs e)
        {
            //validate api url coming very very soon!


            try
            {
                systemStatus.Text = "Calling API...";


                resultsText.Text = await api.CallApiAsync(apiText.Text);

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
