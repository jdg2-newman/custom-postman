using CustomPostman;

namespace CustomPostmanUI
{
    public partial class Dashboard : Form
    {
        private readonly IApiAccess api = new ApiAccess();

        public Dashboard()
        {
            InitializeComponent();
            httpVerbSelection.SelectedItem = "GET";
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private async void callAPI_Click(object sender, EventArgs e)
        {
            systemStatus.Text = "Calling API...";
            resultsText.Text = "";

            //validate api url coming very very soon!
            if (api.ValidateUrl(apiText.Text) == false)
            {
                systemStatus.Text = "Invalid URL";
                return;
            }


            try
            {

                resultsText.Text = await api.CallApiAsync(apiText.Text);
                callData.SelectedTab = resultsTab;

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
